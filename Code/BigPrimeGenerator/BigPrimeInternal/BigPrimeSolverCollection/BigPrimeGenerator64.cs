//Copyright(c) update 2024 the exc-jdbi
//All rights reserved, see license.
//https://github.com/exc-jdbi/BigPrimeGenerators



using System.Numerics;
using System.Security.Cryptography;

namespace exc.jdbi.VeryBigPrimes.Generators;

partial class BigPrimeGeneratorInternal
{
  private class BigPrimeGenerator64
  {
    private readonly static RandomNumberGenerator Rand = RandomNumberGenerator.Create();

    public async static Task<ulong[]> StartAsync(ulong min, ulong max, int size) =>
      await ToPrimeAsync(min, max, size);

    private async static Task<ulong[]> ToPrimeAsync(ulong min, ulong max, int size)
    {
      using var cts = new CancellationTokenSource();
      var token = cts.Token;

      var tasks = Enumerable.Range(0, size)
          .Select(x => Task.Run(() => ToPrime(min, max))).ToArray();

      var result = await Task.WhenAll(tasks);
      await DisposeAllTaskAsync(tasks);
      return result;
    }

    private static ulong ToPrime(ulong min, ulong max)
    {
      while (true)
      {
        var candidate = RngUlong(min, max);
        if ((candidate & 1) == 0) candidate--;
        if (IsMRPrime(candidate))
          return candidate;
      }
    }

    private static bool IsMRPrime(ulong bignumber)
    {
      if (bignumber < 2UL) return false;
      if (bignumber == 2UL) return true;
      if ((bignumber & 1UL) == 0UL)
        return false; // even number 

      int s = 0;
      ulong z = bignumber - 1;
      while ((z & 1) == 0)
      {
        z >>= 1;
        s += 1;
      }

      ulong tmp;
      for (int a = 2; a <= 5; a++)
      {
        tmp = (ulong)BigInteger.ModPow(a, z, bignumber);
        if (tmp == 1 || tmp == bignumber - 1) continue;
        for (int r = 1; r < s; r++)
        {
          tmp = (ulong)BigInteger.ModPow(tmp, 2, bignumber);
          if (tmp == 1) return false;
          if (tmp == bignumber - 1) break;
        }
        if (!(tmp == bignumber - 1))
          return false;
      }
      return true;
    }

    internal static ulong RngUlong(ulong min, ulong max)
    {
      if (min > max)
        throw new ArgumentOutOfRangeException(
          nameof(min), $"{nameof(min)} may not be greater than {nameof(max)}");

      if (min == max) return min;
      var sz = sizeof(ulong);
      var bytes = new byte[sz];
      Rand.GetNonZeroBytes(bytes);
      var scale = bytes[0] | ((ulong)bytes[1] << 8) | ((ulong)bytes[2] << 16) | ((ulong)bytes[3] << 24) |
                  ((ulong)bytes[4] << 32) | ((ulong)bytes[5] << 40) | ((ulong)bytes[6] << 48) | ((ulong)bytes[7] << 56);
      return (ulong)(min + (max - min) * (scale / (double)(ulong.MaxValue + 1.0)));
    }

    private async static Task DisposeAllTaskAsync(
      Task[] tasks)
    {
      try
      {
        await Task.WhenAll(tasks);
        Array.ForEach(tasks, x => x.Dispose());
        tasks = [];
      }
      catch (OperationCanceledException) { }
      catch (Exception) { }
    }
  }
}
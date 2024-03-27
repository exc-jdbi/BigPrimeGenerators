//Copyright(c) update 2024 the exc-jdbi
//All rights reserved, see license.
//https://github.com/exc-jdbi/BigPrimeGenerators


using System.Numerics;
using System.Security.Cryptography;


namespace exc.jdbi.VeryBigPrimes.Generators;

partial class BigPrimeGeneratorInternal
{
  private class BigPrimeGenerator256
  {
    private readonly static RandomNumberGenerator Rand = RandomNumberGenerator.Create();

    public async static Task<BigInteger[]> StartAsync(BigInteger min, BigInteger max, int size) =>
      await ToPrimeAsync(min, max, size);

    private async static Task<BigInteger[]> ToPrimeAsync(BigInteger min, BigInteger max, int size)
    {
      var tasks = Enumerable.Range(0, size)
          .Select(x => Task.Run(() => ToPrime(min, max))).ToArray();

      var result = await Task.WhenAll(tasks);
      await DisposeAllTaskAsync(tasks);
      return result;
    }

    private static BigInteger ToPrime(BigInteger min, BigInteger max)
    {
      while (true)
      {
        var candidate = RngBigInteger(min, max);
        if ((candidate & 1) == 0) candidate--;
        if (IsMRPrime(candidate))
          return candidate;
      }
    }

    private static bool IsMRPrime(BigInteger bignumber)
    {
      if (bignumber < 2UL) return false;
      if (bignumber == 2UL) return true;
      if ((bignumber & 1UL) == 0UL)
        return false; // even number 

      int s = 0;
      BigInteger z = bignumber - 1;
      while ((z & 1) == 0)
      {
        z >>= 1;
        s += 1;
      }

      BigInteger tmp;
      for (int a = 2; a <= 5; a++)
      {
        tmp = BigInteger.ModPow(a, z, bignumber);
        if (tmp == 1 || tmp == bignumber - 1) continue;
        for (int r = 1; r < s; r++)
        {
          tmp = BigInteger.ModPow(tmp, 2, bignumber);
          if (tmp == 1) return false;
          if (tmp == bignumber - 1) break;
        }
        if (!(tmp == bignumber - 1))
          return false;
      }
      return true;
    }

    private static BigInteger RngBigInteger(
      BigInteger min, BigInteger max)
    {
      var bytes = (max - min).ToByteArray();
      Rand.GetNonZeroBytes(bytes);
      bytes[^1] = (byte)(bytes.Last() & 0x7F);

      var result = min + new BigInteger(bytes);
      if (result > max) return RngBigInteger(min, max);
      return result;
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


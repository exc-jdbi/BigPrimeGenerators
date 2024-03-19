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




//private class BigPrimeGenerator256
//{
//  private const int PARALLEL_COUNT = 10;
//  private readonly static Random Rand = new();

//  private static BigInteger[] Test_Primes = [];

//  public async static Task<BigInteger> Start(
//    BigInteger min, BigInteger max, int pcount = -1)
//  {
//    var len = max.ToString().Length;
//    var bitslength = BigInteger.Log2(max) + 1;
//    var cnt = len < 100 ? 100 : 100 + (int)Math.Sqrt(len);

//    var pmax = (int)bitslength < 3571 ? 3571 : (int)bitslength;//The 500th prime is 3571.
//    Test_Primes = SoELinq500(pmax).Select(x => (BigInteger)x).Take(2 * cnt).ToArray();

//    pcount = pcount < PARALLEL_COUNT || max.ToString().Length < 100
//               ? PARALLEL_COUNT
//               : (int)Math.Sqrt(max.ToString().Length);
//    return await ToBigPrimeAsync(min, max, pcount);
//  }

//  private async static Task<BigInteger> ToBigPrimeAsync(
//    BigInteger min, BigInteger max, int pcount = PARALLEL_COUNT)
//  {
//    return await ToLevelPrimeAsync(min, max, pcount);
//  }

//  private async static Task<BigInteger> ToLevelPrimeAsync(
//    BigInteger min, BigInteger max, int pcount = PARALLEL_COUNT)
//  {

//    if (pcount < 2) pcount = PARALLEL_COUNT;
//    while (true)
//    {
//      using var cts = new CancellationTokenSource();
//      var token = cts.Token;
//      var tasks = Enumerable.Range(0, pcount)
//          .Select(x => Task.Run(() => ToLevelPrime(min, max, token))).ToArray();

//      var result = BigInteger.MinusOne;
//      var idx = Task.WaitAny(tasks, 5000, token);
//      if (idx >= 0)
//      {
//        result = tasks[idx].Result;
//        cts.Cancel();
//      }

//      await DisposeAllTaskAsync(tasks);

//      if (result > 1) return result;
//    }
//  }

//  private static BigInteger ToLevelPrime(
//    BigInteger min, BigInteger max, CancellationToken token)
//  {
//    while (true)
//    {
//      if (token.IsCancellationRequested)
//        return -1;

//      var candidate = RngBigInteger(min, max);

//      if (token.IsCancellationRequested)
//        return -1;

//      if (CheckTestPrimes(ref candidate, token))
//        if (IsMRPrime(candidate))
//          return candidate;
//    }
//  }

//  private static bool IsMRPrime(BigInteger bignumber)
//  {
//    if (bignumber < 2UL) return false;
//    if (bignumber == 2UL) return true;
//    if ((bignumber & 1UL) == 0UL)
//      return false; // even number 

//    int s = 0;
//    BigInteger z = bignumber - 1;
//    while ((z & 1) == 0)
//    {
//      z >>= 1;
//      s += 1;
//    }

//    BigInteger tmp;
//    for (int a = 2; a <= 5; a++)
//    {
//      tmp = BigInteger.ModPow(a, z, bignumber);
//      if (tmp == 1 || tmp == bignumber - 1) continue;
//      for (int r = 1; r < s; r++)
//      {
//        tmp = BigInteger.ModPow(tmp, 2, bignumber);
//        if (tmp == 1) return false;
//        if (tmp == bignumber - 1) break;
//      }
//      if (!(tmp == bignumber - 1))
//        return false;
//    }
//    return true;
//  }

//  private static BigInteger RngBigInteger(
//    BigInteger min, BigInteger max)
//  {
//    var bytes = (max - min).ToByteArray();
//    Rand.NextBytes(bytes);
//    bytes[^1] = (byte)(bytes.Last() & 0x7F);

//    var result = min + new BigInteger(bytes);
//    if (result > max) return RngBigInteger(min, max);
//    return result;
//  }

//  private static bool CheckTestPrimes(
//    ref BigInteger candidate, CancellationToken token)
//  {
//    if ((candidate & 1) == 0) candidate--;
//    for (int i = 1; i < Test_Primes.Length; i++)
//    {
//      if (token.IsCancellationRequested)
//        return false;

//      if (candidate == Test_Primes[i])
//        return true;

//      //Very, very slow operation
//      if (candidate % Test_Primes[i] == 0)
//        return false;
//    }

//    return true;
//  }

//  private async static Task DisposeAllTaskAsync(
//    Task[] tasks)
//  {
//    try
//    {
//      await Task.WhenAll(tasks);
//      Array.ForEach(tasks, x => x.Dispose());
//      tasks = [];
//    }
//    catch (OperationCanceledException) { }
//    catch (Exception) { }
//  }



//  private static int[] SoELinq500(int max)
//  {
//    int sqrt = (int)Math.Round(Math.Truncate(Math.Sqrt(max)));
//    var seed = Enumerable.Range(2, max - 1).Select(x => !(x == 2) && (x & 1) == 0 ? 0 : x).ToArray();
//    var primes = Enumerable.Range(2, sqrt)
//    .Where(x => (x & 1) == 1)
//    .Aggregate(seed, (sieve, i) =>
//    {
//      if (sieve[i - 2] == 0)
//        return sieve;
//      int j = i * i;
//      while (j <= max)
//      {
//        sieve[j - 2] = 0;
//        j += 2 * i;
//      }
//      return sieve;
//    }).Where(k => !(k == 0));
//    //File.WriteAllText("p.txt",string.Join(Environment.NewLine, primes));
//    return primes.ToArray();
//  }
//}
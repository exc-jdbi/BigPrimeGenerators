//Copyright(c) update 2024 the exc-jdbi
//All rights reserved, see license.
//https://github.com/exc-jdbi/BigPrimeGenerators



using System.Numerics;
using System.Security.Cryptography;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Threading;

namespace exc.jdbi.VeryBigPrimes.Generators;

partial class BigPrimeGeneratorInternal
{
  private class BigPrimeGenerator2070X190
  {
    //Formula:
    //2070x+1; 2070x+91; 2070x+181; 2070x+271; 2070x+361 --> c = 90;
    //a0 = 2070x + 1; a1 = a0 + 90; a2 = a1 + 90 ... 

    private const int XX = 2070;
    private const int CC = 90; //Spacing
    private const int PARALLEL_COUNT = 10;
    private static BigInteger[] Test_Primes = [];
    private readonly static RandomNumberGenerator Rand = RandomNumberGenerator.Create();

    public async static Task<BigInteger[]> StartAsync(
              BigInteger min, BigInteger max, int size, int pcount = -1)
    {
      var tasks = Enumerable.Range(0, size)
                  .Select(x => Task.Run(() => StartSingleAsync(min, max, pcount))).ToArray();

      var result = await Task.WhenAll(tasks);
      await DisposeAllTaskAsync(tasks);
      return result;
    }

    public async static Task<BigInteger> StartSingleAsync(
      BigInteger min, BigInteger max, int pcount = -1)
    {
      var len = max.ToString().Length;
      var bitslength = BigInteger.Log2(max) + 1;
      var cnt = len < 100 ? 100 : 100 + (int)Math.Sqrt(len);

      var pmax = (int)bitslength < 3571 ? 3571 : (int)bitslength;//The 500th prime is 3571.
      Test_Primes = SoELinq(pmax).Select(x => (BigInteger)x).Take(2 * cnt).ToArray();

      pcount = pcount < PARALLEL_COUNT || max.ToString().Length < 100
                 ? PARALLEL_COUNT
                 : (int)Math.Sqrt(max.ToString().Length);
      return await ToBigPrimeAsync(min, max, pcount);
    }

    private async static Task<BigInteger> ToBigPrimeAsync(
      BigInteger min, BigInteger max, int pcount = PARALLEL_COUNT)
    {
      var mi = (min - 1) / XX;
      mi = mi * XX + 1 >= min ? mi : mi + 1;

      var ma = (max - (22 * CC + 1)) / XX;
      ma = ma * XX + (22 * CC + 1) <= max ? ma : ma - 1;

      return await ToLevelPrimeAsync(min, max, mi, ma, pcount);
    }

    private async static Task<BigInteger> ToLevelPrimeAsync(
      BigInteger min, BigInteger max,
      BigInteger mi, BigInteger ma,
      int pcount = PARALLEL_COUNT)
    {
      if (pcount < 2) pcount = PARALLEL_COUNT;
      while (true)
      {
        using var cts = new CancellationTokenSource();
        var token = cts.Token;
        var tasks = Enumerable.Range(0, pcount)
            .Select(x => Task.Run(() =>
              ToLevelPrime2(min, max, mi, ma, token))).ToArray();

        var result = BigInteger.MinusOne;
        var idx = Task.WaitAny(tasks, token);
        if (idx >= 0 && tasks[idx].Result > 1)
        {
          result = tasks[idx].Result;
          cts.Cancel();
        }

        await DisposeAllTaskAsync(tasks);

        if (result > 1) return result;
      }
    } 

    private static BigInteger ToLevelPrime2(
          BigInteger min, BigInteger max,
          BigInteger mi, BigInteger ma,
          CancellationToken token)
    {
      while (true)
      {
        if (token.IsCancellationRequested)
          return -1;

        var btwo = new BigInteger(2);
        var m = RngBigInteger(mi, ma);

        foreach (var idx in OrderOperation())
        {
          if (token.IsCancellationRequested)
            return -1;

          var candidate = XX * m + idx * CC + 1;
          if (candidate.IsEven) candidate--;

          if (candidate < min || candidate > max)
            break;

          //in first the Fermat-Test
          if (BigInteger.ModPow(btwo, BigInteger.Subtract(candidate, BigInteger.One), candidate) == BigInteger.One)
            if (CheckTestPrimes(ref candidate, token))
              if (IsMRPrime(candidate))
                return candidate;
        }
      }
    }

    private static bool CheckTestPrimes(
      ref BigInteger candidate, CancellationToken token)
    {
      if ((candidate & 1) == 0) candidate--;
      for (int i = 1; i < Test_Primes.Length; i++)
      {
        if (token.IsCancellationRequested)
          return false;

        if (candidate == Test_Primes[i])
          return true;

        if (candidate % Test_Primes[i] == 0)
          return false;
      }

      return true;
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

    private static int[] SoELinq(int max)
    {
      int sqrt = (int)Math.Round(Math.Truncate(Math.Sqrt(max)));
      var seed = Enumerable.Range(2, max - 1).Select(x => !(x == 2) && (x & 1) == 0 ? 0 : x).ToArray();
      var primes = Enumerable.Range(2, sqrt)
      .Where(x => (x & 1) == 1)
      .Aggregate(seed, (sieve, i) =>
      {
        if (sieve[i - 2] == 0)
          return sieve;
        int j = i * i;
        while (j <= max)
        {
          sieve[j - 2] = 0;
          j += 2 * i;
        }
        return sieve;
      }).Where(k => !(k == 0));
      //File.WriteAllText("p.txt",string.Join(Environment.NewLine, primes));
      return primes.ToArray();
    }

    private static int[] OrderOperation()
    {
      //This sequence is based on tests that I have carried out. 
      //Excluding the number 12, since 2070x + 12 * 90 + 1 is not coprime to 2070.

      //Ohne die Zahl 12, da 2070x + 12 * 90 + 1 nicht teilerfremd zu 2070 ist.
      return "9,2,13,4,15,17,22,20,5,10,11,21,1,6,18,3,16,19,7,0,8,14" //without 12
            .Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
    }
  }
}


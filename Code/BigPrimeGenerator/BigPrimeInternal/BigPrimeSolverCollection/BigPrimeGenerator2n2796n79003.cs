//Copyright(c) update 2024 the exc-jdbi
//All rights reserved, see license.
//https://github.com/exc-jdbi/BigPrimeGenerators


using System.Numerics;
using System.Security.Cryptography;


namespace exc.jdbi.VeryBigPrimes.Generators;

partial class BigPrimeGeneratorInternal
{
  private class BigPrimeGenerator2n2796n79003
  {

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
      var (mi, ma) = ToMinMax(min, max);
      pcount = pcount < PARALLEL_COUNT || max.ToString().Length < 100
                 ? PARALLEL_COUNT
                 : (int)Math.Sqrt(max.ToString().Length);

      var len = max.ToString().Length;
      var bitslength = (int)BigInteger.Log2(max) + 1;
      var cnt = len < 100 ? 100 : 100 + (int)Math.Sqrt(len);
      var pmax = bitslength < 3571 ? 3571 : bitslength; //The 500th prime is 3571.
      Test_Primes = SoELinq500(pmax).Select(x => (BigInteger)x).Take(2 * cnt).ToArray();
      return await ToBigPrimeAsync(mi, ma, pcount);
    }


    private async static Task<BigInteger> ToBigPrimeAsync(
      BigInteger min, BigInteger max, int pcount = PARALLEL_COUNT)
    {
      var candidate = await ToLevelPrimeAsync(min, max, pcount);
      return candidate;
    }

    private async static Task<BigInteger> ToLevelPrimeAsync(
      BigInteger min, BigInteger max, int pcount = PARALLEL_COUNT)
    {
      if (pcount < 2) pcount = PARALLEL_COUNT;
      while (true)
      {
        using var cts = new CancellationTokenSource();
        var token = cts.Token;
        var tasks = Enumerable.Range(0, pcount)
            .Select(x => Task.Run(() => ToLevelPrime(min, max, token))).ToArray();

        var result = BigInteger.MinusOne;
        var idx = Task.WaitAny(tasks, token);
        if (idx >= 0)
        {
          result = tasks[idx].Result;
          cts.Cancel();
        }

        await DisposeAllTaskAsync(tasks);

        if (result > 1) return result;
      }
    }

    private static BigInteger ToLevelPrime(
      BigInteger min, BigInteger max, CancellationToken token)
    {
      var loc_obj = new object();

      while (true)
      {
        if (token.IsCancellationRequested)
          return -1;

        var (nn, np) = Calc2n2796n79003(RngBigInteger(min, max));

        lock (loc_obj)
        {
          if (CheckTestPrimes(ref np, token))
          {
            if (token.IsCancellationRequested)
              return -1;
            if (IsMRPrime(np))
              return np;
          }
        }

        lock (loc_obj)
        {
          if (CheckTestPrimes(ref nn, token))
          {
            if (token.IsCancellationRequested)
              return -1;
            if (IsMRPrime(nn))
              return nn;
          }
        }
      }

      throw new ArgumentOutOfRangeException(nameof(min));
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

        //Very, very slow operation
        if (candidate % Test_Primes[i] == 0)
          return false;
      }

      return true;
    }

    private static (BigInteger Min, BigInteger Max) ToMinMax(BigInteger _min, BigInteger _max)
    {
      BigInteger sqmin = Sqrt(_min / 2), sqmax = Sqrt(_max / 2);
      while (Calc2n2796n79003(sqmin).NN > _min) sqmin--;
      while (Calc2n2796n79003(sqmax).NP > _max) sqmax--;
      return (sqmin + 1, sqmax);
    } 

    private static (BigInteger NN, BigInteger NP) Calc2n2796n79003(
      BigInteger n)
    {
      var result = 2 * n * n;
      result += 796 * n;
      return (result - 79003, result + 79003);
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

    private static BigInteger Sqrt(BigInteger n)
    {
      if (n == 0) return 0;
      if (n > 0)
      {
        //log2(n)+1
        int bitlength = Convert.ToInt32(Math.Ceiling(BigInteger.Log(n, 2)));
        var root = BigInteger.One << (bitlength / 2);

        while (!IsSqrt(n, root))
        {
          root += n / root;
          root /= 2;
        }

        return root;
      }

      throw new ArithmeticException("NaN");
    }

    private static bool IsSqrt(BigInteger n, BigInteger root)
    {
      var lower = root * root;
      var upper = (root + 1) * (root + 1);
      return (n >= lower && n < upper);
    }

    private static int[] SoELinq500(int count)
    {

      //That's how I defined it.
      //The 500th prime is 3571. This many primes will never be needed.
      //Example: For a search-prime with e.g. 1024 digits, 100 + Sq(1024) = 132 test primes are needed. 
      var max = 3572;
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
      return primes.Take(count).ToArray();
    }
  }


}


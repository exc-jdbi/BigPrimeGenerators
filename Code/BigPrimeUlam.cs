﻿
//Copyright(c) update 2024 the exc-jdbi
//All rights reserved, see license.
//https://github.com/exc-jdbi/BigPrimeGenerators

using System.Text;
using System.Numerics;
using System.Diagnostics;

//For larger primes from 1024 digits, it is a bit faster than PFPG

namespace exc.jdbi.VeryBigPrimes.Generators;


public class BigPrimeUlam2n2796n79003
{

  private const int PARALLEL_COUNT = 10;
  private readonly static Random Rand = new();
  private static BigInteger[] First_Primes = [];

  public async static void Start()
  {
    var bits = BitsPrime.Bit2048; 
    var _max = (BigInteger.One << (int)bits) - 1;
    //var _min = (BigInteger.One << ((int)bits - 1)) + 1;

    var (min, max) = ToMinMax(bits);
    var pcount = _max.ToString().Length < 100 ? 10 : (int)Math.Sqrt(_max.ToString().Length);

    var sw = Stopwatch.StartNew();
    var prime = await ToBigPrimeAsync(min, max, pcount);
    sw.Stop();

    var strprime = prime.ToString();
    var bits_length = BigInteger.Log2(prime) + 1;

    var sb = new StringBuilder();
    sb.AppendLine($"t = {sw.ElapsedMilliseconds}ms");
    sb.AppendLine($"bits = {bits_length}");
    sb.AppendLine($"digits = {strprime.Length}");
    sb.AppendLine($"prime = {strprime}");

    Debug.WriteLine(sb.ToString());

    MessageBox.Show(sb.ToString());
  }


  private async static Task<BigInteger> ToBigPrimeAsync(
    BigInteger min, BigInteger max, int pcount = PARALLEL_COUNT)
  {
    var len = max.ToString().Length;
    var cnt = len < 100 ? 100 : 100 + (int)Math.Sqrt(len);
    First_Primes = SoELinq500(cnt * 2).Select(x => (BigInteger)x).ToArray();
    var candidate = await ToLowLevelPrimeAsync(min, max, pcount);
    return candidate;
  }

  private async static Task<BigInteger> ToLowLevelPrimeAsync(
    BigInteger min, BigInteger max, int pcount = PARALLEL_COUNT)
  {
    if (pcount < 2) pcount = PARALLEL_COUNT;
    while (true)
    {
      using var cts = new CancellationTokenSource();
      var token = cts.Token;
      var tasks = Enumerable.Range(0, pcount)
          .Select(x => Task.Run(() => ToLowLevelPrime(min, max, token))).ToArray();

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

  private static BigInteger ToLowLevelPrime(
    BigInteger min, BigInteger max, CancellationToken token)
  {
    var loc_obj = new object();

    while (true)
    {
      if (token.IsCancellationRequested)
        return -1;

      var (nn, np) = CalcUlam2n2796n79003(RngBigInteger(min, max));

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
    for (int i = 1; i < First_Primes.Length; i++)
    {
      if (token.IsCancellationRequested)
        return false;

      if (candidate == First_Primes[i])
        return true;

      //Very, very slow operation
      if (candidate % First_Primes[i] == 0)
        return false;
    }

    return true;
  }

  private static (BigInteger Min, BigInteger Max) ToMinMax(
    BitsPrime bits)
  {
    var bit = (int)bits;
    var (min, max) = ToMinMaxFromBits(bit);
    BigInteger sqmin = Sqrt(min / 2), sqmax = Sqrt(max / 2);
    while (CalcUlam2n2796n79003(sqmin).NN > min) sqmin--;
    while (CalcUlam2n2796n79003(sqmax).NP > max) sqmax--;
    return (sqmin + 1, sqmax);
  }

  private static (BigInteger NN, BigInteger NP) CalcUlam2n2796n79003(
    BigInteger n)
  {
    var result = 2 * n * n;
    result += 796 * n;
    return (result - 79003, result + 79003);
  }

  private static (BigInteger Min, BigInteger Max) ToMinMaxFromBits(
    int bits)
  {
    var _max = (BigInteger.One << bits) - 1;        // 10 bit --> 1111111111 = 1023
    var _min = (BigInteger.One << (bits - 1)) + 1;  // 10 bit --> 1000000000 = 512
    return (_min, _max);
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
    Rand.NextBytes(bytes);
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

  private static string BigIntegerToBinaryString(BigInteger x)
  {
    //www.stackoverflow.com

    ReadOnlySpan<byte> srcBytes = x.ToByteArray();
    int srcLoc = srcBytes.Length - 1;

    // Find the first bit set in the first byte so we
    // don't print extra zeros.
    int msb = BitOperations.Log2(srcBytes[srcLoc]);

    // Setup Target
    Span<char> dstBytes = stackalloc char[srcLoc * 8 + msb + 2];
    int dstLoc = 0;

    // Add leading '-' sign if negative.
    if (x.Sign < 0)
      dstBytes[dstLoc++] = '-';
    //else if (!x.IsZero) dstBytes[dstLoc++] = '0'; // add adding leading '0' (optional)

    // The first byte is special because we don't want to print
    // leading zeros.
    byte b = srcBytes[srcLoc--];
    for (int j = msb; j >= 0; j--)
      dstBytes[dstLoc++] = (char)('0' + ((b >> j) & 1));

    // Add the remaining bits.
    for (; srcLoc >= 0; srcLoc--)
    {
      byte b2 = srcBytes[srcLoc];
      for (int j = 7; j >= 0; j--)
        dstBytes[dstLoc++] = (char)('0' + ((b2 >> j) & 1));
    }
    return dstBytes.ToString();
  }

}



public enum BitsPrime : int
{
  Bit128 = 128,
  Bit256 = 256,
  Bit512 = 512,
  Bit1024 = 1024,
  Bit2048 = 2048,
  Bit4096 = 4096,
  Bit8192 = 8192,
  Bit16384 = 16384,
  Bit32768 = 32768,
}

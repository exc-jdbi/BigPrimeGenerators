
//Copyright(c) update 2024 the exc-jdbi
//All rights reserved.

//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in
//all copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//THE SOFTWARE.

using System.Text;
using System.Numerics;
using System.Diagnostics;

//For larger primes from 1024 digits, it is a bit faster than PFPG

namespace exc.jdbi.VeryBigPrimes.Generators;


public class BigPrimeShiftLeft
{

  private const int PARALLEL_COUNT = 10;
  private readonly static Random Rand = new();

  private static BigInteger[] First_Primes = [];

  public async static void Start()
  {
    var sw = Stopwatch.StartNew();

    //Variant over BITS
    //*******************

    //2 * 1024 bit (ca.  309 digits) multipliziert ergibt einen RSA-Key von 2048 bit.
    //2 * 2048 bit (ca.  617 digits) multipliziert ergibt einen RSA-Key von 4096 bit.
    //2 * 4096 bit (ca. 1233 digits) multipliziert ergibt einen RSA-Key von 8192 bit. 
    var cbits = 4096; // ca. 1233 digits

    var max = (BigInteger.One << cbits) - 1;
    var pcount = max.ToString().Length < 100 ? 100 : (int)Math.Sqrt(max.ToString().Length);

    var prime = await ToBigPrimeAsync(cbits, pcount);
    sw.Stop();

    var strprime = prime.ToString();
    //var bits = BigIntegerToBinaryString(prime);
    var bits_length = BigInteger.Log2(prime) + 1;

    var sb = new StringBuilder();
    sb.AppendLine($"t = {sw.ElapsedMilliseconds}ms");
    sb.AppendLine($"bits = {bits_length}");
    sb.AppendLine($"digits = {strprime.Length}");
    sb.AppendLine($"prime = {strprime}");

    Debug.WriteLine(sb.ToString());

    MessageBox.Show(sb.ToString());
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


  private async static Task<BigInteger> ToBigPrimeAsync(
     int bits, int pcount = PARALLEL_COUNT)
  {
    var max = (BigInteger.One << bits) - 1;
    var len = max.ToString().Length;
    var cnt = len < 100 ? 100 : 100 + (int)Math.Sqrt(len);
    First_Primes = SoELinq500(cnt * 2).Select(x => (BigInteger)x).ToArray();
    var candidate = await ToLowLevelPrimeAsync(bits, pcount);
    return candidate;
  }

  private async static Task<BigInteger> ToLowLevelPrimeAsync(
    int bits, int pcount = PARALLEL_COUNT)
  {
    if (pcount < 2) pcount = PARALLEL_COUNT;
    while (true)
    {
      using var cts = new CancellationTokenSource();
      var token = cts.Token;
      var tasks = Enumerable.Range(0, pcount)
          .Select(x => Task.Run(() => ToLowLevelPrime(bits, token))).ToArray();

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
    int bits, CancellationToken token)
  {
    var loc_obj = new object();

    while (true)
    {
      var n = Rand.Next(1, bits);
      var a = ((BigInteger.One << bits) / (BigInteger.One << n)) - 1;

      for (var j = 0; j < 4; j++)
      {
        if (token.IsCancellationRequested)
          return -1;

        lock (loc_obj)
        {
          // Pc = A * (2 ^ N) - 1
          var candidate1 = (a << n) - 1;
          if (candidate1 < 2) continue;
          if (CheckTestPrimes(ref candidate1, token))
          {
            if (token.IsCancellationRequested)
              return -1;
            if (IsMRPrime(candidate1))
              return candidate1;
          }
        }

        if (token.IsCancellationRequested)
          return -1;

        lock (loc_obj)
        {
          // Pc = A * (2 ^ N) + 1
          var candidate2 = (a << n) + 1;
          if (candidate2 < 2) continue;
          if (CheckTestPrimes(ref candidate2, token))
          {
            if (token.IsCancellationRequested)
              return -1;
            if (IsMRPrime(candidate2))
              return candidate2;
          }
        }
        a--;
      }
    }

    throw new ArgumentOutOfRangeException(nameof(bits));
  }

  private static bool CheckTestPrimes(ref BigInteger candidate, CancellationToken token)
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

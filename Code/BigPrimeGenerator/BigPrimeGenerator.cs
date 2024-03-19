//Copyright(c) update 2024 the exc-jdbi
//All rights reserved, see license.
//https://github.com/exc-jdbi/BigPrimeGenerators


using System.Numerics;


namespace exc.jdbi.VeryBigPrimes.Generators;


public partial class BigPrimeGenerator
{
  public static ulong[] RngPrimes(int size) =>
    RngPrimes(ulong.MinValue, ulong.MaxValue, size);

  public static ulong[] RngPrimes(ulong max, int size) =>
    RngPrimes(ulong.MinValue, max, size);

  public static ulong[] RngPrimes(ulong min, ulong max, int size) =>
    BigPrimeGeneratorInternal.RngPrimes(min, max, size);

  public static BigInteger[] RngBigPrimes(int digits, int size)
  {
    var (min, max) = ToMinMaxFromDigits(digits);
    return BigPrimeGeneratorInternal.RngBigPrimes(min, max, size);
  }

  public static BigInteger[] RngBigPrimes(BitsPrime bits, int size)
  {
    var (min, max) = ToMinMaxFromBits((int)bits);
    return BigPrimeGeneratorInternal.RngBigPrimes(min, max, size);
  }

  public static BigInteger[] RngBigPrimes(BigInteger min, BigInteger max, int size) =>
    BigPrimeGeneratorInternal.RngBigPrimes(min, max, size);

  //Async-Await

  public async static Task<ulong[]> RngPrimesAsync(int size) =>
    await RngPrimesAsync(ulong.MinValue, ulong.MaxValue, size);

  public async static Task<ulong[]> RngPrimesAsync(ulong max, int size) =>
    await RngPrimesAsync(ulong.MinValue, max, size);

  public async static Task<ulong[]> RngPrimesAsync(ulong min, ulong max, int size) =>
    await BigPrimeGeneratorInternal.RngPrimesAsync(min, max, size);

  public async static Task<BigInteger[]> RngBigPrimesAsync(int digits, int size)
  {
    var (min, max) = ToMinMaxFromDigits(digits);
    return await BigPrimeGeneratorInternal.RngBigPrimesAsync(min, max, size);
  }

  public async static Task<BigInteger[]> RngBigPrimesAsync(BitsPrime bits, int size)
  {
    var (min, max) = ToMinMaxFromBits((int)bits);
    return await BigPrimeGeneratorInternal.RngBigPrimesAsync(min, max, size);
  }

  public async static Task<BigInteger[]> RngBigPrimesAsync(BigInteger min, BigInteger max, int size) =>
    await BigPrimeGeneratorInternal.RngBigPrimesAsync(min, max, size);



  public static (BigInteger Min, BigInteger Max) ToMinMaxFromBits(int bits)
  {
    var _max = (BigInteger.One << bits) - 1;        // 10 bit --> 1111111111 = 1023
    var _min = (BigInteger.One << (bits - 1)) + 1;  // 10 bit --> 1000000000 = 512
    return (_min, _max);
  }

  public static (BigInteger Min, BigInteger Max) ToMinMaxFromDigits(int digits)
  {
    var _min = "1" + new string('0', digits - 1);
    var _max = new string('9', digits);
    return (BigInteger.Parse(_min), BigInteger.Parse(_max));
  }
  public async static Task<bool> IsNumericAsync(string[] number) =>
    await Task.Run(() => IsNumeric(number));

  public async static Task<bool> IsNumericAsync(string number) =>
    await Task.Run(() => IsNumeric(number));

  public static bool IsNumeric(string[] number)
  {
    if (number is null || number.Length < 1) return false;
    foreach (var str in number)
      if (!IsNumeric(str))
        return false;
    return true;
  }

  public static bool IsNumeric(string number)
  {
    if (string.IsNullOrEmpty(number)) return false;
    foreach (var digit in number)
      if (!int.TryParse(digit.ToString(), out _))
        return false;
    return true;
  }


  public static bool IsMRPrime(BigInteger bignumber)
  {
    if (bignumber < 2UL) return false;
    if (bignumber == 2UL) return true;
    if (bignumber.IsEven)
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
}

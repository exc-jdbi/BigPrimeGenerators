////Copyright(c) update 2024 the exc-jdbi
////All rights reserved, see license.
////https://github.com/exc-jdbi/BigPrimeGenerators


//using System.Numerics;
//using System.Diagnostics;
//using System.Security.Cryptography;


//namespace exc.jdbi.VeryBigPrimes.Generators.Test;


//public class Program
//{
//  public static void Main()
//  {
//    TestPrimeGenerator(10);
//    TestBigPrimeGenerator(3);


//    Console.WriteLine();
//    Console.WriteLine("Finish");
//    Console.ReadLine();

//  }

//  private static void TestPrimeGenerator(int cnt)
//  {
//    TestPrimeGeneratorUI64(cnt);
//  }

//  private static void TestPrimeGeneratorUI64(int cnt)
//  {
//    Console.WriteLine($"{nameof(TestPrimeGeneratorUI64)}\n");

//    var sw = Stopwatch.StartNew();

//    var result1 = BigPrimeGenerator.RngPrimes(cnt);

//    var t1 = sw.ElapsedMilliseconds;

//    sw = Stopwatch.StartNew();

//    var result2 = BigPrimeGenerator.RngPrimes(15ul, 1000ul, cnt);

//    var t2 = sw.ElapsedMilliseconds;

//    sw = Stopwatch.StartNew();

//    var result3 = BigPrimeGenerator.RngPrimes(ulong.MinValue, ulong.MaxValue, cnt);

//    var t3 = sw.ElapsedMilliseconds;

//    var r = new[] { result1, result2, result3 };
//    var b = r.Select(x => (BigInteger)Math.Log2(x[0]) + 1).ToArray();
//    PrintOut("", cnt, b, [t1, t2, t3], result1, result2, result3);


//    Console.WriteLine($"{nameof(TestPrimeGeneratorUI64)}-Async\n");

//    sw = Stopwatch.StartNew();

//    using var aresult1 = BigPrimeGenerator.RngPrimesAsync(cnt);

//    t1 = sw.ElapsedMilliseconds;

//    sw = Stopwatch.StartNew();

//    using var aresult2 = BigPrimeGenerator.RngPrimesAsync(15ul, 1000ul, cnt);

//    t2 = sw.ElapsedMilliseconds;

//    sw = Stopwatch.StartNew();

//    using var aresult3 = BigPrimeGenerator.RngPrimesAsync(ulong.MinValue, ulong.MaxValue, cnt);

//    t3 = sw.ElapsedMilliseconds;

//    r = [aresult1.Result, aresult2.Result, aresult3.Result];
//    b = r.Select(x => (BigInteger)Math.Log2(x[0]) + 1).ToArray();
//    PrintOut("", cnt, b, [t1, t2, t3], aresult1, aresult2, aresult3);
//  }

//  private static void TestBigPrimeGenerator(int cnt)
//  {
//    TestBigPrimeGeneratorUI256(2 * cnt);
//    TestBigPrimeGeneratorUI32768(cnt);
//  }

//  private static void TestBigPrimeGeneratorUI256(int cnt)
//  {
//    //BigPrimeGenerator berechnet alles was kleiner oder gleich wie 
//    //2^256 ist wird in einer separaten Klasse berechnet, damit es
//    //schneller geht. 

//    Console.WriteLine($"{nameof(TestBigPrimeGeneratorUI256)}\n");

//    var digits = (BigInteger.One << 256).ToString().Length - 1;

//    var sw = Stopwatch.StartNew();

//    var result1 = BigPrimeGenerator.RngBigPrimes(digits, cnt);

//    var t1 = sw.ElapsedMilliseconds;

//    sw = Stopwatch.StartNew();

//    var bits = BitsPrime.Bit128;
//    var result2 = BigPrimeGenerator.RngBigPrimes(bits, cnt);

//    var t2 = sw.ElapsedMilliseconds;

//    sw = Stopwatch.StartNew();

//    var min = BigInteger.One << 20;
//    var max = BigInteger.One << 256 - 1; //Ist noch im 256 bit bereich
//    var result3 = BigPrimeGenerator.RngBigPrimes(min, max, cnt);

//    var t3 = sw.ElapsedMilliseconds;

//    var r = new[] { result1, result2, result3 };
//    var b = r.Select(x => BigInteger.Log2(x[0]) + 1).ToArray();
//    PrintOut("", cnt, b, [t1, t2, t3], result1, result2, result3);


//    Console.WriteLine($"{nameof(TestBigPrimeGeneratorUI256)}-Async\n");

//    sw = Stopwatch.StartNew();

//    using var aresult1 = BigPrimeGenerator.RngBigPrimesAsync(digits, cnt);

//    t1 = sw.ElapsedMilliseconds;

//    sw = Stopwatch.StartNew();

//    bits = BitsPrime.Bit256;
//    using var aresult2 = BigPrimeGenerator.RngBigPrimesAsync(bits, cnt);

//    t2 = sw.ElapsedMilliseconds;

//    sw = Stopwatch.StartNew();

//    using var aresult3 = BigPrimeGenerator.RngBigPrimesAsync(min, max, cnt);

//    t3 = sw.ElapsedMilliseconds;

//    r = [aresult1.Result, aresult2.Result, aresult3.Result];
//    b = r.Select(x => BigInteger.Log2(x[0]) + 1).ToArray();
//    PrintOut("", cnt, b, [t1, t2, t3], aresult1, aresult2, aresult3);

//  }

//  private static void TestBigPrimeGeneratorUI32768(int cnt)
//  {
//    //Grosse Primzahlen (> 2^256) werden anders berechnet, damit
//    //die ganze Berechnung schneller ablauft.

//    Console.WriteLine($"{nameof(TestBigPrimeGeneratorUI32768)}\n");

//    var digits = (BigInteger.One << 256).ToString().Length + 1;

//    var sw = Stopwatch.StartNew();

//    var result1 = BigPrimeGenerator.RngBigPrimes(digits, cnt);

//    var t1 = sw.ElapsedMilliseconds;

//    sw = Stopwatch.StartNew();

//    var bits = BitsPrime.Bit1024;
//    var result2 = BigPrimeGenerator.RngBigPrimes(bits, cnt);

//    var t2 = sw.ElapsedMilliseconds;

//    sw = Stopwatch.StartNew();

//    bits = BitsPrime.Bit2048;
//    var (min, max) = BigPrimeGenerator.ToMinMaxFromBits((int)bits);
//    var result3 = BigPrimeGenerator.RngBigPrimes(min, max, cnt);

//    var t3 = sw.ElapsedMilliseconds;

//    var r = new[] { result1, result2, result3 };
//    var b = r.Select(x => BigInteger.Log2(x[0]) + 1).ToArray();
//    PrintOut("", cnt, b, [t1, t2, t3], result1, result2, result3);

//    Console.WriteLine($"{nameof(TestBigPrimeGeneratorUI32768)}-Async\n");

//    sw = Stopwatch.StartNew();

//    digits = 100;
//    using var aresult1 = BigPrimeGenerator.RngBigPrimesAsync(digits, cnt);
//    result1 = aresult1.Result;

//    t1 = sw.ElapsedMilliseconds;

//    sw = Stopwatch.StartNew();

//    bits = BitsPrime.Bit1024;
//    using var aresult2 = BigPrimeGenerator.RngBigPrimesAsync(bits, cnt);
//    result2 = aresult2.Result;

//    t2 = sw.ElapsedMilliseconds;

//    sw = Stopwatch.StartNew();

//    using var aresult3 = BigPrimeGenerator.RngBigPrimesAsync(min, max, cnt);
//    result3 = aresult3.Result;

//    t3 = sw.ElapsedMilliseconds;

//    r = [aresult1.Result, aresult2.Result, aresult3.Result];
//    b = r.Select(x => BigInteger.Log2(x[0]) + 1).ToArray();
//    PrintOut("", cnt, b, [t1, t2, t3], aresult1, aresult2, aresult3);
//  }

//  private static void PrintOut<T>(
//    string titel, int cnt, BigInteger[] bits, long[] times, params T[][] input)
//    where T : INumber<T>
//  {

//    if (!string.IsNullOrEmpty(titel))
//      Console.WriteLine(titel);
//    foreach (var x in input)
//    {
//      Array.ForEach(x, y => Console.WriteLine(string.Join(" ", y)));
//      Console.WriteLine();
//    }
//    Console.WriteLine($"count = {cnt}; bits = {string.Join(" ",bits)}; times = {string.Join("  ", times)} ms");
//    Console.WriteLine();
//    Console.WriteLine();
//  }

//  private static void PrintOut<T>(
//    string titel, int cnt, BigInteger[] bits, long[] times, params Task<T[]>[] input)
//    where T : INumber<T>
//  {
//    var ts = input.Select(x => x.Result).ToArray();
//    PrintOut(titel, cnt, bits, times, ts);
//  }
//}



//internal class Randomholder
//{
//  public readonly static RandomNumberGenerator Rand = RandomNumberGenerator.Create();

//  public static ulong RngUlong(ulong min, ulong max)
//  {
//    if (min > max)
//      throw new ArgumentOutOfRangeException(
//        nameof(min), $"{nameof(min)} may not be greater than {nameof(max)}");

//    if (min == max) return min;
//    var sz = sizeof(ulong);
//    var bytes = new byte[sz];
//    Rand.GetNonZeroBytes(bytes);
//    var scale = bytes[0] | ((ulong)bytes[1] << 8) | ((ulong)bytes[2] << 16) | ((ulong)bytes[3] << 24) |
//                ((ulong)bytes[4] << 32) | ((ulong)bytes[5] << 40) | ((ulong)bytes[6] << 48) | ((ulong)bytes[7] << 56);
//    return (ulong)(min + (max - min) * (scale / (double)(ulong.MaxValue + 1.0)));
//  }
//}
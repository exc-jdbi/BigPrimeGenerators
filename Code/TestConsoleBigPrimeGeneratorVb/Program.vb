'Copyright(c) update 2024 the exc-jdbi
'All rights reserved, see license.
'https://github.com/exc-jdbi/BigPrimeGenerators

Option Strict On
Option Explicit On


Imports System.Numerics
Imports System.Security.Cryptography
Imports exc.jdbi.VeryBigPrimes.Generators

Namespace exc.jdbi.VeryBigPrimes.Generators.Test

  Public Module Program

    Public Sub Main()
      TestPrimeGenerator(10)
      TestBigPrimeGenerator(3)


      Console.WriteLine()
      Console.WriteLine("Finish")
      Console.ReadLine()

    End Sub

    Private Sub TestPrimeGenerator(cnt As Int32)
      TestPrimeGeneratorUI64(cnt)
    End Sub

    Private Sub TestPrimeGeneratorUI64(cnt As Int32)
      Console.WriteLine($"{NameOf(TestPrimeGeneratorUI64)}")

      Dim sw = Stopwatch.StartNew()
      Dim result1 = BigPrimeGenerator.RngPrimes(cnt)
      Dim t1 = sw.ElapsedMilliseconds

      sw = Stopwatch.StartNew()
      Dim result2 = BigPrimeGenerator.RngPrimes(15UL, 1000UL, cnt)
      Dim t2 = sw.ElapsedMilliseconds

      sw = Stopwatch.StartNew()
      Dim result3 = BigPrimeGenerator.RngPrimes(UInt64.MinValue, UInt64.MaxValue, cnt)
      Dim t3 = sw.ElapsedMilliseconds

      Dim r = {result1, result2, result3}
      Dim b = r.[Select](Function(x) Convert.ToUInt64(Math.Log2(x(0)) + 1.0)).ToArray()
      PrintOut("", cnt, b, {t1, t2, t3}, result1, result2, result3)

      Console.WriteLine($"{NameOf(TestPrimeGeneratorUI64)}-Async")

      sw = Stopwatch.StartNew()
      Dim aresult1 = BigPrimeGenerator.RngPrimesAsync(cnt)
      t1 = sw.ElapsedMilliseconds

      sw = Stopwatch.StartNew()
      Dim aresult2 = BigPrimeGenerator.RngPrimesAsync(15UL, 1000UL, cnt)
      t2 = sw.ElapsedMilliseconds

      sw = Stopwatch.StartNew()
      Dim aresult3 = BigPrimeGenerator.RngPrimesAsync(UInt64.MinValue, UInt64.MaxValue, cnt)
      t3 = sw.ElapsedMilliseconds

      r = {aresult1.Result, aresult2.Result, aresult3.Result}
      b = r.[Select](Function(x) Convert.ToUInt64(Math.Log2(x(0)) + 1.0)).ToArray()
      PrintOut("", cnt, b, {t1, t2, t3}, aresult1, aresult2, aresult3)
    End Sub

    Private Sub TestBigPrimeGenerator(cnt As Int32)
      TestBigPrimeGeneratorUI256(2 * cnt)
      TestBigPrimeGeneratorUI32768(cnt)
    End Sub

    Private Sub TestBigPrimeGeneratorUI256(cnt As Int32)
      'BigPrimeGenerator berechnet alles was kleiner oder gleich wie 
      '2^256 ist wird in einer separaten Klasse berechnet, damit es
      'schneller geht. 

      Console.WriteLine($"{NameOf(TestBigPrimeGeneratorUI256)}")

      Dim digits = (BigInteger.One << 256).ToString().Length - 1

      Dim sw = Stopwatch.StartNew()

      Dim result1 = BigPrimeGenerator.RngBigPrimes(digits, cnt)

      Dim t1 = sw.ElapsedMilliseconds
      sw = Stopwatch.StartNew()
      Dim bits = BitsPrime.Bit128
      Dim result2 = BigPrimeGenerator.RngBigPrimes(bits, cnt)

      Dim t2 = sw.ElapsedMilliseconds

      sw = Stopwatch.StartNew()
      Dim min = BigInteger.One << 20
      Dim max = BigInteger.One << 256 - 1 'Ist noch im 256 bit bereich
      Dim result3 = BigPrimeGenerator.RngBigPrimes(min, max, cnt)
      Dim t3 = sw.ElapsedMilliseconds

      Dim r = {result1, result2, result3}
      Dim b = r.[Select](Function(x) BigInteger.Log2(x(0)) + 1).ToArray()
      PrintOut("", cnt, b, {t1, t2, t3}, result1, result2, result3)


      Console.WriteLine($"{NameOf(TestBigPrimeGeneratorUI256)}-Async")

      sw = Stopwatch.StartNew()
      Dim aresult1 = BigPrimeGenerator.RngBigPrimesAsync(digits, cnt)
      t1 = sw.ElapsedMilliseconds

      sw = Stopwatch.StartNew()
      bits = BitsPrime.Bit256
      Dim aresult2 = BigPrimeGenerator.RngBigPrimesAsync(bits, cnt)
      t2 = sw.ElapsedMilliseconds

      sw = Stopwatch.StartNew()
      Dim aresult3 = BigPrimeGenerator.RngBigPrimesAsync(min, max, cnt)
      t3 = sw.ElapsedMilliseconds

      r = {aresult1.Result, aresult2.Result, aresult3.Result}
      b = r.[Select](Function(x) BigInteger.Log2(x(0)) + 1).ToArray()
      PrintOut("", cnt, b, {t1, t2, t3}, aresult1, aresult2, aresult3)

    End Sub

    Private Sub TestBigPrimeGeneratorUI32768(cnt As Int32)
      'Grosse Primzahlen (> 2^256) werden anders berechnet, damit
      'die ganze Berechnung schneller ablauft.

      Console.WriteLine($"{NameOf(TestBigPrimeGeneratorUI32768)}")

      Dim digits = (BigInteger.One << 256).ToString().Length + 1
      Dim sw = Stopwatch.StartNew()

      Dim result1 = BigPrimeGenerator.RngBigPrimes(digits, cnt)
      Dim t1 = sw.ElapsedMilliseconds

      sw = Stopwatch.StartNew()
      Dim bits = BitsPrime.Bit1024
      Dim result2 = BigPrimeGenerator.RngBigPrimes(bits, cnt)
      Dim t2 = sw.ElapsedMilliseconds

      sw = Stopwatch.StartNew()
      bits = BitsPrime.Bit2048
      Dim minmax = BigPrimeGenerator.ToMinMaxFromBits(Convert.ToInt32(bits))
      Dim result3 = BigPrimeGenerator.RngBigPrimes(minmax.Min, minmax.Max, cnt)
      Dim t3 = sw.ElapsedMilliseconds

      Dim r = {result1, result2, result3}
      Dim b = r.[Select](Function(x) BigInteger.Log2(x(0)) + 1).ToArray()
      PrintOut("", cnt, b, {t1, t2, t3}, result1, result2, result3)

      Console.WriteLine($"{NameOf(TestBigPrimeGeneratorUI32768)}-Async")

      sw = Stopwatch.StartNew()

      digits = 100
      Dim aresult1 = BigPrimeGenerator.RngBigPrimesAsync(digits, cnt)
      result1 = aresult1.Result
      t1 = sw.ElapsedMilliseconds

      sw = Stopwatch.StartNew()
      bits = BitsPrime.Bit1024
      Dim aresult2 = BigPrimeGenerator.RngBigPrimesAsync(bits, cnt)
      result2 = aresult2.Result
      t2 = sw.ElapsedMilliseconds

      sw = Stopwatch.StartNew()
      Dim aresult3 = BigPrimeGenerator.RngBigPrimesAsync(minmax.Min, minmax.Max, cnt)
      result3 = aresult3.Result
      t3 = sw.ElapsedMilliseconds

      r = {aresult1.Result, aresult2.Result, aresult3.Result}
      b = r.[Select](Function(x) BigInteger.Log2(x(0)) + 1).ToArray()
      PrintOut("", cnt, b, {t1, t2, t3}, aresult1, aresult2, aresult3)
    End Sub

    Private Sub PrintOut(Of T As INumber(Of T))(titel As String, cnt As Int32, bits As T(), times As Int64(), ParamArray input As T()())

      If Not String.IsNullOrEmpty(titel) Then Console.WriteLine(titel)
      For Each x In input
        Array.ForEach(x, Sub(y) Console.WriteLine(String.Join(" ", y)))
        Console.WriteLine()
      Next
      Console.WriteLine($"count = {cnt}; bits = {String.Join(" ", bits)}; times = {String.Join("  ", times)} ms")
      Console.WriteLine()
      Console.WriteLine()
    End Sub

    Private Sub PrintOut(Of T As INumber(Of T))(titel As String, cnt As Int32, bits As T(), times As Int64(), ParamArray input As Task(Of T())())
      Dim ts = input.[Select](Function(x) x.Result).ToArray()
      PrintOut(titel, cnt, bits, times, ts)
    End Sub
  End Module


  Friend Class Randomholder
    Public Shared ReadOnly Rand As RandomNumberGenerator = RandomNumberGenerator.Create()

    Public Shared Function RngUlong(min As UInt64, max As UInt64) As UInt64
      If min > max Then Throw New ArgumentOutOfRangeException(NameOf(min), $"{NameOf(min)} may not be greater than {NameOf(max)}")

      If min = max Then Return min
      Dim bytes = New Byte(8 - 1) {}
      Rand.GetNonZeroBytes(bytes)
      Dim scale = bytes(0) Or CULng(bytes(1)) << 8 Or CULng(bytes(2)) << 16 Or CULng(bytes(3)) << 24 Or CULng(bytes(4)) << 32 Or CULng(bytes(5)) << 40 Or CULng(bytes(6)) << 48 Or CULng(bytes(7)) << 56
      Return Convert.ToUInt64(min + (max - min) * (scale / (UInt64.MaxValue + 1.0)))
    End Function
  End Class
End Namespace

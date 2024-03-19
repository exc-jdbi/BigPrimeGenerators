//Copyright(c) update 2024 the exc-jdbi
//All rights reserved, see license.
//https://github.com/exc-jdbi/BigPrimeGenerators



using System.Drawing;
using System.Numerics;


namespace exc.jdbi.VeryBigPrimes.Generators;

internal partial class BigPrimeGeneratorInternal
{
  public static ulong[] RngPrimes(ulong min, ulong max, int size) =>
    RngPrimesAsync(min, max, size).Result;

  public static BigInteger[] RngBigPrimes(BigInteger min, BigInteger max, int size) =>
    RngBigPrimesAsync(min, max, size).Result;

  public async static Task<ulong[]> RngPrimesAsync(ulong min, ulong max, int size) =>
    await BigPrimeGenerator64.StartAsync(min, max, size);

  public async static Task<BigInteger[]> RngBigPrimesAsync(
    BigInteger min, BigInteger max, int size)
  {
    var bits = BigInteger.Log2(max) + 1;
    if (bits <= 256)
      return await BigPrimeGenerator256.StartAsync(min, max, size);
    return await RngBigPrimeCollectionAsync(min, max, size);
  }

  private async static Task<BigInteger[]> RngBigPrimeCollectionAsync(BigInteger min, BigInteger max, int size)
  {
    var given = new List<int>(); //Hier nur die Instanz.
    var template = new List<int>() { 1, 2, 3, 4 };

    var tasks = new List<Task<BigInteger>>(size);
    var optimized = OptimizedProcedure(given, template, 0, 0, size).Last().ToArray();

    for (var i = 0; i < optimized.Length; i++)
    {
      for (var j = 0; j < optimized[i].Value; j++)
      {
        switch (optimized[i].Key.Key)
        {
          case 1: tasks.AddRange(RngBigPrime1Collection(min, max)); break;
          case 2: tasks.AddRange(RngBigPrime2Collection(min, max)); break;
          case 3: tasks.AddRange(RngBigPrime3Collection(min, max)); break;
          case 4: tasks.AddRange(RngBigPrime4Collection(min, max)); break;
        }
      }
    }
    if (tasks.Count == size)
    {
      var result = await Task.WhenAll(tasks);
      await DisposeAllTaskAsync(tasks);
      return result;
    }

    throw new NotImplementedException(nameof(RngBigPrimeCollectionAsync));
  }

  private static Task<BigInteger>[] RngBigPrime4Collection(BigInteger min, BigInteger max)
  {
    var tasks = new Task<BigInteger>[4];
    tasks[0] = Task.Run(() => BigPrimeGeneratorEulerN2N41.StartSingleAsync(min, max));
    tasks[1] = Task.Run(() => BigPrimeGenerator2n2796n79003.StartSingleAsync(min, max));
    tasks[2] = Task.Run(() => BigPrimeGenerator30X16.StartSingleAsync(min, max));
    tasks[3] = Task.Run(() => BigPrimeGeneratorEulerN2N41.StartSingleAsync(min, max));
    return tasks;
  }

  private static Task<BigInteger>[] RngBigPrime3Collection(BigInteger min, BigInteger max)
  {
    var tasks = new Task<BigInteger>[3];
    tasks[0] = Task.Run(() => BigPrimeGeneratorEulerN2N41.StartSingleAsync(min, max));
    tasks[1] = Task.Run(() => BigPrimeGenerator2n2796n79003.StartSingleAsync(min, max));
    tasks[2] = Task.Run(() => BigPrimeGenerator30X16.StartSingleAsync(min, max));
    return tasks;
  }

  private  static Task<BigInteger>[] RngBigPrime2Collection(BigInteger min, BigInteger max)
  {
    var tasks = new Task<BigInteger>[2];
    tasks[0] = Task.Run(() => BigPrimeGeneratorEulerN2N41.StartSingleAsync(min, max));
    tasks[1] = Task.Run(() => BigPrimeGenerator2n2796n79003.StartSingleAsync(min, max));
    return tasks;
  }

  private  static Task<BigInteger>[] RngBigPrime1Collection(BigInteger min, BigInteger max)
  {
    var tasks = new Task<BigInteger>[1];
    tasks[0] = Task.Run(() => BigPrimeGeneratorEulerN2N41.StartSingleAsync(min, max)); 
    return tasks;
  }

  private static IEnumerable<Dictionary<IGrouping<int, int>, int>> OptimizedProcedure(
    IEnumerable<int> coins, IEnumerable<int> template, int highest, int sum, int target)
  {
    if (sum == target)
      yield return coins 
            .GroupBy(x => x) 
            .ToDictionary(k => k, v => v.Count());
    if (sum > target) yield break;
    foreach (var value in template)
      if (value >= highest)
      {
        var newcoints = new List<int>(coins) { value };
        foreach (var result in OptimizedProcedure(newcoints, template, value, sum + value, target))
          yield return result;
      }
  }


  //private static (BigInteger Min, BigInteger Max) ToMinMaxFromBits(int bits)
  //{
  //  var _max = (BigInteger.One << bits) - 1;        // 10 bit --> 1111111111 = 1023
  //  var _min = (BigInteger.One << (bits - 1)) + 1;  // 10 bit --> 1000000000 = 512
  //  return (_min, _max);
  //}

  //private static (BigInteger Min, BigInteger Max) ToMinMaxFromDigits(int digits)
  //{
  //  var _min = "1" + new string('0', digits - 1);
  //  var _max = new string('9', digits);
  //  return (BigInteger.Parse(_min), BigInteger.Parse(_max));
  //}

  private async static Task DisposeAllTaskAsync(IEnumerable< Task> tasks)
  {
    try
    {
      var t = tasks.ToArray(); 
      await Task.WhenAll(t);
      Array.ForEach(t, x => x.Dispose());
      t = [];
    }
    catch (OperationCanceledException) { }
    catch (Exception) { }
  }
}

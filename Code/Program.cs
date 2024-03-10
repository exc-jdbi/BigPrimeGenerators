



namespace exc.jdbi.VeryBigPrimes.Generators;


public class Program
{
  public static void Main()
  {
    //A naive variant that is already very fast.
    //BigPrimeGenerator.Start();

    //Optimized variant of 'BigPrimeGenerator'
    //BigPrimeGeneratorFor.Start(); //Not BAD

    //A typical school variant that is already very fast.
    //BigPrimeShiftLeft.Start();

    //The fastest variant I know of so far.
    BigPrimeUlam2n2796n79003.Start(); //Not BAD

    Console.Write("Wait ... ");
    Console.WriteLine("for the MessageBox and Click 'Ok'!");
    Console.WriteLine("After MessageBox Press 'Enter'!");
    Console.ReadLine();


    Console.WriteLine("Finish");
  }
}
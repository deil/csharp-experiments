using System;
using System.Threading;
using System.Globalization;

namespace csharpexperiments
{

  class MainClass
  {
    
    public const short X = 0, Y = 0;

    public static void A() {
      byte a, b, c;
      a = 255;
      b = 122;
      c = (byte)(a & b);
      Console.WriteLine(c);
    }

    public static void Main (string[] args)
    {
      CultureInfo objCulture = new CultureInfo("");
      int [][]q = {new int[2], new int[2]};
      A();
	  Console.WriteLine ("Hello World!");

      try
      {
      	//Generics.Experiment();
      	//VolatileSingletonTest.Experiment();
        Finalization.Experiment();
      
        //new ResetEventTest<AutoResetEvent>().Test(new AutoResetEvent(false));
        //new ResetEventTest<ManualResetEvent>().Test(new ManualResetEvent(false));
        //new ThreadGateway().Test();
      	Console.ReadKey ();
      }
      catch (Exception ex)
      {
      	Console.WriteLine(ex.ToString ());
      	Console.ReadKey();
      }

      Console.WriteLine("Bye");
    }
  }
}
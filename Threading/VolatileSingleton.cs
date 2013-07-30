using System;
using System.Threading;
using System.Collections.Generic;

namespace csharpexperiments
{
	public class VolatileSingleton
	{
		public static VolatileSingleton Instance 
		{
			get
			{
				if (instance == null)
				{
					lock (syncObject)
					{
						if (instance == null)
						{
							instance = new VolatileSingleton();
						}
					}
				}

				return instance;
			}
		}

		private VolatileSingleton ()
		{
			Console.WriteLine("VolatileSingleton constructor");
		}

		private volatile static VolatileSingleton instance;
		private static object syncObject = new object();
	}

	public class VolatileSingletonTest
	{
        int foo;

        public static void Experiment()
        {
            var test = new VolatileSingletonTest();

            new Thread(delegate () 
            {
                Thread.Sleep(5000);
                test.foo = 255; 
            }).Start();

            while (test.foo != 255) ;

            Console.WriteLine("OK");
        }
    }
}


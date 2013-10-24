using System;
using System.Threading;

namespace deilycode
{
	public class Entry
	{
		public static void Main(string[] args)
		{
			Console.WriteLine ("Hello world!");
			Console.WriteLine ("Application thread Id = {0}", Thread.CurrentThread.ManagedThreadId);

            CLR.VirtualMemberCall.Entry.Main ();

			Console.ReadKey();
		}
	}
}

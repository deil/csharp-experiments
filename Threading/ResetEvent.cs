using System;
using System.Threading;
using System.Collections.Generic;

namespace csharpexperiments
{
  public class ResetEventTest<T> where T : EventWaitHandle
  {
    public void Test(T resetEvent)
    {
      _resetEvent = resetEvent;

      _thread1 = new Thread(Work);
      _thread2 = new Thread(Work);
      _isRunning = true;
      _thread1.Start();
      _thread2.Start();

      Console.WriteLine(string.Format("[{0}] signalling resetEvent", Thread.CurrentThread.ManagedThreadId));
      _resetEvent.Set();

      Thread.Sleep(3000);

      _isRunning = false;
      _resetEvent.Set();

      _thread1.Join();
      _thread2.Join();
      Console.WriteLine("Finished");
    }

    private Thread _thread1;
    private Thread _thread2;
    private T _resetEvent;
    private volatile bool _isRunning = false;

    private void Work()
    {
      Console.WriteLine(string.Format("[{0}] thread started", Thread.CurrentThread.ManagedThreadId));
      while (_isRunning)
      {
        _resetEvent.WaitOne();
        Console.WriteLine(string.Format("[{0}] after resetEvent.WaitOne()", Thread.CurrentThread.ManagedThreadId));
        Thread.Sleep(500);
      }

      Console.WriteLine(string.Format("[{0}] finished", Thread.CurrentThread.ManagedThreadId));
    }
  }

  public class ThreadGateway
  {
    public void Test()
    {
      Console.WriteLine("Main thread. Starting children");

      var threads = new List<Thread>();
      for (var i = 0; i < 5; i++)
      {
        var thread = new Thread(x => Routine());
        thread.Start();
      }

      Console.WriteLine("Main thread. Sleeping for 1 second");
      Thread.Sleep(1000);
      Console.WriteLine("Main thread. Signalling");
      resetEvent.Set();

      threads.ForEach(t => t.Join());
    }

    private readonly ManualResetEvent resetEvent = new ManualResetEvent(false);

    private void Routine()
    {
      Console.WriteLine("Thread {0} started", Thread.CurrentThread.ManagedThreadId);
      Console.WriteLine("Thread {0} - before WaitOne()", Thread.CurrentThread.ManagedThreadId);
      resetEvent.WaitOne();
      Console.WriteLine("Thread {0} resumed", Thread.CurrentThread.ManagedThreadId);
    }
  }

}


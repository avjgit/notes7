// http://www.robmiles.com/c-yellow-book/ 5.4 Threads and Threading

using System;
using System.Threading;

class Threading
{
    static private void busyLoop()
    {
        Console.WriteLine(DateTime.Now);
        long count;
        for (count = 0; count < 10000000000; count++)
        {
        }
    }
    static void Main()
    {
        // Threading.busyLoop();
        ThreadStart busyLoopMethod = new ThreadStart(busyLoop);
        Thread t1 = new Thread(busyLoopMethod);
        t1.Start();
        busyLoop();

        Console.ReadLine();
    }
}
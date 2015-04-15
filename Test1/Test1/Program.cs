using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test1
{
    class Program
    {
        static void Main(string[] args)
        {
            var threadName = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine("Main Thread [{0}]: ", threadName);


            var t1 = SleepingMethod1(500);
            var t2 = SleepingMethod2(1000);

            //for(int j = 0; j < 10; j++)
            //{
            //    Console.WriteLine("Main is counting: {0}", j.ToString());
            //}

            Task.WaitAll(new[] { t1, t2 });

            Console.WriteLine("Completed");
            Console.ReadLine();
        }

        public static async Task SleepingMethod1(int interval)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Begin SleepingMethod1 - Thread [{0}]: counter = {1}", Thread.CurrentThread.ManagedThreadId, i.ToString());
                await Task.Delay(interval);
                Console.WriteLine("End SleepingMethod1 - Thread [{0}]: counter = {1}", Thread.CurrentThread.ManagedThreadId, i.ToString());
            }
        }

        public static async Task SleepingMethod2(int interval)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Begin SleepingMethod2 - Thread [{0}]: counter = {1}", Thread.CurrentThread.ManagedThreadId, i.ToString());
                await Task.Delay(interval);
                Console.WriteLine("End SleepingMethod2 - Thread [{0}]: counter = {1}", Thread.CurrentThread.ManagedThreadId, i.ToString());
            }
        }
    }
}

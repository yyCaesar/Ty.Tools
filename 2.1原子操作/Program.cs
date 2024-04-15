using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2._1原子操作
{
    class Program
    {
        /// <summary>
        /// 原子操作:在某个时刻，必须只有一个线程能够进行某个操作。
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //NotInterlocked();
            //WithInterlocked();
            AtomicTest();

            Console.ReadLine();
        }

        static void AtomicTest()
        {
            Thread t1 = new Thread(AddOne);
            Thread t2 = new Thread(AddOne);
            Thread t3 = new Thread(AddOne);

            t1.Start();
            t2.Start();
            t3.Start();

            t1.Join();
            t2.Join();
            t3.Join();

            Console.WriteLine($"sum:{_sum}");
        }

        private static int _sum = 0;
        static void AddOne()
        {
            for (int i = 0; i < 1000000; i++)
            {
                //_sum++;
                Interlocked.Increment(ref _sum);
            }
        }


        static void WithInterlocked()
        {
            CounterWithInterlocked withInterlocked = new CounterWithInterlocked();

            Thread t1 = new Thread(() => { TestCounter(withInterlocked); });
            Thread t2 = new Thread(() => { TestCounter(withInterlocked); });
            Thread t3 = new Thread(() => { TestCounter(withInterlocked); });

            t1.Start();
            t2.Start();
            t3.Start();

            t1.Join();
            t2.Join();
            t3.Join();

            Console.WriteLine($"有原子操作的count值为：{withInterlocked.Count}");
        }

        static void NotInterlocked()
        {
            CounterNotInterlocked notInterlocked = new CounterNotInterlocked();

            Thread t1 = new Thread(() => { TestCounter(notInterlocked); });
            Thread t2 = new Thread(() => { TestCounter(notInterlocked); });
            Thread t3 = new Thread(() => { TestCounter(notInterlocked); });

            t1.Start();
            t2.Start();
            t3.Start();

            t1.Join();
            t2.Join();
            t3.Join();

            Console.WriteLine($"无原子操作的count值为：{notInterlocked.Count}");

        }

        static void TestCounter(CounterBase counter)
        {
            for (int i = 0; i < 100000; i++)
            {
                counter.Increase();
                counter.Decrease();
            }
        }
    }
}

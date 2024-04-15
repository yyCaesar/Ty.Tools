using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _1._1线程基础使用.lock关键字
{
    public static class LockMain
    {
        #region Lock关键字

        public static void Case_Lock()
        {
            CounterNoLock noLock = new CounterNoLock();
            Thread t1 = new Thread(() => { Counter(noLock); });
            Thread t2 = new Thread(() => { Counter(noLock); });
            Thread t3 = new Thread(() => { Counter(noLock); });
            Thread t4 = new Thread(() => { Counter(noLock); });

            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();

            t1.Join();
            t2.Join();
            t3.Join();
            t4.Join();

            Console.WriteLine($"没有锁的结果：{noLock.Count}");

            CounterWithLock withLock = new CounterWithLock();
            Thread t11 = new Thread(() => { Counter(withLock); });
            Thread t12 = new Thread(() => { Counter(withLock); });
            Thread t13 = new Thread(() => { Counter(withLock); });
            Thread t14 = new Thread(() => { Counter(withLock); });

            t11.Start();
            t12.Start();
            t13.Start();
            t14.Start();

            t11.Join();
            t12.Join();
            t13.Join();
            t14.Join();

            Console.WriteLine($"有锁的结果：{withLock.Count}");
        }

        private static void Counter(CounterBase counter)
        {
            for (int i = 0; i < 100000; i++)
            {
                counter.Increase();
                counter.Decrease();
            }
        }

        #endregion
    }
}

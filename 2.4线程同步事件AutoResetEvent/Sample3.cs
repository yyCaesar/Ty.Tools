/*-----------------------------
 * CLR版本：4.0.30319.42000
 * 机器名称：DESKTOP-5GI1QON
 * 唯一标识：79227698-d961-45aa-8dfa-7c1207759eac
 * 当前用户域：DESKTOP-5GI1QON
 * 创建者：huapu.zhang
 * 创建时间：2024-03-06 14:03:46
 * 版本：V1.0.0
 *-----------------------------*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2._4线程同步事件AutoResetEvent
{
    /// <summary>
    /// 两个线程分别打印奇偶数
    /// </summary>
    public static class Sample3
    {

        static int i = 0;
        static AutoResetEvent oddResetEvent = new AutoResetEvent(false);
        static AutoResetEvent evenResetEvent = new AutoResetEvent(false);

        public static void Run()
        {
            Thread thread1 = new Thread(new ThreadStart(show));
            thread1.Name = "偶数线程";
            Thread thread2 = new Thread(new ThreadStart(show));
            thread2.Name = "奇数线程";
            thread1.Start();
            Thread.Sleep(2); //保证偶数线程先运行。
            thread2.Start();
            Console.Read();

        }


        public static void show()
        {
            while (i <= 100)
            {
                int num = i % 2;

                if (num == 0)
                {
                    Console.WriteLine("{0}:{1} {2}  ", Thread.CurrentThread.Name, i++, "evenResetEvent");

                    if (i != 1)
                    {
                        evenResetEvent.Set();
                    }
                    oddResetEvent.WaitOne(); //当前线程阻塞

                }
                else
                {
                    Console.WriteLine("{0}:{1} {2} ", Thread.CurrentThread.Name, i++, "oddResetEvent");
                    //如果此时AutoResetEvent 为非终止状态，则线程会被阻止，并等待当前控制资源的线程通过调用 Set 来通知资源可用。否则不会被阻止
                    oddResetEvent.Set();
                    evenResetEvent.WaitOne();
                }
            }
        }

    }
}

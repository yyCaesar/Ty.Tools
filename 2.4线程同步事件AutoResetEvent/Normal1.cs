/*-----------------------------
 * CLR版本：4.0.30319.42000
 * 机器名称：DESKTOP-5GI1QON
 * 唯一标识：7a7677ea-1181-45e8-b15b-080101711aca
 * 当前用户域：DESKTOP-5GI1QON
 * 创建者：huapu.zhang
 * 创建时间：2024-03-06 11:24:02
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
    /// 正常情况1
    /// </summary>
    public static class Normal1
    {


        static int num = 0;
        static AutoResetEvent event1 = new AutoResetEvent(false);
        static AutoResetEvent event2 = new AutoResetEvent(false);


        public static void Run()
        {
            Thread t1 = new Thread(() => Print());
            Thread t2 = new Thread(() => Print());


            t1.Start();
            Thread.Sleep(10);
            t2.Start();
        }


        private static void Print()
        {
            while (num < 500)
            {
                if (num % 2 == 0)
                {

                    Console.WriteLine($"偶数线程：{num++}");
                    if (num != 1) { event2.Set(); }

                    event1.WaitOne();

                }
                else
                {
                    Console.WriteLine($"奇数线程：{num++}");

                    event1.Set();
                    event2.WaitOne();

                }
            }
        }

    }
}

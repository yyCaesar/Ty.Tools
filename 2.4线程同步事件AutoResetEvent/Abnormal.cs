/*-----------------------------
 * CLR版本：4.0.30319.42000
 * 机器名称：DESKTOP-5GI1QON
 * 唯一标识：7a2055a0-c766-4995-a527-fc8852611f45
 * 当前用户域：DESKTOP-5GI1QON
 * 创建者：huapu.zhang
 * 创建时间：2024-03-06 11:07:42
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
    /// 异常情况
    /// </summary>
    public static class Abnormal
    {

        private static int num = 0;
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
                }
                else
                {
                    Console.WriteLine($"奇数线程：{num++}");
                }
            }
        }

    }
}

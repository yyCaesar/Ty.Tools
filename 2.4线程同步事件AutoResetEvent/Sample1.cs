/*-----------------------------
 * CLR版本：4.0.30319.42000
 * 机器名称：DESKTOP-5GI1QON
 * 唯一标识：f2c62392-1bb9-47d9-b61b-84c7d71da12e
 * 当前用户域：DESKTOP-5GI1QON
 * 创建者：huapu.zhang
 * 创建时间：2024-03-06 11:34:30
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
    /// 两个线程分别读写
    /// </summary>
    public static class Sample1
    {

        private static AutoResetEvent autoResetEvent = new AutoResetEvent(false);
        private static int _number = -1;


        public static void Run()
        {

            Thread t1 = new Thread(() => ReadProc());
            Thread t2 = new Thread(() => WriteProc());

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();
        }

        private static void WriteProc()
        {
            for (int i = 0; i < 100; i++)
            {
                _number = i;
                Console.WriteLine($"write线程写入数据:{_number}");
                autoResetEvent.Set();
                Thread.Sleep(100);
            }


        }

        private static void ReadProc()
        {
            //读等待写线程
            while (true)
            {
                autoResetEvent.WaitOne();
                Console.WriteLine($"read线程读取数据：{_number}");
            }




        }


    }
}

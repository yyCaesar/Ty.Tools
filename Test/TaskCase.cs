/*-----------------------------
 * CLR版本：4.0.30319.42000
 * 机器名称：DESKTOP-5GI1QON
 * 唯一标识：b4d28c59-b35a-4360-8d10-800b2670a23b
 * 当前用户域：DESKTOP-5GI1QON
 * 创建者：huapu.zhang
 * 创建时间：2024-03-04 14:01:28
 * 版本：V1.0.0
 *-----------------------------*/


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class TaskCase
    {

        public void Run()
        {
            ThreadParallelAndWait();
        }

        /// <summary>
        /// 线程串行
        /// </summary>
        public async Task ThreadSerial()
        {
            Stopwatch sp = Stopwatch.StartNew();

            var t1 = Task.Run(() =>
            {
                Console.WriteLine("1、开始注册");
                Task.Delay(1000).Wait();
                Console.WriteLine("1、完成注册");
            });
            t1.Wait();


            var t2 = Task.Run(() =>
            {
                Console.WriteLine("2.开始执行任务");
                Task.Delay(1000).Wait();
                Console.WriteLine("2.执行完成");
            });
            t2.Wait();


            var t3 = Task.Run(() =>
            {
                Console.WriteLine("3.开始执行任务");
                Task.Delay(1000).Wait();
                Console.WriteLine("3.执行完成");
            });
            t3.Wait();

            var t4 = Task.Run(() =>
            {
                Console.WriteLine("4.开始执行任务");
                Task.Delay(1000).Wait();
                Console.WriteLine("4.执行完成");
            });
            t4.Wait();

            sp.Stop();
            Console.WriteLine($"所有任务均完成，耗时：{sp.Elapsed}秒");
        }


        /// <summary>
        /// 线程并行且等待
        /// </summary>
        /// <returns></returns>
        public async Task ThreadParallelAndWait()
        {
            Stopwatch sp = Stopwatch.StartNew();

            var t1 = Task.Run(() =>
            {
                Console.WriteLine("1、开始注册");
                Task.Delay(1000).Wait();
                Console.WriteLine("1、完成注册");
            });


            var t2 = Task.Run(() =>
            {
                Console.WriteLine("2.开始执行任务");
                Task.Delay(1000).Wait();
                Console.WriteLine("2.执行完成");
            });

            var t3 = Task.Run(() =>
            {
                Console.WriteLine("3.开始执行任务");
                Task.Delay(1000).Wait();
                Console.WriteLine("3.执行完成");
            });

            var t4 = Task.Run(() =>
            {
                Console.WriteLine("4.开始执行任务");
                Task.Delay(1000).Wait();
                Console.WriteLine("4.执行完成");
            });

            Task.WaitAll(t1, t2, t3, t4);

            sp.Stop();
            Console.WriteLine($"所有任务均完成，耗时：{sp.Elapsed}秒");
        }

    }
}

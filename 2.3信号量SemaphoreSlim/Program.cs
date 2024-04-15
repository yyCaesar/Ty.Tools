using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2._3信号量SemaphoreSlim
{
    internal class Program
    {
        /// <summary>
        /// 线程锁使一块代码只能一个线程访问。
        /// SemaphoreSlim则是让同一块代码多个线程同时访问，且总数量可控。
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //Demo1();
            Demo2();

            Console.ReadLine();
        }


        /// <summary>
        /// 餐厅一次只能接待2位，但是有15个人在排队
        /// </summary>
        static void Demo2()
        {

            SemaphoreSlim semaphoreSlim = new SemaphoreSlim(2);

            for (int i = 0; i < 15; i++)
            {
                int num = i;
                Task.Run(async () =>
                {

                    Console.WriteLine($"{num}等待位置。。。");
                    await Task.Delay(1000);

                    semaphoreSlim.Wait();

                    Console.WriteLine($"{num}入座吃饭。。。");
                    await Task.Delay(1000);

                    Console.WriteLine($"{num}已吃完饭离开。。。");
                    semaphoreSlim.Release();



                });
            }




        }


        /// <summary>
        /// 一次只能同时下载3个文件，但是有10个文件等待下载
        /// </summary>
        static void Demo1()
        {

            SemaphoreSlim semaphoreSlim = new SemaphoreSlim(3);

            for (int i = 0; i < 10; i++)
            {
                int num = i;

                Task.Run(async () =>
                {
                    semaphoreSlim.Wait();
                    Console.WriteLine($"开始下载{num}号文件，请等候。。。");


                    var time = new Random().Next(1000, 5000);
                    await Task.Delay(time);

                    Console.WriteLine($"{num}号文件，下载完成。。。");
                    semaphoreSlim.Release();
                });
            }




        }

    }
}

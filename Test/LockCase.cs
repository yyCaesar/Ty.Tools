/*-----------------------------
 * CLR版本：4.0.30319.42000
 * 机器名称：DESKTOP-5GI1QON
 * 唯一标识：9634105e-2609-4782-bf68-6bb17d8c2db7
 * 当前用户域：DESKTOP-5GI1QON
 * 创建者：huapu.zhang
 * 创建时间：2024-03-04 15:37:24
 * 版本：V1.0.0
 *-----------------------------*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class LockCase
    {
        private static readonly object LockObj = new object();
        private List<string> strings = new List<string>();

        public void Run()
        {
            MonitorTest();
        }




        public void MonitorTest()
        {
            for (int i = 0; i < 4; i++)
            {
                new Thread(MonitorAdd).Start();
            }

            Console.ReadKey();

            foreach (var item in strings)
            {
                Console.WriteLine(item);
            }
        }

        public void MonitorAdd()
        {
            //Monitor.Enter(LockObj);
            //try
            //{
            //    strings.Add(DateTime.Now.ToString());
            //    Thread.Sleep(1000);
            //}
            //finally
            //{
            //    Monitor.Exit(LockObj);
            //}

            strings.Add(DateTime.Now.ToString());
            Thread.Sleep(1000);
        }

        public void LockAdd()
        {
            lock (LockObj)
            {
                strings.Add(DateTime.Now.ToString());
                Thread.Sleep(1000);
            }
        }

        public void Test()
        {
            Person p1 = new Person { Id = 24, Name = "Kobe" };
            Person p2 = new Person { Id = 25, Name = "Rose" };
            Person p3 = new Person { Id = 23, Name = "Lebl" };

            //开启多线程、模拟三个人同时发起多次领取请求
            for (int i = 0; i < 4; i++)
            {
                //new Thread(() =>
                //{
                //    LockGetCoupon(p1);
                //}).Start();
                //new Thread(() =>
                //{
                //    LockGetCoupon(p2);
                //}).Start();
                //new Thread(() =>
                //{
                //    LockGetCoupon(p3);
                //}).Start();

                var t1 = Task.Run(() =>
                   {
                       MutexGetCoupon(p1);
                   });


                var t2 = Task.Run(() =>
                {
                    MutexGetCoupon(p2);
                });


                var t3 = Task.Run(() =>
                {
                    MutexGetCoupon(p3);
                });

                //t1.Wait();
                //t2.Wait();
                //t3.Wait();

                //Task.WaitAll(t1, t2, t3);
            }

        }


        public void MutexGetCoupon(Person person)
        {
            Console.WriteLine($"date:{DateTime.Now},name:{person.Name},前来领取优惠券");

            using (var mutex = new Mutex(false, person.Id.ToString()))
            {
                try
                {
                    if (mutex.WaitOne(-1, false))
                    {
                        //判断是否已经领取
                        if (person.IsGetCoupon)
                        {
                            //假装业务处理
                            Thread.Sleep(1000);
                            Console.WriteLine($"date:{DateTime.Now},name:{person.Name},已经领取，不可重复领取");
                        }
                        else
                        {

                            //假装业务处理
                            Thread.Sleep(1000);
                            //领取
                            person.IsGetCoupon = true;
                            Console.WriteLine($"date:{DateTime.Now},name:{person.Name},领取成功");
                        }
                    }
                }
                catch (Exception ex)
                {
                    //TxtLogHelper.WriteLog(ex);
                }
                finally
                {
                    mutex.ReleaseMutex();
                }
            }
        }


        public void LockGetCoupon(Person person)
        {
            Console.WriteLine($"date:{DateTime.Now},name:{person.Name},前来领取优惠券");

            lock (LockObj)
            {
                if (person.IsGetCoupon)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine($"date:{DateTime.Now},name:{person.Name},已经领取，不可重复领取");
                }
                else
                {
                    //假装业务处理
                    Thread.Sleep(1000);
                    //领取
                    person.IsGetCoupon = true;
                    Console.WriteLine($"date:{DateTime.Now},name:{person.Name},领取成功");
                }
            }
        }

        /// <summary>
        /// 获取优惠券
        /// </summary>
        public void GetCoupon(Person person)
        {
            Console.WriteLine($"date:{DateTime.Now},name:{person.Name},前来领取优惠券");

            if (person.IsGetCoupon)
            {
                Thread.Sleep(1000);
                Console.WriteLine($"date:{DateTime.Now},name:{person.Name},已经领取，不可重复领取");
            }
            else
            {
                //假装业务处理
                Thread.Sleep(1000);
                //领取
                person.IsGetCoupon = true;
                Console.WriteLine($"date:{DateTime.Now},name:{person.Name},领取成功");
            }
        }


    }


    /// <summary>
    /// Person类
    /// </summary>
    public class Person
    {
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///  姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 是否获得优惠券
        /// </summary>
        public bool IsGetCoupon { get; set; }
    }
}

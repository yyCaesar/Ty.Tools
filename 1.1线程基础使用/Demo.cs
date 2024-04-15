using _1._1线程基础使用.lock关键字;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _1._1线程基础使用
{
    public static class Demo
    {

        public static void Run()
        {
        }





        #region 通过TPL使用线程池

        /// <summary>
        /// 泛型的Task类
        /// </summary>
        static void TestCase05()
        {
            Task.Factory.StartNew(Case05);
        }


        static void Case05()
        {
            Console.WriteLine("Hello from the thread pool!");
        }

        #endregion


        #region 异常处理
        static void TestCase04_False()
        {
            try
            {
                new Thread(Test04_False).Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception");
            }
        }


        static void Test04_False()
        {
            throw null;
        }


        static void TestCase04_True()
        {
            new Thread(Test04_True).Start();
        }

        static void Test04_True()
        {
            try
            {
                throw null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        #endregion


        #region Lambda 表达式与被捕获变量

        static void TestCase03()
        {
            ////变量i在整个循环中指向相同的内存地址
            //for (int i = 0; i < 10; i++)
            //{
            //    new Thread(() => Console.Write(i)).Start();
            //}


            //解决方法就是使用临时变量
            for (int i = 0; i < 10; i++)
            {
                int temp = i;

                new Thread(() => Console.Write(temp)).Start();
            }

        }

        #endregion




        #region 向线程传递数据

        public static void TestCase02()
        {

            Thread t = new Thread(() =>
            {
                Print("new message");

            });

            t.Start();

        }

        private static void Print(string message)
        {
            Console.WriteLine(message);
        }

        #endregion

        #region 线程安全问题

        private static bool done;
        private static readonly object obj = new object();

        /// <summary>
        /// 局部变量
        /// CLR 为每个线程分配各自独立的栈空间，因此局部变量是独立的。
        /// </summary>
        public static void TestCase01()
        {
            new Thread(Go).Start();      // 在新线程执行Go()

            Go();                         // 在主线程执行Go()
        }


        private static void Go()
        {
            //确保了在同一时刻只有一个线程能进入临界区（critical section，不允许并发执行的代码）
            lock (obj)
            {
                // 定义和使用局部变量 - 'cycles'
                if (!done)
                {
                    done = true;
                    Console.WriteLine("Done");

                }
            }
        }

        #endregion
    }
}

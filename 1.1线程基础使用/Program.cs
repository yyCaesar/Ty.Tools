using _1._1线程基础使用.lock关键字;
using _1._1线程基础使用.Monitor类锁定资源;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _1._1线程基础使用
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Basics();
            //LockMain.Case_Lock();
            //MonitorMain.Case_MonitorNotLock();
            MonitorMain.Case_MonitorWithLock();
            //MonitorMain.Case_MonitorWithMonitor();
            //Demo.Run();





            Console.ReadLine();
        }


        static void Basics()
        {
            Thread t = new Thread(Common.PrintNumbers);
            t.Start();

            Console.WriteLine($"Name:{t.Name},IsBackground:{t.IsBackground}");
            Console.WriteLine($"ThreadId:{t.ManagedThreadId},线程启动，状态为：{t.ThreadState},IsAlive:{t.IsAlive}");
            Thread.Sleep(1000);
            Console.WriteLine($"ThreadId:{t.ManagedThreadId},线程挂起，状态为：{t.ThreadState}IsAlive:{t.IsAlive}");
            t.Abort("Information from Main.");
            Thread.Sleep(1000);
            Console.WriteLine($"ThreadId:{t.ManagedThreadId},线程终止，状态为：{t.ThreadState}IsAlive:{t.IsAlive}");
            t.Join();
            Console.WriteLine($"ThreadId:{t.ManagedThreadId},阻止调用线程，状态为：{t.ThreadState}IsAlive:{t.IsAlive}");
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _1._1线程基础使用.Monitor类锁定资源
{
    public static class MonitorMain
    {

        public static void Case_MonitorNotLock()
        {
            Monster monster = new Monster(1000);
            Player wukong = new Player("悟空", 100);
            Player bajie = new Player("八戒", 50);

            Thread t1 = new Thread(() => { wukong.Attack(monster); });

            Thread t2 = new Thread(() => { bajie.Attack(monster); });

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();
        }

        public static void Case_MonitorWithLock()
        {
            Monster monster = new Monster(1000);
            PlayerWithLock wukong = new PlayerWithLock("悟空", 10);
            PlayerWithLock bajie = new PlayerWithLock("八戒", 5);

            Thread t1 = new Thread(() => { wukong.Attack(monster); });

            Thread t2 = new Thread(() => { bajie.Attack(monster); });

            t2.Start();
            t1.Start();

            t1.Join();
            t2.Join();
        }


        public static void Case_MonitorWithMonitor()
        {
            Monster monster = new Monster(1000);
            PlayerWithMonitor wukong = new PlayerWithMonitor("悟空", 10);
            PlayerWithMonitor bajie = new PlayerWithMonitor("八戒", 5);

            Thread t1 = new Thread(() => { wukong.Attack(monster); });

            Thread t2 = new Thread(() => { bajie.Attack(monster); });

            t1.Start();
            t2.Start();
      

            t1.Join();
            t2.Join();
        }
    }
}

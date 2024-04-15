using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2._2使用Mutex类
{
    class Program
    {
 

        static void Main(string[] args)
        {

            Mutex mutex = new Mutex(true, "{3FBAF085-7234-4A10-8E20-F0E8235D0B43}",out bool createdNew);

            if (createdNew)
            {
                Console.WriteLine("首次启动");
            }
            else
            {
                Console.WriteLine("二次启动");
                return;
            }

            Console.ReadLine();
        }
    }
}

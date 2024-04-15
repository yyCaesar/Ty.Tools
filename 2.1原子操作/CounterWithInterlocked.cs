using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2._1原子操作
{
    public class CounterWithInterlocked : CounterBase
    {
        /*
         * Interlocked类为多线程共享的变量提供原子操作。
         * 使用Interlocked类，可以在不阻塞线程(lock、Monitor)的情况下，避免竞争条件。
         * **/

        private int _count;

        public int Count { get { return _count; } }

        public override void Decrease()
        {
            Interlocked.Decrement(ref _count);
        }

        public override void Increase()
        {
            Interlocked.Increment(ref _count);
        }
    }
}

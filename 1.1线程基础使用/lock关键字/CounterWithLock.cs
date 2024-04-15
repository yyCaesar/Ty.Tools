using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1线程基础使用.lock关键字
{
    public class CounterWithLock : CounterBase
    {
        public int Count { get; private set; }

        private readonly object _lockObj = new object();

        public override void Decrease()
        {
            lock (_lockObj)
            {
                Count--;
            }
        }

        public override void Increase()
        {
            lock (_lockObj)
            {
                Count++;
            }
        }
    }
}

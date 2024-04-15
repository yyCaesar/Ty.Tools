using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1线程基础使用.lock关键字
{
    public class CounterNoLock : CounterBase
    {

        public int Count { get; private set; }

        public override void Decrease()
        {
            Count--;
        }

        public override void Increase()
        {
            Count++;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1原子操作
{
    public class CounterNotInterlocked : CounterBase
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

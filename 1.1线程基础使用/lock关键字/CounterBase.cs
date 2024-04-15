using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1线程基础使用.lock关键字
{
    public abstract class CounterBase
    {
        public abstract void Increase();
        public abstract void Decrease();
    }
}

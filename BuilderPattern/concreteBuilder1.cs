/*-----------------------------
 * CLR版本：4.0.30319.42000
 * 机器名称：DESKTOP-5GI1QON
 * 唯一标识：b4f6b458-3a85-4888-a814-8b5026013513
 * 当前用户域：DESKTOP-5GI1QON
 * 创建者：huapu.zhang
 * 创建时间：2024-03-14 16:20:25
 * 版本：V1.0.0
 *-----------------------------*/


using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    public class concreteBuilder1 : Builder
    {
        public override void BuildAnyThing()
        {
            Console.WriteLine("组装Intel 其他配件");
        }

        public override void BuildPartBoard()
        {
            Console.WriteLine("组装Intel Board");
        }

        public override void BuildPartCPU()
        {
            Console.WriteLine("组装Intel CPU");
        }

        public override Computer GetComputer()
        {
            return new Computer();
        }
    }
}

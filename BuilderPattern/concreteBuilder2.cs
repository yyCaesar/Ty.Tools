/*-----------------------------
 * CLR版本：4.0.30319.42000
 * 机器名称：DESKTOP-5GI1QON
 * 唯一标识：92f779d2-d3dc-4fef-b690-d4287b54ce01
 * 当前用户域：DESKTOP-5GI1QON
 * 创建者：huapu.zhang
 * 创建时间：2024-03-14 16:22:18
 * 版本：V1.0.0
 *-----------------------------*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    public class concreteBuilder2 : Builder
    {
        public override void BuildAnyThing()
        {
            Console.WriteLine("组装联想 其他配件");
        }

        public override void BuildPartBoard()
        {
            Console.WriteLine("组装联想 Board");
        }

        public override void BuildPartCPU()
        {
            Console.WriteLine("组装联想 CPU");
        }

        public override Computer GetComputer()
        {
            return new Computer();
        }


    }
}

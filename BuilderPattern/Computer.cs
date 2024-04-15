/*-----------------------------
 * CLR版本：4.0.30319.42000
 * 机器名称：DESKTOP-5GI1QON
 * 唯一标识：128c6471-8685-4ee2-8e2d-54f56096bcf5
 * 当前用户域：DESKTOP-5GI1QON
 * 创建者：huapu.zhang
 * 创建时间：2024-03-14 16:23:34
 * 版本：V1.0.0
 *-----------------------------*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    public class Computer
    {
        //电脑组件集合
        public IList<string> parts = new List<string>();

        //单个组件添加到电脑组件集合中
        public void Add(string part)
        {
            parts.Add(part);
        }

        public void Print()
        {
            Console.WriteLine("电脑组装中。。。");

            foreach (string part in parts)
            {
                Console.WriteLine("组件" + part + "已装好");
            }
            Console.WriteLine("电脑组装好了");
        }

    }
}

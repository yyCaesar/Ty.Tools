/*-----------------------------
 * CLR版本：4.0.30319.42000
 * 机器名称：DESKTOP-5GI1QON
 * 唯一标识：63fc1f10-1cf5-4356-bfaa-7d76c16a2862
 * 当前用户域：DESKTOP-5GI1QON
 * 创建者：huapu.zhang
 * 创建时间：2024-03-14 16:15:31
 * 版本：V1.0.0
 *-----------------------------*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    /// <summary>
    /// 抽象建造者
    /// </summary>
    public abstract class Builder
    {
        //组装成品电脑
        //cpu
        //主板
        //组装完成，得到成品电脑
        public abstract void BuildPartCPU();
        public abstract void BuildPartBoard();
        public abstract void BuildAnyThing();
        public abstract Computer GetComputer();
    }
}

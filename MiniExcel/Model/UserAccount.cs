/*-----------------------------
 * CLR版本：4.0.30319.42000
 * 机器名称：DESKTOP-5GI1QON
 * 唯一标识：195ed2c4-2398-4aba-95b0-b8484add4709
 * 当前用户域：DESKTOP-5GI1QON
 * 创建者：huapu.zhang
 * 创建时间：2024-02-18 11:34:00
 * 版本：V1.0.0
 *-----------------------------*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniExcelTest
{
    public class UserAccount
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public DateTime BoD { get; set; }
        public int Age { get; set; }
        public bool VIP { get; set; }
        public decimal Points { get; set; }
    }
}

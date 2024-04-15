/*-----------------------------
 * CLR版本：4.0.30319.42000
 * 机器名称：DESKTOP-5GI1QON
 * 唯一标识：aea75aaf-aab1-434d-9a64-9ee0cd8188dc
 * 当前用户域：DESKTOP-5GI1QON
 * 创建者：huapu.zhang
 * 创建时间：2024-03-27 19:16:45
 * 版本：V1.0.0
 *-----------------------------*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern
{
    public class Demo1
    {
        public static void DemoMain()
        {
            User landload = new User("房东");
            User tenant = new User("租客");

            Mediator mediator = new Mediator();
            mediator.Trade(1000, landload, tenant);
        }
    }

    class User
    {
        public string Name { get; set; }
        public int Amount { get; set; }

        public User(string name)
        {
            Name = name;
        }
    }

    class Mediator
    {
        public void Trade(int amount, User user1, User user2)
        {
            user1.Amount += amount;
            user2.Amount -= amount;

            Console.WriteLine($"{user1.Name}增加了{amount}元，剩余{user1.Amount}元");
            Console.WriteLine($"{user2.Name}增加了{amount}元，剩余{user2.Amount}元");
        }
    }
}

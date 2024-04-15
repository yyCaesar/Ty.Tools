using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1线程基础使用.Monitor类锁定资源
{

    /// <summary>
    /// 怪兽类
    /// </summary>
    public class Monster
    {
        public int Blood { get; private set; }

        public Monster(int blood)
        {
            Blood = blood;
            Console.WriteLine($"我是怪兽，血量{Blood}滴");
        }


        /// <summary>
        /// 被袭击
        /// </summary>
        public void BeAttacked(int attack)
        {
            if (Blood > 0)
            {
                Blood = Blood - attack;

                if (Blood < 0)
                {
                    Blood = 0;
                }
            }

            Console.WriteLine($"我是怪兽，我剩余{Blood}滴血！");
        }

    }
}

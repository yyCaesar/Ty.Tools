using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1线程基础使用.Monitor类锁定资源
{
    /// <summary>
    /// 玩家类
    /// </summary>
    public class Player
    {

        public string Name { get; private set; }

        public int Atk { get; private set; }


        public Player(string name, int atk)
        {
            this.Name = name;
            this.Atk = atk;
        }


        public void Attack(Monster monster)
        {
            while (monster.Blood > 0)
            {
                Console.WriteLine($"我是{this.Name},我来打怪兽!");
                monster.BeAttacked(this.Atk);
            }

        }


    }
}

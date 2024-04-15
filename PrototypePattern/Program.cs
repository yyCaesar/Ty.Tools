using static PrototypePattern.Program;

namespace PrototypePattern
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Monkey wukong = new Monkey()
            {
                Name = "悟空",
                Weapon = "金箍棒",
                Skill = "七十二变",
                Attack = "金角大王"
            };


            Monkey NewMonkey = wukong;

            NewMonkey.Attack = "白骨精";


            Monkey CloneMonkey_01 = wukong.Clone() as Monkey;
            CloneMonkey_01.Attack = "牛魔王";

            Monkey CloneMonkey_02 = wukong.Clone() as Monkey;
            CloneMonkey_02.Attack = "六耳";


            wukong.Print();
            NewMonkey.Print();
            CloneMonkey_01.Print();
            CloneMonkey_02.Print();

            Console.ReadLine();
        }


        public class Monkey : ICloneable
        {
            public Monkey()
            {
                Console.WriteLine("进入构造函数内");
            }

            public string Name { get; set; }

            public string Weapon { get; set; }

            public string Skill { get; set; }

            public string Attack { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            public void Print()
            {
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(this));
            }


        }

    }
}

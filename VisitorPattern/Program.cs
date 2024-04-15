namespace VisitorPattern
{
    /// <summary>
    /// 访问者模式
    /// 意图：将数据结构与数据操作分离。
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Home home = new Home();
            home.Add(new Cat());
            home.Add(new Dog());

            Master master = new Master();
            Friend friend = new Friend();

            home.Print(master);
            Console.WriteLine("====================");
            home.Print(friend);

            Console.ReadLine();
        }
    }

    public class Home
    {
        private readonly List<IAnimal> animals = new List<IAnimal>();

        public void Add(IAnimal animal)
        {
            animals.Add(animal);
        }


        public void Print(IPerson person)
        {
            foreach (var animal in animals)
            {
                animal.Accept(person);
            }
        }

    }

    public class Friend : IPerson
    {
        public void Feed(Cat animal)
        {
            Console.WriteLine("朋友帮忙投喂猫");
        }

        public void Feed(Dog animal)
        {
            Console.WriteLine("朋友帮忙投喂狗");
        }
    }


    public class Master : IPerson
    {
        public void Feed(Cat animal)
        {
            Console.WriteLine("主人自己投喂猫");
        }

        public void Feed(Dog animal)
        {
            Console.WriteLine("主人自己投喂狗");
        }
    }

    public class Dog : IAnimal
    {
        public void Accept(IPerson person)
        {
            person.Feed(this);
            Console.WriteLine("狗吃饱了好看门");
        }
    }

    public class Cat : IAnimal
    {
        public void Accept(IPerson person)
        {
            person.Feed(this);
            Console.WriteLine("猫吃饱了好睡觉");
        }
    }

    public interface IAnimal
    {

        /// <summary>
        /// 接收投喂
        /// </summary>
        /// <param name="person"></param>
        void Accept(IPerson person);
    }

    public interface IPerson
    {
        /// <summary>
        /// 投喂给谁
        /// </summary>
        /// <param name="animal"></param>
        //void Feed(IAnimal animal);

        void Feed(Cat cat);
        void Feed(Dog dog);
    }
}

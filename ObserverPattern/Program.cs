using static System.Net.Mime.MediaTypeNames;

namespace ObserverPattern
{
    /// <summary>
    /// 观察者模式
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {

            Test3();


            Console.ReadLine();
        }


        static void Test4()
        {
            Cat cat = new Cat();
            cat.CatMiaoActionEvent += new Dog().Wang;
            cat.CatMiaoActionEvent += new Baby().Cry;
            cat.CatMiaoActionEvent += new Mom().Run;
            cat.MiaoDelegateHandler();
        }

        static void Test3()
        {
            Cat cat = new Cat();
            cat.catMiaoAction  += new Dog().Wang;
            cat.catMiaoAction += new Baby().Cry;
            cat.catMiaoAction += new Mom().Run;

            cat.MiaoDelegate();
        }


        static void Test2()
        {
            Cat cat = new Cat();
            cat.AddObserver(new Dog());
            cat.AddObserver(new Baby());
            cat.AddObserver(new Mom());
            cat.MiaoObserver();
        }

        static void Test1()
        {
            Cat cat = new Cat();
            cat.Miao();
        }
    }


    public class Cat
    {
        private IList<IObject> objectsList = new List<IObject>();

        public void AddObserver(IObject obeserver)
        {
            objectsList.Add(obeserver);
        }


        public void MiaoObserver()
        {
            foreach (IObject item in objectsList)
            {
                item?.DoAction();
            }
        }


        public Action catMiaoAction;

        public void MiaoDelegate()
        {
            this.catMiaoAction?.Invoke();
        }


        public event Action CatMiaoActionEvent;

        public void MiaoDelegateHandler()
        {
            this.CatMiaoActionEvent.Invoke();
        }


        public void Miao()
        {
            Console.WriteLine("野猫叫。。。");
            new Dog().Wang();
            new Baby().Cry();
            new Mom().Run();
        }
    }

    public class Mom : IObject
    {
        public void DoAction()
        {
            this.Run();
        }

        public void Run()
        {
            Console.WriteLine("妈妈跑。。。。");
        }
    }

    public class Baby : IObject
    {
        public void DoAction()
        {
            this.Cry();
        }

        public void Cry()
        {
            Console.WriteLine("baby哭泣。。。");
        }
    }

    public class Dog : IObject
    {
        public void DoAction()
        {
            this.Wang();
        }

        public void Wang()
        {
            Console.WriteLine("狗叫。。。。");
        }
    }

    public interface IObject
    {
        void DoAction();
    }
}

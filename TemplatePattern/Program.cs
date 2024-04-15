namespace TemplatePattern
{
    /// <summary>
    /// 模板方法模式
    /// 在一个抽象类中定义一个操作中的算法骨架（对应于生活中的大家下载的模板），而将一些步骤延迟到子类中去实现（对应于我们根据自己的情况向模板填充内容）
    /// 优点：
    ///     1.实现了代码复用。
    ///     2.能够灵活应对子步骤的变化，
    /// 缺点：
    ///     因为引入了一个抽象类，如果实现过多的话，需要开发人员理清类之间的关系。
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {


            Vegetabel spinach = new Spinach();

            spinach.CookVegetabel();

            Console.WriteLine("==============");

            Vegetabel chineseCabbage = new ChineseCabbage();

            chineseCabbage.CookVegetabel();

            Console.ReadLine();

        }
    }


    /// <summary>
    /// 抽象模板角色：定义了一个或多个抽象操作，以便让子类实现，这些抽象操作称为基本操作
    /// 抽象方法，定义执行方法的方式/模板。
    /// </summary>
    public abstract class Vegetabel
    {
        //模板方法不能定义为abstract或virtual，避免被子类重写篡改，防止更改流程的执行顺序。

        public void CookVegetabel()
        {
            Console.WriteLine("抄蔬菜的一般做法");
            this.PourOil();
            this.HeatOil();
            this.PourVegetabel();
            this.StartFry();
        }

        public void PourOil()
        {
            Console.WriteLine("倒油润锅");
        }

        public void HeatOil()
        {
            Console.WriteLine("热锅凉油");
        }

        //倒入蔬菜
        public abstract void PourVegetabel();

        public void StartFry()
        {
            Console.WriteLine("翻炒加调料，准备出锅");
        }
    }

    /// <summary>
    /// 具体模板角色：实现父类所定义的一个或多个抽象方法。
    /// 菠菜子类，实现行为
    /// </summary>
    public class Spinach : Vegetabel
    {
        public override void PourVegetabel()
        {
            Console.WriteLine("倒菠菜进锅中");
        }
    }

    /// <summary>
    /// 具体模板角色：实现父类所定义的一个或多个抽象方法。
    /// 大白菜子类，实现行为
    /// </summary>
    public class ChineseCabbage : Vegetabel
    {
        public override void PourVegetabel()
        {
            Console.WriteLine("倒大白菜进锅中");
        }
    }
}
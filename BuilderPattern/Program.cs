namespace BuilderPattern
{
    /// <summary>
    /// 客户
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {

            Director director = new Director();

            Builder builder1 = new concreteBuilder1();
            Builder builder2 = new concreteBuilder2();


            director.Construct(builder1);
            Computer computer1 = builder1.GetComputer();
            computer1.Print();

            director.Construct(builder2);
            Computer computer2 = builder2.GetComputer();
            computer2.Print();


            Console.ReadLine();
        }
    }
}

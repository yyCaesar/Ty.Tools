namespace ChainOfResponsibilityPattern
{
    /// <summary>
    /// 责任链模式
    /// 目的：层层传递，层层处理。
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {

            ProcessContext context = new ProcessContext();

            ConcreteHandlerA employee = new ConcreteHandlerA();
            ConcreteHandlerB manager = new ConcreteHandlerB();
            ConcreteHandlerC boss = new ConcreteHandlerC();

            employee.Next = manager;
            manager.Next = boss;

            employee.Process(context);

            Console.ReadLine();
        }
    }


    /// <summary>
    /// 抽象处理者
    /// </summary>
    public abstract class Handler
    {
        /// <summary>
        /// 下个处理者
        /// </summary>
        public Handler Next { get; set; }

        /// <summary>
        /// 处理方法
        /// </summary>
        public abstract void Process(ProcessContext context);
    }

    /// <summary>
    /// 具体处理者
    /// </summary>

    public class ConcreteHandlerA : Handler
    {
        public override void Process(ProcessContext context)
        {
            context.Name = "班长";
            Console.WriteLine($"{context.Name}-流程A处理中。。。");
            Next?.Process(context);
        }
    }

    public class ConcreteHandlerB : Handler
    {
        public override void Process(ProcessContext context)
        {
            context.Name = "经理";
            Console.WriteLine($"{context.Name}-流程B处理中。。。");
            Next?.Process(context);
        }
    }

    public class ConcreteHandlerC : Handler
    {
        public override void Process(ProcessContext context)
        {
            context.Name = "老板";
            Console.WriteLine($"{context.Name}-流程C处理中。。。");
            Next?.Process(context);
        }
    }

    public class ProcessContext
    {
        public string Name { get; set; }
    }
}

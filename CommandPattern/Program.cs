namespace CommandPattern
{
    /// <summary>
    /// 命令模式
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// 客户端，院领导
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Receiver receiver = new Receiver();
            Command command = new ConcreteCommand(receiver);
            Invoke invoke = new Invoke(command);

            //领导发出命令
            invoke.ExecuteCommand();

            Console.ReadLine();
        }
    }


    /// <summary>
    /// 教官，负责调用命令对象执行请求
    /// </summary>
    public class Invoke
    {
        public Command _command;

        public Invoke(Command command)
        {
            _command = command;
        }

        public void ExecuteCommand()
        {
            this._command.Action();
        }
    }


    /// <summary>
    /// 命令抽象类
    /// </summary>
    public abstract class Command
    {
        //定义命令的接收者
        public Receiver _receiver;

        public Command(Receiver receiver)
        {
            this._receiver = receiver;
        }

        //命令执行方法
        public abstract void Action();
    }


    /// <summary>
    /// 具体命令角色
    /// </summary>
    public class ConcreteCommand : Command
    {
        public ConcreteCommand(Receiver receiver) : base(receiver)
        {
        }

        public override void Action()
        {
            this._receiver.Run();
        }
    }

    /// <summary>
    /// 命令接收者
    /// </summary>
    public class Receiver
    {
        public void Run()
        {
            Console.WriteLine("跑1000米");
        }
    }
}

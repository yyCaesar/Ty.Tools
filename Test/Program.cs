namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {




            //TaskCase taskCase = new TaskCase();
            //taskCase.Run();

            LockCase lockCase = new LockCase();
            lockCase.Run();

            Console.ReadKey();
        }


        static void TaskTest3()
        {
            var sheets = new List<Sheet> { new Sheet(), new Sheet() };
            var tasks = new Task[2];
            for (int i = 0; i < sheets.Count; i++)
            {
                tasks[i] = Task.Factory.StartNew((index) =>
                {
                    sheets[(int)index].WriteSheet(i);
                }, i);
            }
            Task.WhenAll(tasks).ContinueWith(t =>
            {
                new Sheet().WriteSheet(t.Id);
            }).Wait();
        }

        static void TaskTest2()
        {
            var task1 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("执行任务1");
            }).ContinueWith(t =>
            {
                Console.WriteLine("执行任务2");
            }).ContinueWith(t =>
            {
                Console.WriteLine("执行任务3");
            });
            task1.Wait();
        }


        static void TaskTest1()
        {
            //1.new方式实例化一个Task，需要通过Start方法启动
            Task task = new Task(() =>
            {
                Thread.Sleep(100);
                Console.WriteLine($"task1的线程ID为{Thread.CurrentThread.ManagedThreadId}");
            });
            task.Start();

            //2.Task.Factory.StartNew(Action action)创建和启动一个Task
            Task task2 = Task.Factory.StartNew(() =>
            {
                Thread.Sleep(100);
                Console.WriteLine($"task2的线程ID为{Thread.CurrentThread.ManagedThreadId}");
            });

            //3.Task.Run(Action action)将任务放在线程池队列，返回并启动一个Task
            Task task3 = Task.Run(() =>
            {
                Thread.Sleep(100);
                Console.WriteLine($"task3的线程ID为{Thread.CurrentThread.ManagedThreadId}");
            });

            Console.WriteLine("执行主线程！");
        }
    }

    public class Sheet
    {

        public void WriteSheet(int i)
        {
            Console.WriteLine($"sheet写入{i}");
        }
    }
}

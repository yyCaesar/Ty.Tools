namespace Classic150
{
    /// <summary>
    /// 经典150题
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            //new ArrayString().Run();
            AlternatePrinting();
            Console.ReadLine();

            if () { }
            else if()
            {
                 
            }

        }

        static int count = 0;
        static Mutex mutex = new Mutex();

        static void AlternatePrinting()
        {
            Thread t1 = new Thread(PrintEvenNumbers);
            Thread t2 = new Thread(PrintOddNumbers);
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
        }

        static void PrintOddNumbers()
        {
            while (count < 100)
            {
                mutex.WaitOne();
                if (count % 2 == 1)
                {
                    Console.WriteLine($"thread1：{count++}");
                }

                mutex.ReleaseMutex();
            }
        }

        static void PrintEvenNumbers()
        {
            while (count < 100)
            {
                mutex.WaitOne();

                if (count % 2 == 0)
                {
                    Console.WriteLine($"thread2：{count++}");
                }

                mutex.ReleaseMutex();
            }
        }
    }
}

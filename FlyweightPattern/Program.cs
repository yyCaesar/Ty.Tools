namespace FlyweightPattern
{
    /// <summary>
    /// 享元设计模式
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {

            //创建享元工厂对象
            BikeFactory bikeFactory = new BikeFactory();

            FlyweightBike flyweightBike = bikeFactory.GetBike();
            flyweightBike.Ride("张三");
            flyweightBike.Back("张三");


            //FlyweightBike flyweightBike2 = bikeFactory.GetBike();
            flyweightBike.Ride("李四");
            flyweightBike.Back("李四");


            //FlyweightBike flyweightBike3 = bikeFactory.GetBike();
            flyweightBike.Ride("王五");
            flyweightBike.Back("王五");


            Console.ReadLine();
        }
    }

    public abstract class FlyweightBike
    {
        //内部状态：BikeID、骑行状态
        //外部状态：用户、骑行、锁定

        public string BikeID { get; set; }

        public int State { get; set; }

        public abstract void Ride(string userName);

        public abstract void Back(string userName);
    }

    public class YellowBike : FlyweightBike
    {
        public YellowBike(string id)
        {
            this.BikeID = id;
        }

        public override void Back(string userName)
        {
            State = 0;
            Console.WriteLine($"用户{userName}正在已归还ID为{this.BikeID}的自行车");
        }

        public override void Ride(string userName)
        {
            State = 1;
            Console.WriteLine($"用户{userName}骑行ID为{this.BikeID}的自行车");
        }
    }

    public class BikeFactory
    {
        public List<FlyweightBike> bikePool = new List<FlyweightBike>();

        public BikeFactory()
        {

            for (int i = 0; i < 3; i++)
            {
                bikePool.Add(new YellowBike(i.ToString()));
            }

        }

        public FlyweightBike GetBike()
        {
            for (int i = 0; i < bikePool.Count; i++)
            {
                if (bikePool[i].State == 0)
                {
                    return bikePool[i];
                }
            }

            return null;
        }
    }

}

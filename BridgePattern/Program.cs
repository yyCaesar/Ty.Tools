namespace BridgePattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IColor white = new White();
            IColor black = new Black();
            IColor red = new Red();

            Car gasolineCar = new GasolineCar();
            Car electricCar = new ElectricCar();
            Car hybridCar = new HybridCar();

            gasolineCar.Move(white);
            electricCar.Move(red);
            hybridCar.Move(black);

            Console.ReadLine();
        }

    }


    public abstract class Car
    {
        public abstract void Move(IColor color);
    }


    public class GasolineCar : Car
    {
        public override void Move(IColor color)
        {
            Console.WriteLine($"{color.ShowColor()}颜色的汽油车在行驶");
        }
    }

    public class ElectricCar : Car
    {
        public override void Move(IColor color)
        {
            Console.WriteLine($"{color.ShowColor()}颜色的电动车在行驶");
        }
    }

    public class HybridCar : Car
    {
        public override void Move(IColor color)
        {
            Console.WriteLine($"{color.ShowColor()}颜色的混动车在行驶");
        }
    }



    public interface IColor
    {
        string ShowColor();
    }

    public class White : IColor
    {
        public string ShowColor()
        {
            return "白色";
        }
    }

    public class Black : IColor
    {
        public string ShowColor()
        {
            return "黑色";
        }
    }

    public class Red : IColor
    {
        public string ShowColor()
        {
            return "红色";
        }
    }

}

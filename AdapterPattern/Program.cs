namespace AdapterPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPhoneCharge phoneCharge = new PhoneChargeAdapter();

            phoneCharge.PhoneCharge();

            Console.ReadLine();
        }
    }

    /// <summary>
    /// 安卓充电线
    /// </summary>
    public class AndroidChargeAdaptee
    {
        public void AndroidCharge()
        {
            Console.WriteLine("安卓充电线");
        }
    }

    /// <summary>
    /// 苹果充电接口
    /// </summary>
    public interface IPhoneCharge
    {
        void PhoneCharge();
    }

    /// <summary>
    /// 转接口
    /// </summary>
    public class PhoneChargeAdapter : IPhoneCharge
    {
        AndroidChargeAdaptee androidChargeAdaptee = new AndroidChargeAdaptee();

        public void PhoneCharge()
        {
            androidChargeAdaptee.AndroidCharge();
        }
    }

}

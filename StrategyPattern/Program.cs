using Microsoft.Extensions.DependencyInjection;
using static System.Net.Mime.MediaTypeNames;

namespace StrategyPattern
{
    /// <summary>
    /// 策略模式
    /// 定义了一系列算法或策略，并将每个算法封装在独立的类中，使得他们可以互相替换。
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Test2();

            Console.ReadLine();
        }

        /// <summary>
        /// 手写依赖注入实现
        /// </summary>
        static void Test2()
        {
            var services = new ServiceCollection();
            services.AddScoped<IRepository, EFCoreRepository>();
            //services.AddScoped<IRepository, RedisRepository>();
            services.AddScoped<AppService>();

            var builder = services.BuildServiceProvider();
            var appService = builder.GetRequiredService<AppService>();
            appService.Create(null);

        }

        /// <summary>
        /// 手写实例化实现
        /// </summary>
        static void Test1()
        {
            //如果在需要的地方实例化的话，我们是控制不了代码的。
            IRepository ef = new EFCoreRepository();
            IRepository redis = new RedisRepository();

            var appService = new AppService(ef);
            appService.Create(null);

            appService = new AppService(redis);
            appService.Create(null);
        }
    }



    /// <summary>
    /// Service业务层
    /// </summary>
    public class AppService
    {

        private readonly IRepository _repository;

        //通过构造函数形式把该类型的仓储实例拉进来
        public AppService(IRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// 具体的功能
        /// </summary>
        /// <param name="entity"></param>
        public void Create(object entity)
        {
            _repository.Add(entity);
        }
    }


    /// <summary>
    /// EFCore仓储
    /// </summary>
    public class EFCoreRepository : IRepository
    {
        public void Add(object entity)
        {
            Console.WriteLine("EFCore 仓储");
        }
    }

    public class RedisRepository : IRepository
    {
        public void Add(object entity)
        {
            Console.WriteLine("Redis 仓储");
        }
    }


    /// <summary>
    /// 仓储接口
    /// </summary>
    public interface IRepository
    {
        void Add(object entity);
    }
}

namespace MementoPattern
{
    /// <summary>
    /// 备忘录模式
    /// 解释：保存一个对象的某个状态，以便在适当的时候恢复对象。
    /// 目的：保存历史记录，随时恢复。
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            History history = new History();

            User user = new User() { Name = "第一次提交记录" };
            history.Add(user.Save());

            user.Name = "commit：优化逻辑";
            history.Add(user.Save());

            user.Name = "第三次修改";
            history.Add(user.Save());

            Console.WriteLine($"获取第1次修改：{history.Get(0).User.Name}");
            Console.WriteLine($"获取第2次修改：{history.Get(1).User.Name}");
            Console.WriteLine($"获取第3次修改：{history.Get(2).User.Name}");

            Console.ReadLine();
        }
    }


    /// <summary>
    /// 发起人角色
    /// </summary>
    class User
    {
        public string Name { get; set; }

        public Momento Save()
        {
            return new Momento(new User() { Name = Name });
        }

        public User Restor(Momento momento)
        {
            return momento.User;
        }
    }

    /// <summary>
    /// 备忘录角色
    /// </summary>
    class Momento
    {
        public User User { get; set; }

        public Momento(User user)
        {
            User = user;
        }
    }


    /// <summary>
    /// 管理者角色
    /// </summary>
    class History
    {
        List<Momento> Moments { get; set; } = new();

        public void Add(Momento momento)
        {
            Moments.Add(momento);
        }

        public Momento Get(int version)
        {
            return Moments[version];
        }

    }
}

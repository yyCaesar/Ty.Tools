namespace CompositePattern
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Component company = new DepartComposite("公司");

            Component dept1 = new DepartComposite("部门1");

            Component dept2 = new DepartComposite("部门2");

            Component emp1 = new Employee("张三");
            Component emp2 = new Employee("李四");
            Component emp3 = new Employee("大哥大");

            company.Add(dept1);
            company.Add(dept2);
            dept1.Add(emp1);
            dept1.Add(emp2);
            dept2.Add(emp3);


            company.Display(3);

            Console.ReadLine();
        }



    }


    /// <summary>
    /// 抽象构件，定义子类公共成员
    /// </summary>
    public abstract class Component
    {
        public string Name { get; set; }

        public Component(string name)
        {
            this.Name = name;
        }

        public abstract void Add(Component component);
        public abstract void Remove(Component component);
        public abstract void Display(int depth);
    }

    /// <summary>
    /// 组合节点，部门树枝
    /// </summary>
    public class DepartComposite : Component
    {

        public List<Component> listComponent = new List<Component>();

        public DepartComposite(string name) : base(name) { }

        public override void Add(Component component)
        {
            listComponent.Add(component);
        }

        public override void Remove(Component component)
        {
            listComponent.Remove(component);
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + this.Name);

            foreach (Component component in listComponent)
            {
                component.Display(depth + 5);
            }
        }
    }

    /// <summary>
    /// 树叶构件，员工/树叶无法继续添加子集
    /// </summary>
    public class Employee : Component
    {
        public Employee(string name) : base(name) { }

        public override void Add(Component component)
        {
            throw new NotImplementedException();
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + this.Name);
        }

        public override void Remove(Component component)
        {
            throw new NotImplementedException();
        }
    }
}

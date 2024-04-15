/*-----------------------------
 * CLR版本：4.0.30319.42000
 * 机器名称：DESKTOP-5GI1QON
 * 唯一标识：d8965b5c-9152-493c-a5b8-457bfc704932
 * 当前用户域：DESKTOP-5GI1QON
 * 创建者：huapu.zhang
 * 创建时间：2024-03-27 19:12:09
 * 版本：V1.0.0
 *-----------------------------*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern
{
    public class Demo2
    {
        public static void DemoMain()
        {
            CustomerRoleService service = new CustomerRoleService();
            Customer customer = new Customer();
            Role role = new Role();
            service.AssignRole(customer, role);
        }


    }

    class Customer
    {

    }

    class Role
    {

    }

    class CustomerInRole
    {
        public Customer customer { get; set; }

        public Role role { get; set; }
    }

    class CustomerRoleService
    {

        public void AssignRole(Customer customer, Role role)
        {
            new CustomerInRole() { customer = customer, role = role };
        }

    }
}

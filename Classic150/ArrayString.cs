/*-----------------------------
 * CLR版本：4.0.30319.42000
 * 机器名称：DESKTOP-5GI1QON
 * 唯一标识：abffb91c-c5fa-4bac-b831-245899dfd263
 * 当前用户域：DESKTOP-5GI1QON
 * 创建者：huapu.zhang
 * 创建时间：2024-04-09 9:28:29
 * 版本：V1.0.0
 *-----------------------------*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classic150
{
    /// <summary>
    /// 数组字符串相关题目
    /// </summary>
    public class ArrayString
    {

        public void Run()
        {
            string str = "123";
            string[] strArr = { "1", "2" };
            Console.WriteLine(str);
            Console.WriteLine(strArr);
        }




        /// <summary>
        /// 合并两个有序数组
        /// </summary>
        public void _88()
        {

            int[] nums1 = { 1, 2, 3, 0, 0, 0 };
            int[] nums2 = { 2, 5, 6 };
            int m = 3, n = 3;
            int m1 = m - 1;
            int n1 = n - 1;
            int index = m + n - 1;


            while (m1 >= 0 && n1 >= 0)
            {
                if (nums1[m1] < nums2[n1])
                {
                    nums1[index--] = nums2[n1--];
                }
                else
                {
                    nums1[index--] = nums1[m1--];
                }
            }

            while (n1 >= 0)
            {
                nums1[index--] = nums2[n1--];
            }
        }

    }
}

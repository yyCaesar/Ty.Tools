/*-----------------------------
 * CLR版本：4.0.30319.42000
 * 机器名称：DESKTOP-5GI1QON
 * 唯一标识：704838af-4f8c-4d65-8126-68d3acdbccee
 * 当前用户域：DESKTOP-5GI1QON
 * 创建者：huapu.zhang
 * 创建时间：2024-04-10 11:38:01
 * 版本：V1.0.0
 *-----------------------------*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    public class BinarySearch
    {

        public void Run()
        {
            _744_NextGreatestLetter(null, 'f');
        }



        /// <summary>
        /// 搜索插入位置
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int _35_searchInsert(int[] nums, int target)
        {
            return 0;
        }

        /// <summary>
        /// 寻找比目标字母大的最小字母
        /// </summary>
        /// <param name="letters"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public char _744_NextGreatestLetter(char[] letters, char target)
        {
            letters = new char[] { 'a', 'a', 'c', 'd', 'e', 'f', 'f', 'g' };

            if (target >= letters[letters.Length - 1]) { return letters[0]; }

            int l = 0;
            int r = letters.Length - 1;
            int time = 0;

            while (l <= r)
            {
                int mid = ((r - l) >> 1) + l;

                Console.WriteLine($"第{++time}次,l={l},r={r},mid={mid},mid值={letters[mid]},target={target}");

                if (target >= letters[mid])
                {
                    l = mid + 1;
                }
                else
                {
                    r = mid - 1;
                }
            }

            Console.WriteLine($"返回值是：{letters[l]}");
            return letters[l];
        }

    }
}

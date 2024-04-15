using MiniExcelLibs;
using MiniExcelTest.Model;
using System;
using System.Linq;

namespace MiniExcelTest
{
    public class Function
    {
        static string path = $"{Environment.CurrentDirectory}\\miniExcelTest.csv";

        public void Test()
        {
            //SaveAs();

            //Inserts();

            Query();
        }

        void Query()
        {
            var rows1 = MiniExcel.Query<Users>(path);

            var rows2 = MiniExcel.Query(path).First();

            var rows3 = MiniExcel.Query(path, useHeaderRow: true).ToList();

        }

        void Inserts()
        {
            var value = new[] {
                  new { ID=4,Name ="Frank",InDate=new DateTime(2021,06,07)},
                  new { ID=5,Name ="Gloria",InDate=new DateTime(2022,05,03)},
            };

            MiniExcel.Insert(path, value);
        }

        void Insert()
        {
            var value = new { ID = 3, Name = "Mike", InDate = new DateTime(2021, 04, 23) };
            MiniExcel.Insert(path, value);

        }

        void SaveAs()
        {

            var value = new[] {
              new { ID=1,Name ="Jack",InDate=new DateTime(2021,01,03)},
              new { ID=2,Name ="Henry",InDate=new DateTime(2020,05,03)},
            };

            MiniExcel.SaveAs(path, value);

        }


    }
}

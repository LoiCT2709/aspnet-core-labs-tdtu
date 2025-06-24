using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phan1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Phần 1:Bài 1
            string[] countries = { "Korea", "Japan", "USA", "Jordan", "Jamaica", "China" };

            IEnumerable<string> result = from x in countries
                                         where x.StartsWith("J") && x.EndsWith("n")
                                         select x;
            Console.WriteLine("Danh sach cac quoc gia thoa man yeu cau la:");
            foreach (string s in result)
            {
                Console.WriteLine(s);
            
            }
            Console.ReadLine();
            //Bài 2:
            List<Student> objStudent = new List<Student>() {
                new Student() { Name = "Tom", Gender = "Male", Location = "NewYork" },
                new Student() { Name = "Alice", Gender = "Female", Location = "Hawai" },
                new Student() { Name = "Bob", Gender = "Male", Location = "NewYork" },
                new Student() { Name = "Onana", Gender = "Male", Location ="California"},
                new Student() { Name = "David", Gender = "Male", Location = "Arizona"},
                new Student() { Name = "Andrew", Gender = "Male",Location = "Hawai" }
            };

            //Xử lí nhóm dữ liệu theo location
            var groupedResult =
                                from s in objStudent
                                group s by s.Location into locationGroup
                                select locationGroup;

            foreach (var locationGroup in groupedResult)
            {
                foreach (Student s in locationGroup)
                {
                    Console.WriteLine($"{s.Name}  {locationGroup.Key}");
                }
            }

            Console.ReadLine();
        }
    }
}

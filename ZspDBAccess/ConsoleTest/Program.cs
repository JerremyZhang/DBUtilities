using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZSQL.DBAccess;
//using ZSQL.Common;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student { Name = "zhangsan", Address = "BeiJiing", Age = 43 , PostId="535454"};
            var r = DB.Insert(s, "");
            if (r.IsSuccess)
            {
                Console.WriteLine("插入成功");
                Console.WriteLine("sql语句" + r.SQLString);
            }
            //Console.WriteLine(r.SQLString);
            Console.Read();
        }
    }
    [ZTable("Student")]
    class Student
    {
        [ZColumn("Name")]
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string PostId { get; set; }
    }
}

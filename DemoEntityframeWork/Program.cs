using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace DemoEntityframeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            using (var context = new SchoolManagerDbContext())
            {
                var classTables = context.Set<Class>();
                var class1 = new Class
                {
                    Name = "Class 12A1",
                    Students = new Student[]
                    {
                     new Student
                     {
                         Name="Chicken"
                     }
                    }
                };

                classTables.Add(class1);
                context.SaveChanges();

                var students = context.Set<Student>().ToList();
            }
        }

        public class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public virtual Class Class { get; set; }
            public int ClassId { get; set; }
        }

        public class Class
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public virtual ICollection<Student> Students { get; set; }
        }
    }


}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeloManager.Models
{
    public static class ModelBuilderExtensions
    {
        public static Random random = new Random();

        public static void Seed(this ModelBuilder modelBuilder)
        {
            Employee[] empList = new Employee[10];
            for (int i = 1; i <= 10; i++)
            {
                empList[i - 1] =
                      new Employee
                      {
                          Id = i,
                          Name = RandomString(5),
                          Department = Dept.IT,
                          Email = $"{RandomString(3)}@{RandomString(4)}.com"
                      };
            }

            modelBuilder.Entity<Employee>().HasData(
                empList
            );
        }
        
        public static string RandomString(int length)
        {
            //Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}

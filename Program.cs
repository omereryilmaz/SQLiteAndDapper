using System;
using SQLiteAndDapper.Data;
using SQLiteAndDapper.Model;

namespace SQLiteAndDapper
{
    class Program
    {
        static void Main(string[] args)
        {
            IEmployeeRepository repo = new SqliteEmployeeRepository();

            var employee = new Employee
            {
                FirstName = "Ömer",
                LastName = "Eryılmaz",
                DateOfBirth = DateTime.Now
            };

            repo.SaveEmployee(employee);

            Employee retrievedEmp = repo.GetEmployee(employee.Id);
            Console.WriteLine(
                "FullName: " + retrievedEmp.FirstName + " " + retrievedEmp.LastName + "\n" +
                "Date Of Birth: " + retrievedEmp.DateOfBirth
            );
        }
    }
}

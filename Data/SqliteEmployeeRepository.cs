using System;
using System.IO;
using System.Linq;
using Dapper;
using SQLiteAndDapper.Model;

namespace SQLiteAndDapper.Data
{
  public class SqliteEmployeeRepository : SqliteBaseRepository, IEmployeeRepository
  {
    public Employee GetEmployee(long id)
    {
      if (!File.Exists(DbFile)) return null;

      using (var cnn = CompanyDbConnection())
      {
        cnn.Open();
        Employee result = cnn.Query<Employee>(
            @"SELECT Id, FirstName, LastName, DateOfBirth
                FROM Employee
                WHERE Id = @id", new { id }).FirstOrDefault();
        return result;
      }
    }

    public void SaveEmployee(Employee employee)
    {
      if (!File.Exists(DbFile))
      {
        //CreateDatabase();
      }

      using (var cnn = CompanyDbConnection())
      {
        cnn.Open();
        employee.Id = cnn.Query<long>(
            @"INSERT INTO Customer 
              ( FirstName, LastName, DateOfBirth ) VALUES 
              ( @FirstName, @LastName, @DateOfBirth );
              select last_insert_rowid()", employee).First();
      }
    }

    private static void CreateDatabase()
    {
      using (var cnn = CompanyDbConnection())
      {
        cnn.Open();
        cnn.Execute(
            @"create table Employee
                (
                  Id           integer identity primary key AUTOINCREMENT,
                  FirstName    varchar(100) not null,
                  LastName     varchar(100) not null,
                  DateOfBirth  datetime not null
                )");
      }
    }
  }
}
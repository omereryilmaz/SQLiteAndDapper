using System;
using System.IO;
using System.Linq;
using Dapper;
using SQLiteAndDapper.Model;

namespace SQLiteAndDapper.Data
{
  public class SqliteEmployeeRepository : SqliteBaseRepository, IEmployeeRepository
  {
    public Employee GetEmployee(int id)
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
        CreateDatabase();
      }

      using (var cnn = CompanyDbConnection())
      {
        cnn.Open();
        employee.Id = cnn.Query<int>(
            @"INSERT INTO Employee 
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

        var createTableCmd = cnn.CreateCommand();
        createTableCmd.CommandText = @"
          create table Employee
          (
            Id           INTEGER PRIMARY KEY AUTOINCREMENT,
            FirstName    VARCHAR(100) NOT NULL,
            LastName     VARCHAR(100) NOT NULL,
            DateOfBirth  DATETIME NOT NULL
          )";
                
        createTableCmd.ExecuteNonQuery();
      }
    }
  }
}
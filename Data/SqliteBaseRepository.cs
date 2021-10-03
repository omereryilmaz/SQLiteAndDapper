using System;
using Microsoft.Data.Sqlite;

namespace SQLiteAndDapper.Data
{
  public class SqliteBaseRepository
  {
    public static string DbFile
    {
      get { return Environment.CurrentDirectory + "\\CompanyDb.sqlite";}
    }

    public static SqliteConnection CompanyDbConnection()
    {
      return new SqliteConnection("Data Source=" + DbFile);
    }
  }
}
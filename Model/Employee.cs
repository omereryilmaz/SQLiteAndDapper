using System;

namespace SQLiteAndDapper.Model
{
  public class Employee
  {
    public string Id { get; set; }
    public string FirstName { get; set; } 
    public string LastName { get; set; } 
    public DateTime DateOfBirth { get; set; }  
  }
}
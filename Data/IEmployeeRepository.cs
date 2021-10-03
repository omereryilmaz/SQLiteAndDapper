using SQLiteAndDapper.Model;

namespace SQLiteAndDapper.Data
{
  public interface IEmployeeRepository
  {
    Employee GetEmployee (long id);
    void SaveEmployee(Employee employee);    
  }
}
using SQLiteAndDapper.Model;

namespace SQLiteAndDapper.Data
{
  public interface IEmployeeRepository
  {
    Employee GetEmployee (int id);
    void SaveEmployee(Employee employee);    
  }
}
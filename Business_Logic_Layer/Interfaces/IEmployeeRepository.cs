using Entity_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Interfaces
{
    public interface IEmployeeRepository
    {
        Employee AddEmployee<T>(T entity) where T : Employee;
        void DeleteEmployee(int id);
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployeeById(int id);
        void UpdateEmployeeById(Employee employee);
    }
}

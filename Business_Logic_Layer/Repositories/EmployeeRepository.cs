using Business_Logic_Layer.Interfaces;
using Data_Access_Layer;
using Entity_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _context;
        public EmployeeRepository(EmployeeDbContext context)
        {
            _context = context;
        }
        Employee IEmployeeRepository.AddEmployee<T>(T entity)
        {
            Employee employee = new Employee();
            employee.First_Name = entity.First_Name;
            employee.Middle_Name = entity.Middle_Name;
            employee.Last_Name = entity.Last_Name;

            _context.Employee.Add(employee);
            _context.SaveChanges();
            return employee;
        }
        public void DeleteEmployee(int id)
        {
            var finded_employee = _context.Employee.Find(id);
            _context.Employee.Remove(finded_employee);
            _context.SaveChanges();
        }

        public Employee GetEmployeeById(int id)
        {
            var employee = _context.Employee.Find(id);
            return employee;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            var employees = _context.Employee.ToList();
            return employees;
        }

        public void UpdateEmployeeById(Employee employee)
        {
            var customer_old = _context.Employee.Find(employee.Id);
            var cust = _context.Employee.Where(x => x.Id == employee.Id);
            customer_old.First_Name = employee.First_Name;
            customer_old.Middle_Name = employee.Middle_Name;
            customer_old.Last_Name = employee.Last_Name;
            _context.SaveChanges();
        }
    }
}

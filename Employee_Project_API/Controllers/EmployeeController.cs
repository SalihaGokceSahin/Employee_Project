using Business_Logic_Layer.Interfaces;
using Business_Logic_Layer.Repositories;
using Entity_Layer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Project_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        private IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            _employeeRepository.AddEmployee(employee);
            return Ok(employee);
        }
        [HttpDelete]
        public IActionResult DeleteEmployee(int id)
        {
            _employeeRepository.DeleteEmployee(id);
            return Ok();
        }
        [HttpGet("~/getEmployee")]
        public IActionResult GetEmployeeById(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);
            return Ok(employee);
        }
        [HttpGet("~/getEmployees")]
        public IActionResult GetEmployees()
        {
            var allEmployees = _employeeRepository.GetEmployees();
            return Ok(allEmployees);
        }
        [HttpPut]
        public IActionResult UpdateEmployeeById(Employee employee)
        {
            _employeeRepository.UpdateEmployeeById(employee);
            return Ok();

        }
    }
}

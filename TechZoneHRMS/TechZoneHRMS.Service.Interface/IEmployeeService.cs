using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechZoneHRMS.API.Models;

namespace TechZoneHRMS.Service.Interface
{
    public interface IEmployeeService
    {
        Task<ActionResult<IEnumerable<Employee>>> GetEmployees();
        Task<ActionResult<Employee>> GetEmployeeById(int id);
        Task<IActionResult> EditEmployee(int id, Employee employee);
        Task<ActionResult<Employee>> CreateEmployee(Employee employee);
        Task<IActionResult> DeleteEmployee(int id);
    }
}

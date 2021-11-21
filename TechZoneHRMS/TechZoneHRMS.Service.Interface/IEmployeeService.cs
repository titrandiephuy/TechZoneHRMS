using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechZoneHRMS.API.Models;
using TechZoneHRMS.Domain.Models.Employee;
using TechZoneHRMS.Domain.Response;

namespace TechZoneHRMS.Service.Interface
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDetail>> GetEmployees();
        Task<ActionResult<EmployeeDetail>> GetEmployeeById(int id);
        Task<IActionResult> EditEmployee(int id, EditEmployee editEmployee);
        Task<ActionResult<Result>> CreateEmployee(CreateEmployee createEmployee);
        Task<IActionResult> DeleteEmployee(int id);
    }
}

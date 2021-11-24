using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechZoneHRMS.API.Models;
using TechZoneHRMS.Domain.Models.Employee;
using TechZoneHRMS.Domain.Response;
using TechZoneHRMS.Service.Interface;

namespace TechZoneHRMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeDetail>> GetEmployees()
        {
            return await employeeService.GetEmployees();
        }

        [HttpGet("id")]
        public async Task<ActionResult<EmployeeDetail>> GetEmployeeById(int id)
        {
            return await employeeService.GetEmployeeById(id);
        }

        [HttpPost]
        public async Task<ActionResult<Result>> CreateEmployee(CreateEmployee createEmployee)
        {
            return await employeeService.CreateEmployee(createEmployee);
        }

        [HttpPut]
        public async Task<ActionResult<Result>> EditEmployee(EditEmployee editEmployee)
        {
            return await employeeService.EditEmployee(editEmployee);
        }

        [HttpPatch]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            return await employeeService.DeleteEmployee(id);
        }
    }
}

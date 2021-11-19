using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechZoneHRMS.API.Models;
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
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await employeeService.GetEmployees();
        }

        [HttpGet("id")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            return await employeeService.GetEmployeeById(id);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            return await employeeService.CreateEmployee(employee);
        }

        [HttpPut]
        public async Task<IActionResult> EditEmployee(int id, Employee employee)
        {
            return await employeeService.EditEmployee(id, employee);
        }

        [HttpPatch]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            return await employeeService.DeleteEmployee(id);
        }
    }
}

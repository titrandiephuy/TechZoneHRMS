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
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        {
            return await departmentService.GetDepartments();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartmentById(int id)
        {
            return await departmentService.GetDepartmentById(id);
        }

        [HttpPost]
        public async Task<ActionResult<Department>> CreateDepartment(Department department)
        {
            return await departmentService.CreateDepartment(department);
        }

        [HttpPut]
        public async Task<IActionResult> EditDepartment(int id, Department department)
        {
            return await departmentService.EditDepartment(id, department);
        }

        [HttpPatch]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            return await departmentService.DeleteDepartment(id);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechZoneHRMS.API.Models;
using TechZoneHRMS.Domain.Models;
using TechZoneHRMS.Domain.Models.Department;
using TechZoneHRMS.Domain.Response;
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
        public async Task<IEnumerable<DepartmentDetail>> GetDepartments()
        {
            return await departmentService.GetDepartments();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentDetail>> GetDepartmentById(int id)
        {
            return await departmentService.GetDepartmentById(id);
        }

        [HttpPost]
        public async Task<ActionResult<Result>> CreateDepartment(CreateDepartment department)
        {
            return await departmentService.CreateDepartment(department);
        }

        [HttpPut]
        public async Task<ActionResult<Result>> EditDepartment(DepartmentDetail editdepartment)
        {
            return await departmentService.EditDepartment(editdepartment);
        }
        [HttpPatch]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            return await departmentService.DeleteDepartment(id);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TechZoneHRMS.API.Models;
using TechZoneHRMS.Domain.Models;
using TechZoneHRMS.Domain.Response;

namespace TechZoneHRMS.Service.Interface
{
    public interface IDepartmentService
    {
        Task<ActionResult<IEnumerable<Department>>> GetDepartments();
        Task<ActionResult<Department>> GetDepartmentById(int id);
        Task<IActionResult> EditDepartment(int id, Department department);
        Task<ActionResult<Result>> CreateDepartment(CreateDepartment create);
        Task<IActionResult> DeleteDepartment(int id);
    }
}

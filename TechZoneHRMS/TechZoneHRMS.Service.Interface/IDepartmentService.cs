using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TechZoneHRMS.API.Models;

namespace TechZoneHRMS.Service.Interface
{
    public interface IDepartmentService
    {
        Task<ActionResult<IEnumerable<Department>>> GetDepartments();
        Task<ActionResult<Department>> GetDepartmentById(int id);
        Task<IActionResult> EditDepartment(int id, Department department);
        Task<ActionResult<Department>> CreateDepartment(Department department);
        Task<IActionResult> DeleteDepartment(int id);
    }
}

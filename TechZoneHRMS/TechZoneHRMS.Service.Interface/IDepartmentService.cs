using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TechZoneHRMS.API.Models;
using TechZoneHRMS.Service.Interface;
using TechZoneHRMS.Domain.Response;
using TechZoneHRMS.Domain.Models.Department;
using TechZoneHRMS.Domain.Models;

namespace TechZoneHRMS.Service.Interface
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentDetail>> GetDepartments();
        Task<ActionResult<DepartmentDetail>> GetDepartmentById(int id);
        Task<IActionResult> EditDepartment(int id, EditDepartment editdepartment);
        Task<ActionResult<Result>> CreateDepartment(CreateDepartment create);
        Task<IActionResult> DeleteDepartment(int id);
    }
}

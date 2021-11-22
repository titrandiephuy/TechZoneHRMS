using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechZoneHRMS.MVC.Commons;
using TechZoneHRMS.MVC.Helpers;
using TechZoneHRMS.MVC.Models.Departments;

namespace TechZoneHRMS.MVC.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("/Department/Get")]
        public async Task<IActionResult> Get()
        {
            var data = await ApiHelper.HttpGet<List<Department>>(@$"{Common.ApiUrl}Category");
            return Ok(data);
        }
        [HttpGet]
        [Route("/Department/GetDepartmentById")]
        public async Task<Department> GetDepartmentById([FromQuery] int id)
        {
            return await ApiHelper.HttpGet<Department>(@$"{Common.ApiUrl}Category/GetDepartmentById?id=" + id);
        }

    }
}

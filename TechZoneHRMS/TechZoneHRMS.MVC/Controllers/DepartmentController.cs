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
        [Route("api/Department")]
        public async Task<IActionResult> Get()
        {
            var data = ApiHelper.HttpGet<List<Department>>(@$"{Common.ApiUrl}Department");
            return Ok(data);
        }
        [HttpPost]
        [Route("api/Department")]
        public async Task<IActionResult> Create([FromBody] CreateDepartment model)
        {
            return Ok(ApiHelper.HttpPost<CreateDepartmentResult>(@$"{Common.ApiUrl}Department", "POST", model));
        }
    }
}

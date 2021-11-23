using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechZoneHRMS.API.Models;
using TechZoneHRMS.MVC.Commons;
using TechZoneHRMS.MVC.Helpers;
using TechZoneHRMS.MVC.Models.Departments;
using TechZoneHRMS.Service.Interface;

namespace TechZoneHRMS.MVC.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService service;

        public DepartmentController(IDepartmentService service)
        {
            this.service = service;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
         var departments = await service.GetDepartments();
            return View();
        }
        
    }
}

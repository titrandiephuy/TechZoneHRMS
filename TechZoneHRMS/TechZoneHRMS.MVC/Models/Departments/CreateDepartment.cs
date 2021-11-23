using System;
namespace TechZoneHRMS.MVC.Models.Departments
{
    public class CreateDepartment
    {
        public string DepartmentName { get; set; }
        public string DepartmentPhoneNumber { get; set; }
        public string DepartmentLocation { get; set; }
        public bool DepartmentStatus { get; set; }
    }
}

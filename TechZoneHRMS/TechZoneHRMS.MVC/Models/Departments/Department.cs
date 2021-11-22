using System;
namespace TechZoneHRMS.MVC.Models.Departments
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentPhoneNumber { get; set; }
        public string DepartmentLocation { get; set; }
        public bool DepartmentStatus { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace TechZoneHRMS.Domain.Models
{
    public class CreateDepartment
    {
        [Required]
        [StringLength(100)]
        public string DepartmentName { get; set; }
        [Required]
        [StringLength(50)]
        public string DepartmentPhoneNumber { get; set; }
        [Required]
        [StringLength(100)]
        public string DepartmentLocation { get; set; }
        [Required]
        public bool DepartmentStatus { get; set; }
    }
}

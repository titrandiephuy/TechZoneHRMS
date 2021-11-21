using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechZoneHRMS.Domain.Models.Department
{
    public class DepartmentDetail
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentPhoneNumber { get; set; }
        public string DepartmentLocation { get; set; }
        public bool DepartmentStatus { get; set; }
    }
}

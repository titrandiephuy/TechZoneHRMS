using System;
using System.Collections.Generic;

#nullable disable

namespace TechZoneHRMS.API.Models
{
    public partial class Salary
    {
        public Salary()
        {
            Employees = new HashSet<Employee>();
        }

        public int SalaryId { get; set; }
        public double PayRate { get; set; }
        public int Commission { get; set; }
        public int Allowance { get; set; }
        public int BasicSalary { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}

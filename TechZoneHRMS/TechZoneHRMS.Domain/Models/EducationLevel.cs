﻿using System;
using System.Collections.Generic;

#nullable disable

namespace TechZoneHRMS.API.Models
{
    public partial class EducationLevel
    {
        public EducationLevel()
        {
            Employees = new HashSet<Employee>();
        }

        public int EducationLevelId { get; set; }
        public string Degree { get; set; }
        public string Major { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}

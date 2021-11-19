using System;
using System.Collections.Generic;

#nullable disable

namespace TechZoneHRMS.API.Models
{
    public partial class Leaf
    {
        public int LeaveId { get; set; }
        public string LeaveName { get; set; }
        public int LeaveDays { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? TotalDays { get; set; }
        public int EmployeeId { get; set; }
        public bool? StatusLeave { get; set; }

        public virtual Employee Employee { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace TechZoneHRMS.API.Models
{
    public partial class InChange
    {
        public DateTime? EmployeedDate { get; set; }
        public int? EmployeeId { get; set; }
        public int? PositionId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Position Position { get; set; }
    }
}

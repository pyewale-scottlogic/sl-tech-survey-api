using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class ProjectOwner
    {
        public int ProjectOwnerId { get; set; }
        public int? ProjectId { get; set; }
        public int? AccountOwnerId { get; set; }
        public int? TechLeadId { get; set; }
        public DateTime? FromDate { get; set; }

        public virtual Employee? AccountOwner { get; set; }
        public virtual Project? Project { get; set; }
        public virtual Employee? TechLead { get; set; }
    }
}

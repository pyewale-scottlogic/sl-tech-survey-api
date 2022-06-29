using System;
using System.Collections.Generic;

namespace TechSurveyAPI.Models
{
    public partial class ProjectOwner
    {
        public int ProjectOwnerId { get; set; }
        public int ProjectId { get; set; }
        public int AccountOwnerId { get; set; }
        public int TechLeadId { get; set; }
        public DateTime? FromDate { get; set; }

        public virtual Employee AccountOwner { get; set; } = null!;
        public virtual Project Project { get; set; } = null!;
        public virtual Employee TechLead { get; set; } = null!;
    }
}

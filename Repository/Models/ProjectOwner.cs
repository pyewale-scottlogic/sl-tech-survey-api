using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class ProjectOwner
    {
        public int? ProjectSurveyId { get; set; }
        public int? AccountOwnerId { get; set; }
        public int? TechLeadId { get; set; }

        public virtual Employee? AccountOwner { get; set; }
        public virtual ProjectSurvey? ProjectSurvey { get; set; }
        public virtual Employee? TechLead { get; set; }
    }
}

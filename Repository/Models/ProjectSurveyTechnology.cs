using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class ProjectSurveyTechnology
    {
        public int? ProjectSurveyId { get; set; }
        public int? TechnologyId { get; set; }

        public virtual ProjectSurvey? ProjectSurvey { get; set; }
        public virtual Technology? Technology { get; set; }
    }
}

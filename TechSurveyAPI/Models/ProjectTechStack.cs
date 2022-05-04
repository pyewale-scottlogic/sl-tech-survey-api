using System;
using System.Collections.Generic;

namespace TechSurveyAPI.Models
{
    public partial class ProjectTechStack
    {
        public int ProjectTechStackId { get; set; }
        public int ProjectSurveyId { get; set; }
        public int TechnologyId { get; set; }

        public virtual ProjectSurvey ProjectSurvey { get; set; } = null!;
        public virtual Technology Technology { get; set; } = null!;
    }
}

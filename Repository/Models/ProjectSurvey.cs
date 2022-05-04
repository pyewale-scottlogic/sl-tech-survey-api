using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class ProjectSurvey
    {
        public ProjectSurvey()
        {
            ProjectTechStacks = new HashSet<ProjectTechStack>();
        }

        public int ProjectSurveyId { get; set; }
        public int ProjectId { get; set; }
        public int SurveyId { get; set; }
        public int PlatformId { get; set; }
        public DateTime SurveyDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Platform Platform { get; set; } = null!;
        public virtual Project Project { get; set; } = null!;
        public virtual Survey Survey { get; set; } = null!;
        public virtual ICollection<ProjectTechStack> ProjectTechStacks { get; set; }
    }
}

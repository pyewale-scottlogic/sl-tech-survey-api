using System;
using System.Collections.Generic;

namespace TechSurveyAPI.Models
{
    public partial class Platform
    {
        public Platform()
        {
            ProjectSurveys = new HashSet<ProjectSurvey>();
        }

        public int PlatformId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<ProjectSurvey> ProjectSurveys { get; set; }
    }
}

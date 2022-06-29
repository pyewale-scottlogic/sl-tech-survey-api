using System;
using System.Collections.Generic;

namespace TechSurveyAPI.Models
{
    public partial class ProjectSurvey
    {
        public ProjectSurvey()
        {
            Platforms = new HashSet<Platform>();
            Technologies = new HashSet<Technology>();
        }

        public int ProjectSurveyId { get; set; }
        public int? ProjectId { get; set; }
        public DateTime? SurveyDate { get; set; }
        public int? Quarter { get; set; }
        public int? Year { get; set; }

        public virtual Project? Project { get; set; }

        public virtual ICollection<Platform> Platforms { get; set; }
        public virtual ICollection<Technology> Technologies { get; set; }
    }
}

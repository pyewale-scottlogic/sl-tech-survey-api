using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class ProjectSurvey
    {
        public ProjectSurvey()
        {
            ProjectOwners = new HashSet<ProjectOwner>();
            Technologies = new HashSet<Technology>();
        }

        public int ProjectSurveyId { get; set; }
        public int? ProjectId { get; set; }
        public int? PlatformId { get; set; }
        public DateTime? SurveyDate { get; set; }
        public int? Quarter { get; set; }
        public int? Year { get; set; }

        public virtual Platform? Platform { get; set; }
        public virtual Project? Project { get; set; }
        public virtual ICollection<ProjectOwner> ProjectOwners { get; set; }

        public virtual ICollection<Technology> Technologies { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class Project
    {
        public Project()
        {
            ProjectOwners = new HashSet<ProjectOwner>();
            ProjectSurveys = new HashSet<ProjectSurvey>();
        }

        public int ProjectId { get; set; }
        public string ProjectName { get; set; } = null!;
        public string? KimbleUrl { get; set; }
        public int? KimbleProjectId { get; set; }
        public int? CompanyId { get; set; }

        public virtual Company? Company { get; set; }
        public virtual ICollection<ProjectOwner> ProjectOwners { get; set; }
        public virtual ICollection<ProjectSurvey> ProjectSurveys { get; set; }
    }
}

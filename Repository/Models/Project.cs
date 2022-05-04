using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class Project
    {
        public Project()
        {
            ProjectSurveys = new HashSet<ProjectSurvey>();
        }

        public int ProjectId { get; set; }
        public string Name { get; set; } = null!;
        public int? CompanyId { get; set; }

        public virtual Company? Company { get; set; }
        public virtual ICollection<ProjectSurvey> ProjectSurveys { get; set; }
    }
}

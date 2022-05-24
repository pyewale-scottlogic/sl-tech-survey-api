using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class Technology
    {
        public Technology()
        {
            ProjectSurveys = new HashSet<ProjectSurvey>();
        }

        public int TechnologyId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<ProjectSurvey> ProjectSurveys { get; set; }
    }
}

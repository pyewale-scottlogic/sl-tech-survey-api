using System;
using System.Collections.Generic;

namespace TechSurveyAPI.Models
{
    public partial class Technology
    {
        public Technology()
        {
            ProjectTechStacks = new HashSet<ProjectTechStack>();
        }

        public int TechnologyId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<ProjectTechStack> ProjectTechStacks { get; set; }
    }
}

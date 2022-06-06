using Repository.Models;

namespace TechSurveyAPI.DTOs
{
    public class ProjectSurveyDTO
    {
        public int ProjectSurveyId { get; set; }
        public int? ProjectId { get; set; }
        public int? PlatformId { get; set; }
        public DateTime? SurveyDate { get; set; }
        public int? Quarter { get; set; }
        public int? Year { get; set; }

        public ICollection<TechnologyDTO>? Technologies { get; set; }

        public ICollection<ProjectOwnerDTO>? ProjectOwners { get; set; }
    }
}

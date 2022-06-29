using System.ComponentModel.DataAnnotations;

namespace TechSurveyAPI.DTOs
{
    public class ProjectSurveyUpdateDTO
    {
        [Required]
        public int ProjectSurveyId { get; set; }

        [Required(ErrorMessage = "Project is mandatory!")]
        public int ProjectId { get; set; }
        
        [Required(ErrorMessage = "Quarter is mandatory!")]
        public int? Quarter { get; set; }

        [Required(ErrorMessage = "Year is mandatory!")]
        public int? Year { get; set; }

        public ICollection<TechnologyDTO>? Technologies { get; set; }

        public ICollection<ProjectOwnerUpdateDTO>? ProjectOwners { get; set; }

        public ICollection<PlatformDTO>? Platforms { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace TechSurveyAPI.DTOs
{
    public class ProjectAddDTO
    {
        [Required(ErrorMessage = "Project Name is mandatory!")]
        public string ProjectName { get; set; } = null!;

        [Required(ErrorMessage = "CompanyId is mandatory to add Project!")]
        public int? CompanyId { get; set; }
    }
}

using Repository.Models;
using System.ComponentModel.DataAnnotations;

namespace TechSurveyAPI.DTOs
{
    public class ProjectSurveyAddDTO
    {
        [Required(ErrorMessage = "Project is mandatory!")]
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "Platform is mandatory!")]
        public int PlatformId { get; set; }

        [Required(ErrorMessage = "Quarter is mandatory!")]
        public int? Quarter { get; set; }

        [Required(ErrorMessage = "Year is mandatory!")]
        public int? Year { get; set; }

        //[Required(ErrorMessage = "Account Owner is mandatory!")]
        //public int AccountOwnerId { get; set; }

        //[Required(ErrorMessage = "Tech lead is mandatory!")]
        //public int? TechLeadId { get; set; }
        public ICollection<TechnologyDTO>? Technologies { get; set; }

        public ICollection<ProjectOwnerAddDTO>? ProjectOwners { get; set; }  
    }
}

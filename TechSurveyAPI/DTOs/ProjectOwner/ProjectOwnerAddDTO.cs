using System.ComponentModel.DataAnnotations;

namespace TechSurveyAPI.DTOs
{
    public class ProjectOwnerAddDTO
    {
        public int ProjectId { get; set; }

        [Required(ErrorMessage="Account Owner is required")]
        public int AccountOwnerId { get; set; }
        [Required(ErrorMessage = "Tech Lead is required")]
        public int? TechLeadId { get; set; }
        [Required(ErrorMessage = "From Date is required")]
        public DateTime? FromDate { get; set; }

    }
}

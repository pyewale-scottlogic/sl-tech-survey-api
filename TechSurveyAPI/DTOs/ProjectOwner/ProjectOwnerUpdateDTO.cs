using System.ComponentModel.DataAnnotations;

namespace TechSurveyAPI.DTOs
{
    public class ProjectOwnerUpdateDTO
    {
        public int ProjectOwnerId { get; set; }

        public int ProjectId { get; set; }
        public int? AccountOwnerId { get; set; }
        public int? TechLeadId { get; set; }

        [DataType(DataType.Date)]
        public DateTime? FromDate { get; set; }
    }
}

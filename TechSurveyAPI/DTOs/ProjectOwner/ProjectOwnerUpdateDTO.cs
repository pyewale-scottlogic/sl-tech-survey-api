namespace TechSurveyAPI.DTOs
{
    public class ProjectOwnerUpdateDTO
    {
        public int ProjectSurveyId { get; set; }
        public int? AccountOwnerId { get; set; }
        public int? TechLeadId { get; set; }

        public DateTime? FromDate { get; set; }
    }
}

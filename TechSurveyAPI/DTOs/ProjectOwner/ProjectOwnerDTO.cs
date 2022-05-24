namespace TechSurveyAPI.DTOs
{
    public class ProjectOwnerDTO
    {
        public int ProjectSurveyId { get; set; }
        public int? AccountOwnerId { get; set; }
        public int? TechLeadId { get; set; }

        public DateTime? FromDate { get; set; }
    }
}

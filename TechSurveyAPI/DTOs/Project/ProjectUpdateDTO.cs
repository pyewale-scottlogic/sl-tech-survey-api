namespace TechSurveyAPI.DTOs
{
    public class ProjectUpdateDTO
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; } = null!;

        public string KimbleUrl { get; set; } = null!;
    }
}

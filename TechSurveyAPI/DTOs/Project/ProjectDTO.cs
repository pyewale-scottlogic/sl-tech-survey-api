namespace TechSurveyAPI.DTOs
{
    public class ProjectDTO
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; } = null!;
        public int CompanyId { get; set; }
            
        public string CompanyName { get; set; } = null!;

        public string KimbleUrl { get; set; } 

        public ICollection<ProjectOwnerDTO> ProjectOwners { get; set; }
    }
}

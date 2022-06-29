namespace TechSurveyAPI.DTOs
{
    public class ProjectOwnerDTO
    {
        public int ProjectOwnerId { get; set; }
        public int ProjectId { get; set; }
        public int? AccountOwnerId { get; set; }
        public int? TechLeadId { get; set; }

        public DateTime? FromDate { get; set; }

        public EmployeeDTO AccountOwner { get; set; } = null!;
        public EmployeeDTO TechLead { get; set; } = null!;

        //public ProjectDTO Project { get; set; } = null!;
    }
}

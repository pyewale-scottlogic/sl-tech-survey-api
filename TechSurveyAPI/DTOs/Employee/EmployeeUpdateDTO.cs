namespace TechSurveyAPI.DTOs
{
    public class EmployeeUpdateDTO
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
    }
}

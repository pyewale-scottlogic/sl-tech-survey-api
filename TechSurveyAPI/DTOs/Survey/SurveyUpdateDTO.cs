namespace TechSurveyAPI.DTOs
{
    public class SurveyUpdateDTO
    {
        public int SurveyId { get; set; }
        public string Year { get; set; } = null!;
        public int Quarter { get; set; }
    }
}

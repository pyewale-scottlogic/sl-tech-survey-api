namespace TechSurveyAPI.DTOs
{
    public class SurveyDTO
    {
        public int SurveyId { get; set; }
        public string Year { get; set; } = null!;
        public int Quarter { get; set; }
    }
}

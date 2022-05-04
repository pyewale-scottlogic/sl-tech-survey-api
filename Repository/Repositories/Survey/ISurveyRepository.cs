using Repository.Models;

namespace Repository.Repositories
{
    public interface ISurveyRepository
    {
        Task<IEnumerable<Survey>> GetAllSurveysAsync();
        Task<Survey> GetSurveyByIdAsync(int SurveyId);
        void CreateSurvey(Survey Survey);
        void UpdateSurvey(Survey Survey);
        void DeleteSurvey(Survey Survey);
    }
}

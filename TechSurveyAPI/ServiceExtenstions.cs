using LoggerService;
using Repository.Repositories;

namespace TechSurveyAPI
{
    public static class ServiceExtenstions
    {
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }

        public static void ConfigureLoggerService(this IServiceCollection services) =>
                                                    services.AddSingleton<ILoggerManager, LoggerManager>();


        public static void AddCORSService(this IServiceCollection services)
        {
            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                                      policy =>
                                      {
                                          policy.WithOrigins("http://localhost:3000")
                                                              .AllowAnyHeader()
                                                              .AllowAnyMethod();
                                      });
            });
        }
    }
}

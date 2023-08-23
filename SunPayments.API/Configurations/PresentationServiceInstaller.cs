using SunPayments.API.Exceptions;
using SunPayments.API.Services;

namespace SunPayments.API.Configurations
{
    public class PresentationServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<PublickeyService>(opt =>
            {
                opt.BaseAddress = new Uri(configuration["BaseUrl"]);
            });

            services.AddHttpClient<InitializeService>(opt =>
            {
                opt.BaseAddress = new Uri(configuration["BaseUrl"]);
            });

            services.AddHttpClient<ChallengeService>(opt =>
            {
                opt.BaseAddress = new Uri(configuration["BaseUrl"]);
            });

            services.AddHttpClient<PhoneService>(opt =>
            {
                opt.BaseAddress = new Uri(configuration["BaseUrl"]);
            });

            services.AddHttpClient<InitializeKycService>(opt =>
            {
                opt.BaseAddress = new Uri(configuration["BaseUrl"]);
            });

            services.UseCustomValidationResponse();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                    });
            });
        }
    }
}

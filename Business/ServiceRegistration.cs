using Business.Abstract;
using Business.Concrete;
using Core.Helpers.Security.JWT;
using Core.Storage.Azure;
using Microsoft.Extensions.DependencyInjection;

namespace Business
{
    public static class ServiceRegistration
    {
        public static void AddBusinessService(this IServiceCollection service)
        {

            // Manager and Service
            service.AddScoped<IProjectImageService, ProjectImageManager>();
            service.AddScoped<IProjectService, ProjectManager>();
            service.AddScoped<IAboutMeService, AboutMeManager>();
            service.AddScoped<IContactFormService, ContactFormManager>();
            service.AddScoped<IExperienceService, ExperienceManager>();
            service.AddScoped<ISkillService, SkillManager>();
            service.AddScoped<ISocialMediaService, SocialMediaManager>();

            service.AddScoped<IUserService, UserManager>();
            service.AddScoped<IAuthService, AuthManager>();


            // Additional
            service.AddScoped<IAzureStorage, AzureStorage>();
            service.AddScoped<ITokenHelper, JwtHelper>();
        }
    }
}

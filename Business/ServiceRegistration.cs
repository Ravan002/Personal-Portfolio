using Business.Abstract;
using Business.Concrete;
using Core.Storage.Azure;
using Microsoft.Extensions.DependencyInjection;

namespace Business
{
    public static class ServiceRegistration
    {
        public static void AddBusinessService(this IServiceCollection service)
        {
            service.AddScoped<IProjectImageService, ProjectImageManager>();
            service.AddScoped<IProjectService, ProjectManager>();
            service.AddScoped<IAboutMeService, AboutMeManager>();
            service.AddScoped<IContactFormService, ContactFormManager>();
            service.AddScoped<IExperienceService, ExperienceManager>();
            service.AddScoped<ISkillService, SkillManager>();
            service.AddScoped<ISocialMediaService, SocialMediaManager>();
            service.AddScoped<IAzureStorage, AzureStorage>();
        }
    }
}

using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess
{
    public static class ServiceRegistration
    {
        public static void AddDataAccessService(this IServiceCollection service)
        {
            service.AddDbContext<ProjectContext>();
            service.AddScoped<IAboutMeDal, EfAboutMeDal>();
            service.AddScoped<IContactFormDal, EfContactFormDal>();
            service.AddScoped<IExperienceDal, EfExperienceDal>();
            service.AddScoped<IProjectDal, EfProjectDal>();
            service.AddScoped<IProjectImageDal, EfProjectImageDal>();
            service.AddScoped<ISkillDal, EfSkillDal>();
            service.AddScoped<ISocialMediaDal, EfSocialMediaDal>();
        }
    }
}

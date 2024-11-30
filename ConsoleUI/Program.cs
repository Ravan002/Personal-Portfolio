// Her defe DataAccess-de method yarandan zaman imzanisini iterface-de ilk yarat yaddan cixmasin




using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

//IProjectImageDal pi = new EfProjectImageDal();
//ProjectContext context = new();
//IProjectDal p = new EfProjectDal();
//var project = context.Projects.Include(p => p.ProjectImages).FirstOrDefault(p => p.Id == 1);
//Console.WriteLine("Hello");
//foreach (var item in project.ProjectImages)
//{
//    Console.WriteLine(item.ImagePath);
//}


//project.ProjectImages = new List<ProjectImage>
//{
//    new ProjectImage
//    {
//        ImagePath="main image"
//    },
//    new ProjectImage
//    {
//        ImagePath="chat part image"
//    },
//};
//var projectImage = new ProjectImage
//{
//    ImagePath = "chat part image"
//};
//project.ProjectImages.Add(projectImage);
//pi.Add(projectImage);




//Project project = new Project
//{
//    ProjectName = "Portfolio",
//    Description = "Personal website",
//    Link = "//httpada"
//};

//p.Add(project);
//Console.WriteLine(project.ProjectImages.Count);

ProjectContext context = new();
IAboutMeDal aboutMe = new EfAboutMeDal(context);

AboutMe? about1 = await aboutMe.GetAsync(a => a.Id == 1);
if(about1 != null)
{
    about1.Profession = "Backend Developer (C#/.NET)";
    int save = await aboutMe.Update(about1);
    Console.WriteLine(save);
}
else
{
    Console.WriteLine("Dont have such account");
}

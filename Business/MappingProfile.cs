using AutoMapper;
using Entities.Concrete;
using Entities.Dtos.AboutMeDtos;
using Entities.Dtos.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Project 
            CreateMap<AddProjectDto, Project>();


            // About Me 
            CreateMap<AboutMeDto, AboutMe>();
        }
    }
}

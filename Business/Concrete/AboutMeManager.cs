using AutoMapper;
using Business.Abstract;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.AboutMeDtos;

namespace Business.Concrete
{
    public class AboutMeManager(IAboutMeDal aboutMeDal, IMapper mapper) : IAboutMeService
    {
        private readonly IAboutMeDal _aboutMeDal= aboutMeDal;
        private readonly IMapper _mapper = mapper;
        public async Task<IResult> AddAboutMe(AboutMeDto dto)
        {
            AboutMe aboutMe = _mapper.Map<AboutMe>(dto);
            var result = await _aboutMeDal.AddAsync(aboutMe);
            return new SuccessResult($"{result} operation done");
        }

        public Task<IResult> UpdateAboutMe(int id)
        {
            throw new NotImplementedException();
        }
    }
}

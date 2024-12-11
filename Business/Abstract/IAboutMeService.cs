using Core.Helpers.Results.Abstract;
using Entities.Dtos.AboutMeDtos;

namespace Business.Abstract
{
    public interface IAboutMeService
    {
        Task<IResult> AddAboutMe(AboutMeDto dto);
        Task<IResult> UpdateAboutMe(int id );
    }
}

using Core.Helpers.Results.Abstract;
using Entities.Concrete.Auth;

namespace Business.Abstract
{
    public interface IUserService
    {
        Task<IDataResult<List<User>>> GetAllUserWithRoleAsync();
        Task<IDataResult<User>> GetUserByEmail(string email);
        Task AddUser(User user);
        Task<IResult> UpdateUser(User user);
    }
}

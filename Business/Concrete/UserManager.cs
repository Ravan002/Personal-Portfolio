using Business.Abstract;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.Auth;

namespace Business.Concrete
{
    public class UserManager(IUserDal userDal) : IUserService
    {
        private readonly IUserDal _userDal = userDal;

        public async Task<IDataResult<List<User>>> GetAllUserWithRoleAsync()
        {
            var result = await _userDal.GetAllUsersWithRole();
            return result.Count != 0
                ? new SuccesDataResult<List<User>>(result, "succes result")
                : new ErrorDataResult<List<User>>(result, "nothing found");
        }

        public async Task<IDataResult<User>> GetUserByEmail(string email)
        {
            var result = await _userDal.GetAsync(u => u.Email == email);
            return result != null ? new SuccesDataResult<User>(result) : new ErrorDataResult<User>();
        }
        public async Task AddUser(User user)
        {
            var result = await _userDal.AddAsync(user);
        }

        public async Task<IResult> UpdateUser(User user)
        {
            var result = await _userDal.UpdateAsync(user);
            return result > 0 
                ? new SuccessResult("Success Update") 
                : new ErrorResult("Operation Failed");
        }

    }
}

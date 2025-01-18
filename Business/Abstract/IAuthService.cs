using Core.Helpers.Results.Abstract;
using Core.Helpers.Security.JWT;
using Entities.Concrete.Auth;
using Entities.Dtos.Auth;

namespace Business.Abstract
{
    public interface IAuthService
    {
        Task<IDataResult<TokenResponse>> Login(LoginDto dto);
        Task<IDataResult<TokenResponse>> Register(RegisterDto dto);
        TokenResponse CreateTokens(User user);
        Task<IDataResult<TokenResponse>> RefreshAccessToken(TokenResponse tokenRequest);
        Task<User?> GetUserByEmailFromExpireToken(string accessToken);
    }
}

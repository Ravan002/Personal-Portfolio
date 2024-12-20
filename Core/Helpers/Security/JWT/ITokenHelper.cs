using Entities.Concrete.Auth;

namespace Core.Helpers.Security.JWT
{
    public interface ITokenHelper
    {
        string CreateAccessToken(User user);
        (string RefreshToken, DateTime ExpireTime) CreateRefreshToken();
    }
}

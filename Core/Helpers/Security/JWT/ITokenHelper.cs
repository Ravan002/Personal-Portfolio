using Entities.Concrete.Auth;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Core.Helpers.Security.JWT
{
    public interface ITokenHelper
    {
        string CreateAccessToken(User user);
        (string RefreshToken, DateTime ExpireTime) CreateRefreshToken();
        IEnumerable<Claim> GetClaimPrincipalsFromAccessToken(string accessToken);
    }
}

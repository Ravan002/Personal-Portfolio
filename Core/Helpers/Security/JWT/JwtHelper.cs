using Core.Helpers.Security.Encryption;
using Entities.Concrete.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Core.Helpers.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        private readonly TokenParams _tokenParams;
        private readonly IConfiguration _configuration;
        public JwtHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            _tokenParams = _configuration.GetSection("TokenParams").Get<TokenParams>()!;
        }
        public string CreateAccessToken(User user)
        {
            var expire = DateTime.UtcNow.AddMinutes(_tokenParams.AccessTokenLifeTime);

            SecurityKey secretKey = SecurityKeyHelper.CreateSecurityKey(_tokenParams.SecretKey);

            SigningCredentials signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(secretKey);

            var securityToken = new JwtSecurityToken(
                issuer: _tokenParams.Issuer,
                audience: _tokenParams.Audience,
                notBefore: DateTime.UtcNow,
                expires: expire,
                signingCredentials: signingCredentials,
                claims: SetClaims(user)
                );
            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.WriteToken(securityToken);

            return token;
        }

        public (string RefreshToken, DateTime ExpireTime) CreateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return (Convert.ToBase64String(randomNumber), DateTime.UtcNow.AddMinutes(_tokenParams.RefreshTokenLifeTime));
        }

        private IEnumerable<Claim> SetClaims(User user)
        {
            var claims = new List<Claim>
            {
                new (ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new (ClaimTypes.Email, user.Email),
            };
            if (user.RoleClaim != null)
            {
                claims.Add(new Claim(ClaimTypes.Role, user.RoleClaim.Name));
            }
            return claims;
        }


        public IEnumerable<Claim> GetClaimPrincipalsFromAccessToken(string accessToken)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidAudience = _tokenParams.Audience,

                ValidateIssuer = true,
                ValidIssuer = _tokenParams.Issuer,

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(_tokenParams.SecretKey),

                //ValidateLifetime = true,
                //ClockSkew = TimeSpan.Zero
            };

            var tokenHadler = new JwtSecurityTokenHandler();
            var principal = tokenHadler.ValidateToken(accessToken, tokenValidationParameters, out _);

            return principal.Claims;
        }
    }
}

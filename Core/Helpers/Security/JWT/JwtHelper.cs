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
            var expire = DateTime.UtcNow.AddSeconds(_tokenParams.AccessTokenLifeTime);

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
            return (Convert.ToBase64String(randomNumber), DateTime.UtcNow.AddSeconds(_tokenParams.RefreshTokenLifeTime));
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
    }
}


//var claims = new List<Claim>
//    {
//        new(ClaimTypes.Name, "ravan"),
//        new(ClaimTypes.Email,"mammedov.r39@gmail.com")
//    };


//SymmetricSecurityKey secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secretKey.secretKey.secretKey.secretKey.secretKey.secretKey.secretKey.secretKey.secretKey.secretKey.secretKey.secretKey.secretKey."));
//SigningCredentials signInCredentials = new SigningCredentials(secretKey, algorithm: SecurityAlgorithms.HmacSha256);

//var expirationDate = DateTime.Now.AddSeconds(60);
//SecurityToken jwt = new JwtSecurityToken(issuer: "portfolio-back", audience: "portfolio-front", claims: claims, notBefore: DateTime.Now, expires: expirationDate, signingCredentials: signInCredentials);
//SecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

//var token = tokenHandler.WriteToken(jwt);
//Console.WriteLine(token);
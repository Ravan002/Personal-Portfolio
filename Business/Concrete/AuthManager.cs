using Business.Abstract;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using Core.Helpers.Security.Hashing;
using Core.Helpers.Security.JWT;
using Entities.Concrete.Auth;
using Entities.Dtos.Auth;
using System.Security.Claims;

namespace Business.Concrete
{
    public class AuthManager(IUserService userService, ITokenHelper tokenHelper) : IAuthService
    {
        private readonly IUserService _userService = userService;
        private readonly ITokenHelper _tokenHelper = tokenHelper;

        public async Task<IDataResult<TokenResponse>> Login(LoginDto dto)
        {
            var result = await _userService.GetUserByEmail(dto.Email);
            if (!result.Success)
            {
                return new ErrorDataResult<TokenResponse>("wrong email or password");
            }
            User user = result.Data;

            bool userPasswordCheck = HashingHelper.VerifyPasswordHash(dto.Password, user.PasswordHash, user.PasswordSalt);
            var tokenResponse = userPasswordCheck ? CreateTokens(user) : null;
            if (tokenResponse != null)
            {
                var updateResult = await _userService.UpdateUser(user);
                return new SuccesDataResult<TokenResponse>(tokenResponse, "Success login");
            }
            return new ErrorDataResult<TokenResponse>("wrong email or password");
        }

        public async Task<IDataResult<TokenResponse>> Register(RegisterDto dto)
        {
            var userExistCheck = await _userService.GetUserByEmail(dto.Email);
            if (userExistCheck.Data != null)
            {
                return new ErrorDataResult<TokenResponse>("Email already used");
            }
            if (dto.Password != dto.ConfirmPassword)
            {
                return new ErrorDataResult<TokenResponse>("passwords doesnt match");
            }

            // Change this past using mapper
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePassordHash(dto.Password, out passwordHash, out passwordSalt);
            User user = new User
            {
                Email = dto.Email,
                FirstName = dto.FirtName,
                LastName = dto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            var tokenResponse = CreateTokens(user);
            await _userService.AddUser(user);

            return new SuccesDataResult<TokenResponse>(tokenResponse, "register succesfully completed");
        }

        public TokenResponse CreateTokens(User user)
        {
            var accessToken = _tokenHelper.CreateAccessToken(user);
            var (refreshToken, expireTime) = _tokenHelper.CreateRefreshToken();
            var tokenResponse = new TokenResponse
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                RefreshTokenExpireTime = expireTime
            };
            user.RefreshToken = tokenResponse.RefreshToken;
            user.RefreshTokenExpireTime = expireTime;
            return tokenResponse;
        }

        public async Task<IDataResult<TokenResponse>> RefreshAccessToken(TokenResponse tokenRequest)
        {
            var user = await GetUserByEmailFromExpireToken(tokenRequest.AccessToken);

            if (user!=null && user.RefreshToken == tokenRequest.RefreshToken && user.RefreshTokenExpireTime >= DateTime.UtcNow)
            {
                var tokenResponse = CreateTokens(user);
                await _userService.UpdateUser(user);
                return new SuccesDataResult<TokenResponse>(tokenResponse,"Success");
            }
            return new ErrorDataResult<TokenResponse>("Error");
        }

        public async Task<User?> GetUserByEmailFromExpireToken(string accessToken)
        {
            var claims = _tokenHelper.GetClaimPrincipalsFromAccessToken(accessToken);
            var email = claims.SingleOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

            var user = email != null ? await _userService.GetUserByEmail(email) : null;
            return user.Data;
        }
    }

}

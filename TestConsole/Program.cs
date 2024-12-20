
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using TestConsole;

Console.WriteLine("Hello, World!");

// JWT work logic we create one token, when user want to make action or use method, sends token.
// base64url-encoded(header).base64url-encoded(payload).signature - jwt consist of 3 part and seperate by dot.
// server take first 2 part and use token algorithm which is in header and secret key which we use to create token. This secret key always stay in private place 
// then use the algorithm, 2 part and secret key and result from this part if the wqual to signature part so token is valid.
// jwt.io -da secret key verib api terefde saxta jwt create edib yoxla-> yoxlanildi saxta token isledi
// Elave olarak program.cs -de token icin  ClockSkew=TimeSpan.Zero yazmak gerek cunki expirration time yoxlanilmirdi.

var randomNumber = new byte[32];

using var rng = RandomNumberGenerator.Create();
Console.WriteLine(rng.ToString());

rng.GetBytes(randomNumber);
Console.WriteLine(randomNumber.ToString());

var result = Convert.ToBase64String(randomNumber);
Console.WriteLine(result);

static AccessToken GenerateToken()
{
    var claims = new List<Claim>
    {
        new(ClaimTypes.Name, "ravan"),
        new(ClaimTypes.Email,"mammedov.r39@gmail.com")
    };


    SymmetricSecurityKey secretKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secretKey.secretKey.secretKey.secretKey.secretKey.secretKey.secretKey.secretKey.secretKey.secretKey.secretKey.secretKey.secretKey."));
    SigningCredentials signInCredentials= new SigningCredentials(secretKey, algorithm: SecurityAlgorithms.HmacSha256);

    var expirationDate = DateTime.Now.AddSeconds(60);
    SecurityToken jwt = new JwtSecurityToken(issuer: "portfolio-back", audience: "portfolio-front",claims: claims,notBefore: DateTime.Now, expires: expirationDate,signingCredentials: signInCredentials);
    SecurityTokenHandler tokenHandler= new JwtSecurityTokenHandler();

    var token=tokenHandler.WriteToken(jwt);
    Console.WriteLine(token);
    Console.WriteLine("===================================================");


    var result=tokenHandler.ValidateToken(token, new TokenValidationParameters
    {
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "portfolio-back",
        ValidAudience = "portfolio-front",
        IssuerSigningKey = secretKey
    }, out SecurityToken validatedToken);

    Console.WriteLine(result);
    return null;
}


// bugun user yarat , login register, claims

// Refresh Token => Access  token vaxti bitdikde 401 Unauthorized xetais verilir ve auto olarak Refresh methodu ise dusur.
// Refresh methodu refresh tokeni istifade  ederek , eger expire olmayibsa yeni bir access token yaradir ve user-e gonderir.
// HttpContext ile userid gotur, sonra id ile refresh token gotur ve client terefden gelen refresh token ile eyni olub olmadigini yoxla

// SigningCredentialsdaki hmacsha 256 ve signature olani arasindaki ferq nedir bax
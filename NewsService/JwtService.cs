using Anas_Abualsauod.News.Domain.Dtos.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using News.Infrastracture.EFDbContext;
using News.Infrastracture.Encrybtion;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace News.Service
{
    public class JwtService
    {
        private readonly NewsDbContext _context;
        private readonly IConfiguration _configuration;

        public JwtService(NewsDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<LoginUserResponse> AuthenticateUser(LoginUserRequest loginRequest)
        {
            var user = await _context.Users.
                FirstOrDefaultAsync(u => u.UserName == loginRequest.UserName);
            if (user == null)
            {
                return null; // Authentication failed
            }

            var isPasswordValid = HashData.Verify(loginRequest.Password, user.Password);

            if (!isPasswordValid)
            {
                return null; // Authentication failed
            }

            // Generate JWT token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["JwtConfig:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                  {
        new Claim(ClaimTypes.Name, user.UserName)
    }),
                Expires = DateTime.UtcNow.AddMinutes(60),
                Issuer = _configuration["JwtConfig:Issuer"],//1
                Audience = _configuration["JwtConfig:Audience"],//2
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);
            return new LoginUserResponse
            {
                Id = user.Id,
                UserName = user.UserName,
                AccessToken = jwtToken,
                Expiration = 3600 // Token expiration time in seconds
            };
        }



    }
}
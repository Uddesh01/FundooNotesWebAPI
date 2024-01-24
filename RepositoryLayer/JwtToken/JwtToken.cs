using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Entitys;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace RepositoryLayer.JwtToke
{   
    public class JwtToken
    {
        public IConfiguration configuration;
        public JwtToken(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string GenerateToken(UserEntity userEntity)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim("Email",userEntity.UserEmail),
                new Claim("UserId",userEntity.UserId.ToString())
            };
            var token = new JwtSecurityToken(configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

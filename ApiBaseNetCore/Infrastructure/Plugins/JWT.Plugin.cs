using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ApiBaseNetCore.Infrastructure.Interfaces;
using Domain.Dtos;

using Microsoft.IdentityModel.Tokens;

namespace ApiBaseNetCore.Infrastructure.Plugins
{
    public class JWTPlugin : IJwt
    {

      
        public string GenerateToken(JWTOptionsDto options)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            // add personalized Claims
            var claims = new List<Claim>
            {
                new Claim(type:"UserId", value: options.UserId.ToString()),
                new Claim(type:"NTUser", value: options.NTUser),
                new Claim(type:"RoleId", value: options.RoleId.ToString())
                
            };
            var key = new SymmetricSecurityKey( Encoding.ASCII.GetBytes(options.SecretKey));
            var credencials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                claims: claims,
                notBefore: DateTime.Now,
                expires: options.ExpireDate,
                signingCredentials: credencials
            );
            return tokenHandler.WriteToken(token);
        }

        public JWTOptionsDto DecodeToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("SecretKey");
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out var validatedToken);
            var jwtToken = (JwtSecurityToken) validatedToken;
            var userId = jwtToken.Claims.First(x => x.Type == "UserId").Value;
            var ntUser = jwtToken.Claims.First(x => x.Type == "NTUser").Value;
            var roleId = jwtToken.Claims.First(x => x.Type == "RoleId").Value;
            return new JWTOptionsDto
            {
                UserId = int.Parse(userId),
                NTUser = ntUser,
                RoleId = int.Parse(roleId)
            };
        }
    }
}
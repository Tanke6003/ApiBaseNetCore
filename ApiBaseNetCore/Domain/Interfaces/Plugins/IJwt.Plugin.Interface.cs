
using ApiBaseNetCore.Domain.Dtos;


namespace ApiBaseNetCore.Infrastructure.Interfaces
{
    public interface IJwt
    {
        string GenerateToken(JWTOptionsDto options);
        JWTOptionsDto DecodeToken(string token);


        
    }
}
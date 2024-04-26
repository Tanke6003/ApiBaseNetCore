
using Domain.Dtos;

namespace Infrastructure.Interfaces
{
    public interface IJwt
    {
        string GenerateToken(JWTOptionsDto options);
        JWTOptionsDto DecodeToken(string token);


        
    }
}
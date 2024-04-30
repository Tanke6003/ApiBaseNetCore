
using ApiBaseNetCore.Domain.Dtos;

namespace ApiBaseNetCore.Domain.Interfaces.Services
{
    public interface IUserService
    {
        List<UserDto> GetUsers();
    }
}

using Domain.Dtos;

namespace Application.Interfaces
{
    public interface IUserService
    {
        List<UserDto> GetUsers();
    }
}
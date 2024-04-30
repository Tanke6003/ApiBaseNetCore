
using ApiBaseNetCore.Domain.Dtos;

namespace ApiBaseNetCore.Domain.Interfaces.Repository{
    public interface IUserRepository{
        
        List<UserDto> GetUsers(out string exceptionMessage);

        UserDto GetUserById(int id, out string exceptionMessage);

    }
}
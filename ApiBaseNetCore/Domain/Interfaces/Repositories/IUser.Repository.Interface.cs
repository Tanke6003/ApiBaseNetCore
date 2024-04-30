
using Domain.Dtos;

namespace ApiBaseNetCore.Infrastructure.Interfaces.Repository{
    public interface IUserRepository{
        
        List<UserDto> GetUsers();

    }
}
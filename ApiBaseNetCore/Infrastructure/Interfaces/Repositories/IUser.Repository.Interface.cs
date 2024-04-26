
using Domain.Dtos;

namespace Infrastructure.Interfaces.Repository{
    public interface IUserRepository{
        
        List<UserDto> GetUsers();

    }
}

using Domain.Dtos;

namespace Infractructure.Interfaces.Repository{
    public interface IUserRepository{
        
        List<UserDto> GetUsers();

    }
}
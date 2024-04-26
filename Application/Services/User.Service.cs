

using Application.Interfaces;
using Domain.Dtos;
using Infractructure.Interfaces.Repository;

namespace Application.Services
{
    public class UserService : IUserService
    {
        IUserRepository _userRepository;
        public UserService( IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public List<UserDto> GetUsers()
        {
            List<UserDto> users = new List<UserDto>();
            try
            {
                users = _userRepository.GetUsers();
                return users;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
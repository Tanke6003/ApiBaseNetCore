
using ApiBaseNetCore.Domain.Dtos;
using ApiBaseNetCore.Domain.Interfaces.Repository;
using ApiBaseNetCore.Domain.Interfaces.Services;




namespace ApiBaseNetCore.Application.Services
{
    public class UserService : IUserService
    {
        IUserRepository _userRepository;
        public UserService( IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public List<UserDto> GetUsers()
        {   string exceptionMessage = string.Empty;
            List<UserDto> users = new List<UserDto>();
            try
            {
                users = _userRepository.GetUsers(out exceptionMessage);
                if (exceptionMessage != "")
                    throw new Exception(exceptionMessage);
                return users;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
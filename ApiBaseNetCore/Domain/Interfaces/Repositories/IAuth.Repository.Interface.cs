
namespace ApiBaseNetCore.Domain.Interfaces.Repositories
{
    public interface IAuthRepository
    {
        public bool Authenticate(string username, string password, out string exceptionMessage);

        public string  Login(string username, string password, out string exceptionMessage);




        
    }
}
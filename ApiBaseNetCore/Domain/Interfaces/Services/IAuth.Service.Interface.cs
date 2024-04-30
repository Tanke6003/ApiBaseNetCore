
namespace ApiBaseNetCore.Domain.Interfaces.Services
{
    public interface IAuthService
    {
        string Login(string username, string password, out string exceptionMessage);
    }
}
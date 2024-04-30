

using ApiBaseNetCore.Domain.Interfaces.Repositories;
using ApiBaseNetCore.Domain.Interfaces.Services;

namespace ApiBaseNetCore.Application.Services
{
    public class AuthService : IAuthService
    {
        private IAuthRepository _authRepository;
        public AuthService(Infrastructure.Interfaces.plugins.IEnvs envs, IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public string Login(string username, string password, out string exceptionMessage)
        {
            return _authRepository.Login(username, password, out exceptionMessage);
        }
    }
}

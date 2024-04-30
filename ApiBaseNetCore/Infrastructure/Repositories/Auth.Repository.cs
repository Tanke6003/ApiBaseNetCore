

using ApiBaseNetCore.Domain.Dtos;
using ApiBaseNetCore.Domain.Interfaces.Plugins;
using ApiBaseNetCore.Domain.Interfaces.Repositories;
using ApiBaseNetCore.Infrastructure.Interfaces;

namespace ApiBaseNetCore.Infrastructure.Repository{

    public class AuthRepository:IAuthRepository{

        private IJwt _jwt;
        private IDirectoryService _directoryService;
        public AuthRepository(IJwt jwt, IDirectoryService directoryService)
        {
            _jwt = jwt;
            _directoryService = directoryService;
        }

        public bool Authenticate(string username, string password, out string exceptionMessage){
            exceptionMessage = "";
            try{

                if(_directoryService.Authenticate(username, password)){
                    return true;
                }
                else{
                    exceptionMessage = "Usuario no registrado en el directorio activo";
                    return false;
                }
            }
            catch(Exception ex){
                exceptionMessage = ex.Message;
                return false;
            }
        }

        public string Login(string username, string password, out string exceptionMessage){
            exceptionMessage = "";
            try{
                if(Authenticate(username, password, out exceptionMessage))
                {
                    JWTOptionsDto jwtOptions =  new JWTOptionsDto();
                    jwtOptions.NTUser = username;
                    jwtOptions.UserId = 1;
                    jwtOptions.RoleId = 1;
                    jwtOptions.ExpireDate = DateTime.Now.AddDays(1);

                    return _jwt.GenerateToken(jwtOptions);
                }
                if(exceptionMessage!="")
                    throw new Exception(exceptionMessage);
                return null;
            }
            catch(Exception ex){
                exceptionMessage = ex.Message;
                return null;
            }
        }
        
    }
}
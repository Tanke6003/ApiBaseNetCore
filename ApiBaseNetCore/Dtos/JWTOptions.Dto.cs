

namespace Domain.Dtos
{
    public class JWTOptionsDto
    {
        public int UserId {get;set;}
        public string NTUser {get;set;} = string.Empty;
        public int RoleId {get;set;}
        public string SecretKey {get;set;} = string.Empty;
        public DateTime ExpireDate {get;set;}
    }
}
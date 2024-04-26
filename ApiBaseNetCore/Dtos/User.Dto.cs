
namespace Domain.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        
        public string NtUser { get; set; }
        public string FullName { get; set; }
        public bool Available { get; set; }
        public string Email { get; set; }

        public DateTime LastUpdate { get; set; }
        public int  LastUpdateBy { get; set; }

        public int RoleId { get; set; }

    }
}
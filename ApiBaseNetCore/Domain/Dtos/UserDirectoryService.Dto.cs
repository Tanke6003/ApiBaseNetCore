
namespace ApiBaseNetCore.Domain.Dtos
{
    public class UserDirectoryServiceDto
    {
        public int EmployeeNumber { get; set; }  //employeenumber
        public string NtUser { get; set; } = ""; //samaccountname
        public string FullName { get; set; } = ""; //extensionattribute14
        public string Email { get; set; }  = ""; //mail
        

    }
}
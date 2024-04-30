
using ApiBaseNetCore.Domain.Dtos;

namespace ApiBaseNetCore.Domain.Interfaces.Plugins
{
    public interface IDirectoryService
    {
        bool Authenticate(string username, string password);

        UserDirectoryServiceDto GetUserByNtUser(string ntUser);

        UserDirectoryServiceDto GetUserByEmployeeNumber(int employeeNumber);

        UserDirectoryServiceDto GetUserByEmail(string email);

    }
}
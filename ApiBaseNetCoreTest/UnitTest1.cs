
using ApiBaseNetCoreTest.common;
using Infrastructure.Interfaces;
using Infrastructure.Interfaces.Repository;
using Infractructure.Repository;
using Infrastructure.Plugins;
using Xunit;

namespace ApiBaseNetCoreTest;

public class UnitTestUserRepository
{
    [Fact]
    public void ShouldReturnUsersList()
    {
        // Arrange
        IConnectionDB _connectionDB = connectionUtil.moqConnection();
        IUserRepository _userRepository = new UserRepository(_connectionDB);

        

        // Act
        

        // Assert

    }
}
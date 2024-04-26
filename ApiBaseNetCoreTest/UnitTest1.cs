
using ApiBaseNetCoreTest.common;
using ApiBaseNetCore.Infrastructure.Interfaces;
using ApiBaseNetCore.Infrastructure.Interfaces.plugins;
using Xunit;
using ApiBaseNetCore.Infrastructure.Interfaces.Repository;
using Moq;
using Domain.Dtos;
namespace ApiBaseNetCoreTest;

public class UnitTestUserRepository
{
    [Fact]
    public void ShouldReturnUsersList()
    {
        // Arrange
        var _connectionDB = connectionUtil.moqConnection().Object;
        //IUserRepository _userRepository = new ApiBaseNetCore.Infrastructure.Repository.UserRepository(_connectionDB);

        var mockRepository = new Mock<IUserRepository>();
    
        mockRepository.Setup(x => x.GetUsers()).Returns(new List<UserDto>());
        // Act
        
        var result = mockRepository.Object.GetUsers();

        // Assert

        Assert.NotNull(result);
        Assert.IsType<List<UserDto>>(result);

    }
}
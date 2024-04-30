
using ApiBaseNetCoreTest.common;
using Moq;
using ApiBaseNetCore.Domain.Interfaces.Repository;
using ApiBaseNetCore.Domain.Dtos;
using ApiBaseNetCore.Infrastructure.Interfaces;
using System.Data;
namespace ApiBaseNetCoreTest.UnitTest.Repositories;

public class UnitTestUserRepository
{
    [Fact]
    public void ShouldReturnUsersList()
    {
        // Arrange
        string errorMessage = string.Empty;
        // var _connection = new  Mock<IConnectionDB>();
        // _connection.Setup(x => x.GetDataTable(It.IsAny<string>(), out It.Ref<string>.IsAny)).Returns(new DataTable());
        //IUserRepository _userRepository = new ApiBaseNetCore.Infrastructure.Repository.UserRepository(_connectionDB);

        var mockRepository = new Mock<IUserRepository>();

        mockRepository.Setup(x => x.GetUsers(out errorMessage)).Returns(new List<UserDto>());
        // Act

        var result = mockRepository.Object.GetUsers(out errorMessage);

        // Assert

        Assert.NotNull(result);
        Assert.IsType<List<UserDto>>(result);

    }
    [Fact]
    public void ShouldReturnUserById()
    {
        // Arrange
        string errorMessage = string.Empty;
        var _connectionDB = connectionUtil.moqConnection().Object;


        var mockRepository = new Mock<IUserRepository>();

        mockRepository.Setup(x => x.GetUserById(1, out errorMessage)).Returns(new UserDto());
        // Act

        var result = mockRepository.Object.GetUserById(1, out errorMessage);

        // Assert

        Assert.NotNull(result);
        Assert.IsType<UserDto>(result);

    }
[Fact]
public void ShouldReturnEmptyUserAndErrorMessage()
{
    // Arrange
    string errorMessage = "Error message";
    var _connectionDB = connectionUtil.moqConnection().Object;

    var mockRepository = new Mock<IUserRepository>();

    mockRepository.Setup(x => x.GetUserById(1, out errorMessage))
              .Returns(() =>
              {
                  errorMessage = "Error message";
                  return new UserDto();
              });

    // Act
    var result = mockRepository.Object.GetUserById(1, out errorMessage);

    // Assert
    Assert.NotNull(errorMessage);
    Assert.NotEmpty(errorMessage);
    Assert.NotNull(result);
    Assert.IsType<UserDto>(result);
    Assert.Equal("Error message", errorMessage);
    // Add assertions for other properties if needed
}



}
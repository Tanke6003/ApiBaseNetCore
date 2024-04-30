


using ApiBaseNetCore.Domain.Dtos;
using ApiBaseNetCore.Infrastructure.Interfaces;
using Moq;

namespace ApiBaseNetCoreTest.UnitTest.Plugins{

    public class UnitTestJwtPlugin
    {
        [Fact]
        public void ShouldReturnToken()
        {
            // Arrange
            var _jwt = new Mock<IJwt>();
            _jwt.Setup(x => x.GenerateToken(It.IsAny<JWTOptionsDto>())).Returns("token");

           

            // Act
            
            var result = _jwt.Object.GenerateToken(new JWTOptionsDto());
            // Assert


            Assert.NotNull(result);
            Assert.IsType<string>(result);


          
        }
        [Fact]
        public void ShouldReturnAnObjectTypeJwtOptionsDto()
        {
            // Arrange
            var _jwt = new Mock<IJwt>();
            _jwt.Setup(x => x.DecodeToken(It.IsAny<string>())).Returns(new JWTOptionsDto());
        
            // Act
            var result = _jwt.Object.DecodeToken("token");

            // Assert

            Assert.NotNull(result);
            Assert.IsType<JWTOptionsDto>(result);


        }
    }
}
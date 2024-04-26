using Moq;
using System.Data;
using ApiBaseNetCore.Infrastructure.Interfaces;
namespace ApiBaseNetCoreTest.common
{
    public static class connectionUtil
    {
        public static Mock<IConnectionDB> moqConnection(){
            var mock = new Mock<IConnectionDB>();

        
        // Comportamiento para el método GetDataTable
        mock.Setup(m => m.GetDataTable(It.IsAny<string>(), out It.Ref<string>.IsAny))
            .Returns(new DataTable());
        

        return mock;

    }
    }

}
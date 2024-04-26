using Moq;
using System.Data;
namespace ApiBaseNetCoreTest.common
{
    public static class connectionUtil
    {
        public static Mock<ICp> moqConnection(){
            var mock = new Mock<Infrastructure.Interfaces.IConnectionDB>();

        // Comportamiento para el método GetDataTable
        mock.Setup(m => m.GetDataTable(It.IsAny<string>(), out It.Ref<string>.IsAny))
            .Returns(new DataTable());
        

        return mock;

    }
    }

}
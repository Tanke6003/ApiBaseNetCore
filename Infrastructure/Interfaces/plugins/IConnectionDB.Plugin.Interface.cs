using System.Data;

namespace Infractructure.Interfaces
{
    public interface IConnectionDB
    {
        DataTable GetDataTable(string query,out string ExceptionMessage);

        DataSet GetDataSet(string query,out string ExceptionMessage);
        

    }
}
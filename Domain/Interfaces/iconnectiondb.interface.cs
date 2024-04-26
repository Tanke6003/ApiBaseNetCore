using System.Data;

namespace Domain.Interfaces
{
    public interface IConnectionDB
    {
        DataTable GetDataTable(string query,out string ExceptionMessage);

        DataSet GetDataSet(string query,out string ExceptionMessage);
        

    }
}
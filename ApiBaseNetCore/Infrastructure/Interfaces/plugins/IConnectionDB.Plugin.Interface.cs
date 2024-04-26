using System.Data;
using Microsoft.Data.SqlClient;

namespace Infrastructure.Interfaces
{
    public interface IConnectionDB
    {
        DataTable GetDataTable(string query,out string ExceptionMessage);

        DataSet GetDataSet(string query,out string ExceptionMessage);
        
        DataTable ExecDataTable(string query,out string ExceptionMessage);
        DataTable ExecDataTable(string query, SqlParameter[] parameters, out string ExceptionMessage);

    }
}
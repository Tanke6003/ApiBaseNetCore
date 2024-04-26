using System.Data;
using Infractructure.Interfaces;
using Microsoft.Data.SqlClient;


namespace Infractructure.Plugins
{

    public class MsSqlConnectionDB : IConnectionDB
    {
        private readonly string connectionString = "Server=.;Database=MyDB;Trusted_Connection=True;";
        private SqlConnection connection;

        public MsSqlConnectionDB(string connectionString)
        {
            this.connectionString = connectionString;
            connection = new SqlConnection(this.connectionString);
        }
        public DataTable GetDataTable(string query, out string ExceptionMessage)
        {
            DataTable dt = new DataTable();
            ExceptionMessage = string.Empty;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandTimeout = 120;
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            }
            catch (System.Exception ex)
            {
                ExceptionMessage = ex.Message;
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
        public DataSet GetDataSet(string query, out string ExceptionMessage)
        {
            DataSet ds = new DataSet();
            ExceptionMessage = string.Empty;
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandTimeout = 120;
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(ds);
            }
            catch (System.Exception ex)
            {
                ExceptionMessage = ex.Message;
            }
            finally
            {
                connection.Close();
            }
            return ds;
        }
    }
}
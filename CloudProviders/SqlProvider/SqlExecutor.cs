using System.Data;
using System.Data.SqlClient;

namespace Ebersoft.CloudProviders.SqlProvider;

public class SqlExecutor : ISqlExecutor
{
    private readonly string _connectionString;
    
    public SqlExecutor(string server, string database, string userId, string password)
    {
        _connectionString = string.Format(Constants.ConnectionStringFormat, server, database, userId, password);
    }

    public async Task<int> ExecuteNonQueryAsync(string query)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            using (var command = new SqlCommand(query, connection))
            {
                await connection.OpenAsync();
                return await command.ExecuteNonQueryAsync();
            }
        }
    }

    public async Task<DataTable> ExecuteQueryAsync(string query)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            using (var command = new SqlCommand(query, connection))
            {
                await connection.OpenAsync();
                var dataTable = new DataTable();
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    dataTable.Load(reader);
                }
                return dataTable;
            }
        }
    }
}
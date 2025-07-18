namespace LojaDeBrinquedos.API.Models;

public class DateBaseConexão(IConfiguration configuration)
{
    private readonly string _connectionString = configuration.GetConnectionString("DefaultConnection");

    public SqlConnection GetConnection()
    {
        return new SqlConnection(_connectionString);
    }
}
}

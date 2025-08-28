using Microsoft.AspNetCore.Connections;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDeBrinquedos.Infrastructure.Data;
public class LojaDbContext
{
    private static readonly string _connectionString =
              "Server=localhost;Port=3306;Database=LojaDeBrinquedos;User Id=root;Password=;";

    public static IDbConnection CreateConnection()
    {
        return new MySqlConnection(_connectionString);
    }

}





    


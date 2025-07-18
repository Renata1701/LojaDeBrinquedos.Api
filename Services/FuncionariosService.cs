using LojaDeBrinquedos.API.Models;
using Microsoft.Data.SqlClient;

namespace LojaDeBrinquedos.API.Services;

public class FuncionariosService
{
    private readonly string _connectionString;

    public FuncionariosService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("MinhaConexaoSQL");
    }

    public async Task<List<Funcionarios>> ListarAsync()
    {
        var funcionarios = new List<Funcionarios>();

        try
        {
            using var conexao = new SqlConnection(_connectionString);
            await conexao.OpenAsync();

            var query = "SELECT Id, Nome, Cargo, Salario FROM Funcionarios";

            using var comando = new SqlCommand(query, conexao);
            using var leitor = await comando.ExecuteReaderAsync();

        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao listar funcionários.", ex);
        }

        return funcionarios;
    }

    public async Task<bool> AdicionarAsync(Funcionarios funcionario)
    {
        try
        {
            using var conexao = new SqlConnection(_connectionString);
            await conexao.OpenAsync();

            var query = "INSERT INTO Funcionarios (Nome, Cargo, Salario) VALUES (@Nome, @Cargo, @Salario)";
            using var comando = new SqlCommand(query, conexao);

            comando.Parameters.AddWithValue("@Nome", funcionario.Nome);
            comando.Parameters.AddWithValue("@Cargo", funcionario.Cargo);
            comando.Parameters.AddWithValue("@Salario", funcionario.Salario);

            int linhasAfetadas = await comando.ExecuteNonQueryAsync();

            return linhasAfetadas > 0;
        }
        catch (Exception)
        {
            return false;
        }
    }
}

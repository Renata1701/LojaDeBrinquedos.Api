using LojaDeBrinquedos.API.Domain.Entities;
using Microsoft.Data.SqlClient;

namespace LojaDeBrinquedos.API.Services;

public class ProgramaFidelidadeService
{
    private readonly string _connectionString;

    public ProgramaFidelidadeService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("MinhaConexaoSQL");
    }

    public async Task<List<ProgramaFidelidade>> ListarAsync()
    {
        var programas = new List<ProgramaFidelidade>();

        try
        {
            using var conexao = new SqlConnection(_connectionString);
            await conexao.OpenAsync();

            var query = "SELECT Id, ClienteId, Pontos, Nivel FROM ProgramaFidelidade";

            using var comando = new SqlCommand(query, conexao);
            using var leitor = await comando.ExecuteReaderAsync();

        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao listar programas de fidelidade.", ex);
        }

        return programas;
    }

    public async Task<bool> AdicionarAsync(ProgramaFidelidade programa)
    {
        try
        {
            using var conexao = new SqlConnection(_connectionString);
            await conexao.OpenAsync();

            var query = "INSERT INTO ProgramaFidelidade (ClienteId, Pontos, Nivel) VALUES (@ClienteId, @Pontos, @Nivel)";
            using var comando = new SqlCommand(query, conexao);

            comando.Parameters.AddWithValue("@ClienteId", programa.ClienteId);
            comando.Parameters.AddWithValue("@Pontos", programa.Pontos);
            comando.Parameters.AddWithValue("@Nivel", programa.Nivel);

            int linhasAfetadas = await comando.ExecuteNonQueryAsync();

            return linhasAfetadas > 0;
        }
        catch (Exception)
        {
            return false;
        }
    }
}

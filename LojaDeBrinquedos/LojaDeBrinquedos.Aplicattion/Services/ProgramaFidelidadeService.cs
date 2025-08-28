using LojaDeBrinquedos.Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace LojaDeBrinquedos.API.Services;

public class ProgramaFidelidadeService
{
    private readonly string _connectionString;

    public ProgramaFidelidadeService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("MinhaConexaoSQL") ?? string.Empty;
    }

    public async Task<List<ProgramaFidelidade>> ListarAsync()
    {
        var programas = new List<ProgramaFidelidade>();

        try
        {
            using var conexao = new SqlConnection(_connectionString);
            await conexao.OpenAsync();

            var query = "SELECT Id, ClienteId, Pontos, Nivel, DataCadastro, Nome, Descricao, PontosNecessarios FROM ProgramaFidelidade";

            using var comando = new SqlCommand(query, conexao);
            using var leitor = await comando.ExecuteReaderAsync();

            while (await leitor.ReadAsync())
            {
                programas.Add(new ProgramaFidelidade
                {
                    Id = leitor.GetInt32(0),
                    ClienteId = leitor.GetInt32(1),
                    Pontos = leitor.GetInt32(2),
                    Nivel = leitor.GetString(3),
                    DataCadastro = leitor.GetDateTime(4),
                    Nome = leitor.GetString(5),
                    Descricao = leitor.GetString(6),
                    PontosNecessarios = leitor.GetInt32(7)
                });
            }
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

            var query = "INSERT INTO ProgramaFidelidade (ClienteId, Pontos, Nivel, DataCadastro, Nome, Descricao, PontosNecessarios) VALUES (@ClienteId, @Pontos, @Nivel, @DataCadastro, @Nome, @Descricao, @PontosNecessarios)";
            using var comando = new SqlCommand(query, conexao);

            comando.Parameters.AddWithValue("@ClienteId", programa.ClienteId);
            comando.Parameters.AddWithValue("@Pontos", programa.Pontos);
            comando.Parameters.AddWithValue("@Nivel", programa.Nivel);
            comando.Parameters.AddWithValue("@DataCadastro", programa.DataCadastro);
            comando.Parameters.AddWithValue("@Nome", programa.Nome);
            comando.Parameters.AddWithValue("@Descricao", programa.Descricao);
            comando.Parameters.AddWithValue("@PontosNecessarios", programa.PontosNecessarios);

            int linhasAfetadas = await comando.ExecuteNonQueryAsync();

            return linhasAfetadas > 0;
        }
        catch (Exception)
        {
            return false;
        }
    }
}

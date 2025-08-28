using LojaDeBrinquedos.Aplicattion.Interfaces;
using LojaDeBrinquedos.Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace LojaDeBrinquedos.API.Services;

public class NewLestterService : INewsLetterService
{
    private readonly string _connectionString;

    public NewLestterService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("MinhaConexaoSQL") ?? string.Empty;
    }

    public async Task<IEnumerable<NewsLetter>> ObterTodosNewsLetterAsync()
    {
        var newsletters = new List<NewsLetter>();

        try
        {
            using var conexao = new SqlConnection(_connectionString);
            await conexao.OpenAsync();

            var query = "SELECT Id, Email, DataCadastro, Ativo FROM NewsLetter WHERE Ativo = 1";

            using var comando = new SqlCommand(query, conexao);
            using var leitor = await comando.ExecuteReaderAsync();

            while (await leitor.ReadAsync())
            {
                newsletters.Add(new NewsLetter
                {
                    Id = leitor.GetInt32(0),
                    Email = leitor.GetString(1),
                    DataCadastro = leitor.GetDateTime(2),
                    Ativo = leitor.GetBoolean(3)
                });
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao listar newsletters.", ex);
        }

        return newsletters;
    }

    public async Task<NewsLetter?> ObterNewsLetterPorIdAsync(int id)
    {
        try
        {
            using var conexao = new SqlConnection(_connectionString);
            await conexao.OpenAsync();

            var query = "SELECT Id, Email, DataCadastro, Ativo FROM NewsLetter WHERE Id = @Id AND Ativo = 1";
            using var comando = new SqlCommand(query, conexao);
            comando.Parameters.AddWithValue("@Id", id);

            using var leitor = await comando.ExecuteReaderAsync();

            if (await leitor.ReadAsync())
            {
                return new NewsLetter
                {
                    Id = leitor.GetInt32(0),
                    Email = leitor.GetString(1),
                    DataCadastro = leitor.GetDateTime(2),
                    Ativo = leitor.GetBoolean(3)
                };
            }

            return null;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao obter newsletter com ID {id}.", ex);
        }
    }

    public async Task<bool> AdicionarNewsLetterAsync(NewsLetter newsLetter)
    {
        try
        {
            using var conexao = new SqlConnection(_connectionString);
            await conexao.OpenAsync();

            var query = "INSERT INTO NewsLetter (Email, DataCadastro, Ativo) VALUES (@Email, @DataCadastro, @Ativo)";
            using var comando = new SqlCommand(query, conexao);

            comando.Parameters.AddWithValue("@Email", newsLetter.Email);
            comando.Parameters.AddWithValue("@DataCadastro", newsLetter.DataCadastro);
            comando.Parameters.AddWithValue("@Ativo", newsLetter.Ativo);

            int linhasAfetadas = await comando.ExecuteNonQueryAsync();

            return linhasAfetadas > 0;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<bool> AtualizarNewsLetterAsync(NewsLetter newsLetter)
    {
        try
        {
            using var conexao = new SqlConnection(_connectionString);
            await conexao.OpenAsync();

            var query = "UPDATE NewsLetter SET Email = @Email, Ativo = @Ativo WHERE Id = @Id";
            using var comando = new SqlCommand(query, conexao);

            comando.Parameters.AddWithValue("@Id", newsLetter.Id);
            comando.Parameters.AddWithValue("@Email", newsLetter.Email);
            comando.Parameters.AddWithValue("@Ativo", newsLetter.Ativo);

            int linhasAfetadas = await comando.ExecuteNonQueryAsync();

            return linhasAfetadas > 0;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<bool> RemoverNewsLetterAsync(int id)
    {
        try
        {
            using var conexao = new SqlConnection(_connectionString);
            await conexao.OpenAsync();

            var query = "UPDATE NewsLetter SET Ativo = 0 WHERE Id = @Id";
            using var comando = new SqlCommand(query, conexao);

            comando.Parameters.AddWithValue("@Id", id);

            int linhasAfetadas = await comando.ExecuteNonQueryAsync();

            return linhasAfetadas > 0;
        }
        catch (Exception)
        {
            return false;
        }
    }
}

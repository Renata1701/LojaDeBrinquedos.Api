using LojaDeBrinquedos.Aplicattion.Interfaces;
using LojaDeBrinquedos.Domain.Entities;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace LojaDeBrinquedos.API.Services;

public class NewLestterService : INewsLetterService
{
    private readonly string _connectionString = Configuration.ConnectionString("MinhaConexaoSQL");

    public async Task<List<INewsLetterService>> ListarAsync()
    {
        var newsletters = new List<INewsLetterService>();

        try
        {
            using var conexao = new SqlConnection(_connectionString);
            await conexao.OpenAsync();

            var query = "SELECT Id, Email FROM NewsLetter";

            using var comando = new SqlCommand(query, conexao);
            using var leitor = await comando.ExecuteReaderAsync();

        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao listar newsletters.", ex);
        }

        return newsletters;
    }

    public async Task<bool> AdicionarAsync(INewsLetterService newsletter)
    {
        try
        {
            using var conexao = new SqlConnection(_connectionString);
            await conexao.OpenAsync();

            var query = "INSERT INTO NewsLetter (Email) VALUES (@Email)";
            using var comando = new SqlCommand(query, conexao);

            int linhasAfetadas = await comando.ExecuteNonQueryAsync();

            return linhasAfetadas > 0;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public IEnumerable<INewsLetterService> ObterTodosClientes()
    {
        throw new NotImplementedException();
    }

    public Cliente ObterClientePorId(int id)
    {
        throw new NotImplementedException();
    }

    public void AdicionarCliente(Cliente cliente)
    {
        throw new NotImplementedException();
    }

    public void AtualizarCliente(Cliente cliente)
    {
        throw new NotImplementedException();
    }

    public void RemoverCliente(int id)
    {
        throw new NotImplementedException();
    }

    IEnumerable<NewsLe> INewsLetterService.ObterTodosClientes()
    {
        throw new NotImplementedException();
    }
}

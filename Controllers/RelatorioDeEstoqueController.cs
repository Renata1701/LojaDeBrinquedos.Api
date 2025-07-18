using LojaDeBrinquedos.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace LojaDeBrinquedos.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RelatorioDeEstoqueController : ControllerBase
{
    private readonly string _connectionString = "Server=Natalli_i5;Database=LojaDeBrinquedos;Trusted_Connection=True;";

    [HttpGet]
    public IActionResult GetRelatorioEstoque()
    {
        var relatorio = new List<RelatorioDeEstoque();

        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        string query = @"
                SELECT Id, Nome, Quantidade, Preco
                FROM Produto
                ORDER BY Nome
            ";

        using var command = new SqlCommand(query, connection);
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            var dto = new RelatorioDeEstoque()

            {
                ProdutoId = reader.GetInt32(0),
                Nome = reader.GetString(1),
                Quantidade = reader.GetInt32(2),
                Preco = reader.GetDecimal(3),
                ValorTotalVendido = reader.GetInt32(2) * reader.GetDecimal(3)
            };

            relatorio.Add(dto);
        }

        return Ok(relatorio);
    }

}


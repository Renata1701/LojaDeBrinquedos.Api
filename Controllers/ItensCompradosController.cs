using LojaDeBrinquedos.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace LojaDeBrinquedos.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ItensCompradosController : ControllerBase
{
    private readonly string _connectionString = "Server=Natalli_i5;Database=LojaDeBrinquedos;Trusted_Connection=True;\r\n";

    [HttpGet]
    public IActionResult Get()
    {
        var itens = new List<object>();

        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        string query = "SELECT Id, CompraEstoqueId, ProdutoId, Quantidade, PrecoUnitario FROM ItemCompra";

        using var command = new SqlCommand(query, connection);
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            itens.Add(new
            {
                Id = reader.GetInt32(0),
                CompraEstoqueId = reader.GetInt32(1),
                ProdutoId = reader.GetInt32(2),
                Quantidade = reader.GetInt32(3),
                PrecoUnitario = reader.GetDecimal(4)
            });
        }

        return Ok(itens);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        string query = "SELECT Id, CompraEstoqueId, ProdutoId, Quantidade, PrecoUnitario FROM ItemCompra WHERE Id = @Id";
        using var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Id", id);
        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            var item = new
            {
                Id = reader.GetInt32(0),
                CompraEstoqueId = reader.GetInt32(1),
                ProdutoId = reader.GetInt32(2),
                Quantidade = reader.GetInt32(3),
                PrecoUnitario = reader.GetDecimal(4)
            };
            return Ok(item);
        }
        return NotFound();
    }
    [HttpPost]

    public IActionResult Post([FromBody] ItensComprados item)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        string query = "INSERT INTO ItemCompra (CompraEstoqueId, ProdutoId, Quantidade, PrecoUnitario) OUTPUT INSERTED.Id VALUES (@CompraEstoqueId, @ProdutoId, @Quantidade, @PrecoUnitario)";
        using var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@CompraEstoqueId", item.CompraEstoqueId);
        command.Parameters.AddWithValue("@ProdutoId", item.ProdutoId);
        command.Parameters.AddWithValue("@Quantidade", item.Quantidade);
        command.Parameters.AddWithValue("@PrecoUnitario", item.PrecoUnitario);
        item.Id = (int)command.ExecuteScalar();
        return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
    }
    [HttpPut("{id}")]

    public IActionResult Put(int id, [FromBody] ItensComprados item)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        string query = "UPDATE ItemCompra SET CompraEstoqueId = @CompraEstoqueId, ProdutoId = @ProdutoId, Quantidade = @Quantidade, PrecoUnitario = @PrecoUnitario WHERE Id = @Id";
        using var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Id", id);
        command.Parameters.AddWithValue("@CompraEstoqueId", item.CompraEstoqueId);
        command.Parameters.AddWithValue("@ProdutoId", item.ProdutoId);
        command.Parameters.AddWithValue("@Quantidade", item.Quantidade);
        command.Parameters.AddWithValue("@PrecoUnitario", item.PrecoUnitario);
        int rowsAffected = command.ExecuteNonQuery();
        if (rowsAffected == 0) return NotFound();
        return NoContent();
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        string query = "DELETE FROM ItemCompra WHERE Id = @Id";
        using var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Id", id);
        int rowsAffected = command.ExecuteNonQuery();
        if (rowsAffected == 0) return NotFound();
        return NoContent();

    }

}


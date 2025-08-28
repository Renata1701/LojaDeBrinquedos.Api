using LojaDeBrinquedos.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace LojaDeBrinquedos.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EstoqueController : ControllerBase
{
    private static List<Estoque> estoques = new();
    private string? _connectionString;

    public EstoqueController(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("MinhaConexaoSQL");
    }
   
    

    [HttpGet]
    public IActionResult Get()
    {
        var estoques = new List<object>();

        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        // Supondo que a tabela estoque tenha Id, ProdutoId, Quantidade
        string query = "SELECT Id, ProdutoId, Quantidade FROM Estoque";

        using var command = new SqlCommand(query, connection);
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            estoques.Add(new
            {
                Id = reader.GetInt32(0),
                ProdutoId = reader.GetInt32(1),
                Quantidade = reader.GetInt32(2)
            });
        }

        return Ok(estoques);
    }

    [HttpPost]
    public IActionResult Create(Estoque estoque)
    {
        estoque.Id = estoques.Count > 0 ? estoques.Max(e => e.Id) + 1 : 1;
        estoques.Add(estoque);
        return CreatedAtAction(nameof(Get), new { id = estoque.Id }, estoque);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Estoque updated)
    {
        var estoque = estoques.FirstOrDefault(e => e.Id == id);
        if (estoque == null) return NotFound();

        estoque.ProdutoId = updated.ProdutoId;
        estoque.Quantidade = updated.Quantidade;
        estoque.Localizacao = updated.Localizacao;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var estoque = estoques.FirstOrDefault(e => e.Id == id);
        if (estoque == null) return NotFound();

        estoques.Remove(estoque);
        return NoContent();
    }
}






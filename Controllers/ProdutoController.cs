using LojaDeBrinquedos.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace LojaDeBrinquedos.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProdutoController : ControllerBase
{
    private static List<Produto> produtos = new();
    private string? _connectionString;

    public ProdutoController(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("MinhaConexaoSQL");
    }

    [HttpGet]
    public IActionResult Get()
    {
        var produtos = new List<object>();

        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        string query = "SELECT Id, Nome, Quantidade, Preco FROM Produto";

        using var command = new SqlCommand(query, connection);
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            produtos.Add(new
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1),
                Quantidade = reader.GetInt32(2),
                Preco = reader.GetDecimal(3)
            });
        }

        return Ok(produtos);
    }

    [HttpGet("{id}")]
    public ActionResult<Produto> Get(int id)
    {
        var produto = produtos.FirstOrDefault(p => p.Id == id);
        if (produto == null) return NotFound();
        return Ok(produto);
    }

    [HttpPost]
    public ActionResult<Produto> Post([FromBody] Produto produto)
    {
        produto.Id = produtos.Count > 0 ? produtos.Max(p => p.Id) + 1 : 1;
        produtos.Add(produto);
        return CreatedAtAction(nameof(Get), new { id = produto.Id }, produto);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Produto atualizado)
    {
        var produto = produtos.FirstOrDefault(p => p.Id == id);
        if (produto == null) return NotFound();

        produto.Nome = atualizado.Nome;
        produto.Descricao = atualizado.Descricao;
        produto.Preco = atualizado.Preco;
        produto.Estoque = atualizado.Estoque;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var produto = produtos.FirstOrDefault(p => p.Id == id);
        if (produto == null) return NotFound();

        produtos.Remove(produto);
        return NoContent();
    }
}

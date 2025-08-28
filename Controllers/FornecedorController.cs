using LojaDeBrinquedos.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace LojaDeBrinquedos.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class FornecedorController : ControllerBase
{
    private static List<Fornecedor> fornecedores = new();
    private string? _connectionString;

    public FornecedorController(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("MinhaConexaoSQL");
    }

    [HttpGet]
    public IActionResult Get()
    {
        var fornecedores = new List<object>();

        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        string query = "SELECT Id, Nome, CNPJ FROM Fornecedor";

        using var command = new SqlCommand(query, connection);
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            fornecedores.Add(new
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1),
                CNPJ = reader.GetString(2)
            });
        }

        return Ok(fornecedores);
    }


    [HttpGet("{id}")]
    public ActionResult<Fornecedor> Get(int id)
    {
        var fornecedor = fornecedores.FirstOrDefault(f => f.Id == id);
        if (fornecedor == null) return NotFound();
        return Ok(fornecedor);
    }

    [HttpPost]
    public ActionResult<Fornecedor> Post([FromBody] Fornecedor fornecedor)
    {
        fornecedor.Id = fornecedores.Count > 0 ? fornecedores.Max(f => f.Id) + 1 : 1;
        fornecedores.Add(fornecedor);
        return CreatedAtAction(nameof(Get), new { id = fornecedor.Id }, fornecedor);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Fornecedor atualizado)
    {
        var fornecedor = fornecedores.FirstOrDefault(f => f.Id == id);
        if (fornecedor == null) return NotFound();

        fornecedor.Nome = atualizado.Nome;
        fornecedor.Cnpj = atualizado.Cnpj;
        fornecedor.Email = atualizado.Email;
        fornecedor.Telefone = atualizado.Telefone;
        fornecedor.Endereco = atualizado.Endereco;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var fornecedor = fornecedores.FirstOrDefault(f => f.Id == id);
        if (fornecedor == null) return NotFound();

        fornecedores.Remove(fornecedor);
        return NoContent();
    }
}

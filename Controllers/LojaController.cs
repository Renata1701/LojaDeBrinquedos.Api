using LojaDeBrinquedos.API.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace LojaDeBrinquedos.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LojaController : ControllerBase
{
    private static List<Loja> lojas = new();
    private string? _connectionString;

    public LojaController(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("MinhaConexaoSQL");
    }

    [HttpGet]
    public IActionResult Get()
    {
        var lojas = new List<object>();

        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        string query = "SELECT Id, Nome, Endereco FROM Loja";

        using var command = new SqlCommand(query, connection);
        using var reader = command.ExecuteReader();
        
        while (reader.Read())
        {
            lojas.Add(new
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1),
                Endereco = reader.GetString(2)
            });
        }

        return Ok(lojas);
    }


    [HttpGet("{id}")]
    public ActionResult<Loja> Get(int id)
    {
        var loja = lojas.FirstOrDefault(l => l.Id == id);
        return loja == null ? NotFound() : Ok(loja);
    }

    [HttpPost]
    public ActionResult<Loja> Post([FromBody] Loja loja)
    {
        loja.Id = lojas.Count > 0 ? lojas.Max(l => l.Id) + 1 : 1;
        lojas.Add(loja);
        return CreatedAtAction(nameof(Get), new { id = loja.Id }, loja);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Loja loja)
    {
        var existente = lojas.FirstOrDefault(l => l.Id == id);
        if (existente == null) return NotFound();

        existente.Nome = loja.Nome;
        existente.Cnpj = loja.Cnpj;
        existente.Endereco = loja.Endereco;
        existente.Telefone = loja.Telefone;
        existente.Responsavel = loja.Responsavel;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var loja = lojas.FirstOrDefault(l => l.Id == id);
        if (loja == null) return NotFound();
        lojas.Remove(loja);
        return NoContent();
    }
}

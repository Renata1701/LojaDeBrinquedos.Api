using LojaDeBrinquedos.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Numerics;

namespace LojaDeBrinquedos.API.Controllers;
[Route("api/[controller]")]
[ApiController]

public class ClienteController : ControllerBase
{
    private static List<Cliente> clientes = new();
    private string? _connectionString;

    public ClienteController(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("MinhaConexaoSQL");
    }

    [HttpGet]
    public IActionResult Get()
    {
        var clientes = new List<object>();

        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        string query = "SELECT Id, Nome, Email FROM Cliente";

        using var command = new SqlCommand(query, connection);
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            clientes.Add(new
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1),
                Email = reader.GetString(2)
            });
        }

        return Ok(clientes);
    }

    [HttpGet("{id}")]
    public ActionResult<Cliente> Get(int id)
    {
        var cliente = clientes.FirstOrDefault(c => c.Id == id);
        if (cliente == null) return NotFound();
        return Ok(cliente);
    }

    [HttpPost]
    public ActionResult<Cliente> Post([FromBody] Cliente cliente)
    {
        cliente.Id = clientes.Count > 0 ? clientes.Max(c => c.Id) + 1 : 1;
        cliente.DataCadastro = DateTime.Now;
        clientes.Add(cliente);
        return CreatedAtAction(nameof(Get), new { id = cliente.Id }, cliente);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Cliente atualizado)
    {
        var cliente = clientes.FirstOrDefault(c => c.Id == id);
        if (cliente == null) return NotFound();

        cliente.Nome = atualizado.Nome;
        cliente.Email = atualizado.Email;
        cliente.CPF = atualizado.CPF;
        cliente.Telefone = atualizado.Telefone;
        cliente.Endereco = atualizado.Endereco;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var cliente = clientes.FirstOrDefault(c => c.Id == id);
        if (cliente == null) return NotFound();

        clientes.Remove(cliente);
        return NoContent();
    }
}

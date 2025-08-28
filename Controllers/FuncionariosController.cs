using LojaDeBrinquedos.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace LojaDeBrinquedos.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class FuncionariosController : ControllerBase
{

    private static List<Funcionarios> funcionarios = new();
    private string? _connectionString;

    public FuncionariosController(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("MinhaConexaoSQL");
    }

    [HttpGet]
    public IActionResult Get()
    {
        var funcionarios = new List<object>();

        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        string query = "SELECT Id, Nome, Cargo FROM Funcionario";

        using var command = new SqlCommand(query, connection);
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            funcionarios.Add(new
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1),
                Cargo = reader.GetString(2)
            });
        }

        return Ok(funcionarios);
    }


    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var f = funcionarios.FirstOrDefault(x => x.Id == id);
        return f == null ? NotFound() : Ok(f);
    }

    [HttpPost]
    public IActionResult Create(Funcionarios funcionario)
    {
        funcionario.Id = funcionarios.Count > 0 ? funcionarios.Max(x => x.Id) + 1 : 1;
        funcionario.DataAdmissao = DateTime.Now;
        funcionarios.Add(funcionario);
        return CreatedAtAction(nameof(Get), new { id = funcionario.Id }, funcionario);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Funcionarios funcionarioAtualizado)
    {
        var f = funcionarios.FirstOrDefault(x => x.Id == id);
        if (f == null) return NotFound();

        f.Nome = funcionarioAtualizado.Nome;
        f.CPF = funcionarioAtualizado.CPF;
        f.Cargo = funcionarioAtualizado.Cargo;
        f.Salario = funcionarioAtualizado.Salario;
        f.Email = funcionarioAtualizado.Email;
        f.Telefone = funcionarioAtualizado.Telefone;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var f = funcionarios.FirstOrDefault(x => x.Id == id);
        if (f == null) return NotFound();

        funcionarios.Remove(f);
        return NoContent();
    }
}


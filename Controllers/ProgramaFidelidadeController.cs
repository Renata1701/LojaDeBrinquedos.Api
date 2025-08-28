using LojaDeBrinquedos.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace LojaDeBrinquedos.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProgramaFidelidadeController : ControllerBase
{
    private string? _connectionString;

    public ProgramaFidelidadeController(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("MinhaConexaoSQL");
    }

    [HttpGet]
    public IActionResult Get()
    {
        var programas = new List<object>();

        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        string query = "SELECT Id, ClienteId, Pontos FROM ProgramaFidelidade";

        using var command = new SqlCommand(query, connection);
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            programas.Add(new
            {
                Id = reader.GetInt32(0),
                ClienteId = reader.GetInt32(1),
                Pontos = reader.GetInt32(2)
            });
        }

        return Ok(programas);
    }


    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        string query = "SELECT Id, ClienteId, Pontos FROM ProgramaFidelidade WHERE Id = @Id";
        using var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Id", id);
        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            var programa = new
            {
                Id = reader.GetInt32(0),
                ClienteId = reader.GetInt32(1),
                Pontos = reader.GetInt32(2)
            };
            return Ok(programa);
        }
        return NotFound();


    }
    [HttpPost]
    public IActionResult Post([FromBody] ProgramaFidelidade modelo)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        string query = "INSERT INTO ProgramaDeFidelidade (Nome, Descricao, PontosNecessarios) VALUES (@Nome, @Descricao, @PontosNecessarios)";

        using var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Nome", modelo.Nome);
        command.Parameters.AddWithValue("@Descricao", modelo.Descricao);
        command.Parameters.AddWithValue("@PontosNecessarios", modelo.PontosNecessarios);

        int linhasAfetadas = command.ExecuteNonQuery();

        if (linhasAfetadas > 0)
            return Ok("Programa de fidelidade criado com sucesso!");
        else
            return BadRequest("Erro ao criar programa de fidelidade.");
    }

    // PUT - Atualizar programa de fidelidade existente
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ProgramaFidelidade model) 
    
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        string query = "UPDATE ProgramaDeFidelidade SET Nome = @Nome, Descricao = @Descricao, PontosNecessarios = @PontosNecessarios WHERE Id = @Id";

        using var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Nome", model.Nome);
        command.Parameters.AddWithValue("@Descricao", model.Descricao);
        command.Parameters.AddWithValue("@PontosNecessarios", model.PontosNecessarios);
        command.Parameters.AddWithValue("@Id", id);

        int linhasAfetadas = command.ExecuteNonQuery();

        if (linhasAfetadas > 0)
            return Ok("Programa de fidelidade atualizado com sucesso!");
        else
            return NotFound("Programa de fidelidade não encontrado.");
    }

    
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        string query = "DELETE FROM ProgramaDeFidelidade WHERE Id = @Id";

        using var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Id", id);

        int linhasAfetadas = command.ExecuteNonQuery();

        if (linhasAfetadas > 0)
            return Ok("Programa de fidelidade excluído com sucesso!");
        else
            return NotFound("Programa de fidelidade não encontrado.");
    }
}










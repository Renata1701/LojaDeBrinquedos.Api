namespace LojaDeBrinquedos.API.Domain.Entities;

public class ProgramaFidelidade
{
    private int v1;
    private string v2;
    private string v3;
    internal object Recompensas;
    internal object PontosNecessarios;
    internal object Nome;
    internal object Descricao;
    internal object Nivel;

    public int Id { get; set; }
    public int ClienteId { get; set; }
    public int Pontos { get; set; }
    public DateTime DataCadastro { get; set; }
    public ProgramaFidelidade(int id, int clienteId, int pontos, DateTime dataCadastro)
    {
        Id = id;
        ClienteId = clienteId;
        Pontos = pontos;
        DataCadastro = dataCadastro;
    }

    public ProgramaFidelidade(int v1, string v2, string v3)
    {
        this.v1 = v1;
        this.v2 = v2;
        this.v3 = v3;
    }

    internal static object? GetAll()
    {
        throw new NotImplementedException();
    }
}

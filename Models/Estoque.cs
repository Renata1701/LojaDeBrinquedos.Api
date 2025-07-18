namespace LojaDeBrinquedos.API.Models;

public class Estoque
{
    internal object Localizacao;

    public int Id { get; set; }
    public int ProdutoId { get; set; }
    public int Quantidade { get; set; }
    public Estoque(int id, int produtoId, int quantidade)
    {
        Id = id;
        ProdutoId = produtoId;
        Quantidade = quantidade;
    }
}
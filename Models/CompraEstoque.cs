namespace LojaDeBrinquedos.API.Models;

public class CompraEstoque
{
    public int Id { get; set; }
    public int FornecedorId { get; set; }
    public int ProdutoId { get; set; }
    public int Quantidade { get; set; }
    public decimal PrecoUnitario { get; set; }
    public DateTime DataCompra { get; set; }

    public CompraEstoque(int id, int fornecedorId, int produtoId, int quantidade, decimal precoUnitario, DateTime dataCompra)
    {
        Id = id;
        FornecedorId = fornecedorId;
        ProdutoId = produtoId;
        Quantidade = quantidade;
        PrecoUnitario = precoUnitario;
        DataCompra = dataCompra;
    }
}





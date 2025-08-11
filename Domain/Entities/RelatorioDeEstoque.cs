namespace LojaDeBrinquedos.API.Domain.Entities;

public class RelatorioDeEstoque(int produtoId, string nomeProduto, decimal preco, int quantidadeEmEstoque, int quantidadeVendida, decimal valorTotalVendido)
{
    internal object? Id;
    internal object? DataAtualizacao;
    internal object DataUltimaAtualizacao;
    internal string Nome;
    internal int Quantidade;

    public RelatorioDeEstoque()
    {
    }

    public int ProdutoId { get; set; } = produtoId;
    public string NomeProduto { get; set; } = nomeProduto;
    public decimal Preco { get; set; } = preco;
    public int QuantidadeEmEstoque { get; set; } = quantidadeEmEstoque;
    public int QuantidadeVendida { get; set; } = quantidadeVendida;
    public decimal ValorTotalVendido { get; set; } = valorTotalVendido;

    
    internal static object? GetAll()
    {
        throw new NotImplementedException();
    }

    internal int Max(Func<object, object> value)
    {
        throw new NotImplementedException();
    }
}

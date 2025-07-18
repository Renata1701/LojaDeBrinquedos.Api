
namespace LojaDeBrinquedos.API.Models;

public class Produto
{
    internal int Quantidade;
    internal string Codigo;
    internal string Categoria;
    internal DateTime DataCadastro;
    internal bool Ativo;

    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public decimal Preco { get; set; }
    public string Imagem { get; set; }
    public int CategoriaId { get; set; }
    public int Estoque { get; set; }
    public Produto(int id, string nome, string descricao, decimal preco, string imagem, int categoriaId, int estoque)
    {
        Id = id;
        Nome = nome;
        Descricao = descricao;
        Preco = preco;
        Imagem = imagem;
        CategoriaId = categoriaId;
        Estoque = estoque;
    }
}

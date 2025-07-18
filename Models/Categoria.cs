namespace LojaDeBrinquedos.API.Models;
public class Categoria
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string Imagem { get; set; }

    public Categoria(int id, string nome, string descricao, string imagem)
    {
        Id = id;
        Nome = nome;
        Descricao = descricao;
        Imagem = imagem;
    }

    public Categoria(int v1, string v2)
    {
    }
}

namespace LojaDeBrinquedos.API.Domain.Entities;
public class CategoriaService
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string Imagem { get; set; }

    public CategoriaService(int id, string nome, string descricao, string imagem)
    {
        Id = id;
        Nome = nome;
        Descricao = descricao;
        Imagem = imagem;
    }

    public CategoriaService(int v1, string v2)
    {
    }
}

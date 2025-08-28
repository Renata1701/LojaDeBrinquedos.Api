namespace LojaDeBrinquedos.API.ResultModel;

public class CategoriaResult
{
    public string Nome { get; set; }

    public string Descricao { get; set; }

    public CategoriaResult(string nome, string descricao)
    {
        nome = Nome;
        Descricao = descricao;
    }
}

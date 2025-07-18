using LojaDeBrinquedos.API.Models;

namespace LojaDeBrinquedos.API.Services;

public class NewLestterService
{
    private readonly List<NewsLetter> _inscritos = new();

    public void Inscrever(NewsLetter pessoa) => _inscritos.Add(pessoa);

    public List<NewsLetter> Listar() => _inscritos;
}

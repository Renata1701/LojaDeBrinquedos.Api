using LojaDeBrinquedos.Domain.Entities;

namespace LojaDeBrinquedos.Aplicattion.Interfaces;

public interface INewsLetterService
{
    Task<IEnumerable<NewsLetter>> ObterTodosNewsLetterAsync();
    Task<NewsLetter?> ObterNewsLetterPorIdAsync(int id);
    Task<bool> AdicionarNewsLetterAsync(NewsLetter newsLetter);
    Task<bool> AtualizarNewsLetterAsync(NewsLetter newsLetter);
    Task<bool> RemoverNewsLetterAsync(int id);
}

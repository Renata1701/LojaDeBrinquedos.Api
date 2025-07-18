using LojaDeBrinquedos.API.Models;

namespace LojaDeBrinquedos.API.Services;

public class ProgramaFidelidadeService
{
    private readonly List<ProgramaFidelidade> _fidelidades = new();

    public void Adicionar(ProgramaFidelidade f) => _fidelidades.Add(f);

    public List<ProgramaFidelidade> Listar() => _fidelidades;
}

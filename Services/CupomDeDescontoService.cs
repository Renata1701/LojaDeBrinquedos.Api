using LojaDeBrinquedos.API.Models;

namespace LojaDeBrinquedos.API.Services;

public class CupomDeDescontoService
{
    private readonly List<CupomDeDesconto> _cupons = new();

    public List<CupomDeDesconto> Listar() => _cupons;

    public void Adicionar(CupomDeDesconto cupom) => _cupons.Add(cupom);
}

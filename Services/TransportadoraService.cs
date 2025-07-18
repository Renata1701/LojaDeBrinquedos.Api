using LojaDeBrinquedos.API.Models;

namespace LojaDeBrinquedos.API.Services;

public class TransportadoraService
{
    private readonly List<Transportadora> _transportadoras = new();

    public List<Transportadora> Listar() => _transportadoras;

    public void Adicionar(Transportadora transportadora) => _transportadoras.Add(transportadora);
}

using LojaDeBrinquedos.API.Models;

namespace LojaDeBrinquedos.API.Services;

public class EntregaService
{
    private readonly List<Entrega> _entregas = new();

    public void RegistrarEntrega(Entrega entrega) => _entregas.Add(entrega);

    public List<Entrega> Listar() => _entregas;
}

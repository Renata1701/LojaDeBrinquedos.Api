using LojaDeBrinquedos.API.Models;

namespace LojaDeBrinquedos.API.Services;

public class ItensCompradosService
{
    private readonly List<ItensComprados> _compras = new();

    public List<ItensComprados> Listar() => _compras;

    public void RegistrarCompra(ItensComprados compra) => _compras.Add(compra);
}


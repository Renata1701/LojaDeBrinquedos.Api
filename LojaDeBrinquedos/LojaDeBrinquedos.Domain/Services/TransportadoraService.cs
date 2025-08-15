using LojaDeBrinquedos.API.Domain.Entities;
using LojaDeBrinquedos.API.Domain.Interfaces;
using Microsoft.Data.SqlClient;

namespace LojaDeBrinquedos.API.Services;

public class TransportadoraService : ITransportadoraService
{
    private readonly string _connectionString;

    public TransportadoraService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("MinhaConexaoSQL");
    }

    private readonly List<Transportadora> _transportadoras;

    public void AdicionarTransportadora(Transportadora transportadora)
    {
        if (transportadora == null)
            throw new ArgumentNullException(nameof(transportadora));

        if (_transportadoras.Any(t => t.Id == transportadora.Id))
            throw new InvalidOperationException("Transportadora já existe.");

        _transportadoras.Add(transportadora);
    }

    public IEnumerable<Transportadora> ObterTodasTransportadoras()
    {
        return _transportadoras;
    }

    public Transportadora ObterTransportadoraPorId(int id)
    {
        return _transportadoras.FirstOrDefault(t => t.Id == id);
    }

    public void AtualizarTransportadora(Transportadora transportadora)
    {
        var existente = ObterTransportadoraPorId(transportadora.Id);
        if (existente == null)
            throw new InvalidOperationException("Transportadora não encontrada.");

        existente.Nome = transportadora.Nome;
        existente.Telefone = transportadora.Telefone;
        
    }

    public void RemoverTransportadora(int id)
    {
        var transportadora = ObterTransportadoraPorId(id);
        if (transportadora == null)
            throw new InvalidOperationException("Transportadora não encontrada.");

        _transportadoras.Remove(transportadora);
    }
}
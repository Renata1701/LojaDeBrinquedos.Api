using LojaDeBrinquedos.API.Models;

namespace LojaDeBrinquedos.API.Services;

public class FornecedorService
{
    
    
        private readonly List<Fornecedor> _fornecedores = new();

        public List<Fornecedor> Listar() => _fornecedores;

        public void Adicionar(Fornecedor fornecedor) => _fornecedores.Add(fornecedor);

        public Fornecedor BuscarPorId(int id) => _fornecedores.FirstOrDefault(f => f.Id == id);
    

}

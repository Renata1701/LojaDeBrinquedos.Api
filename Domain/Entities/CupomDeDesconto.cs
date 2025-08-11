namespace LojaDeBrinquedos.API.Domain.Entities;

    public class CupomDeDesconto
    {
        public int Id { get; set; } 

        public string Codigo { get; set; }
        public decimal ValorDesconto { get; set; }
        public DateTime DataValidade { get; set; }
        public bool Ativo { get; set; }

        public CupomDeDesconto(string codigo, decimal valorDesconto, DateTime dataValidade, bool ativo)
        {
            Codigo = codigo;
            ValorDesconto = valorDesconto;
            DataValidade = dataValidade;
            Ativo = ativo;
        }

    public CupomDeDesconto(int v1, string v2, int v3, DateTime dateTime)
    {
    }
}






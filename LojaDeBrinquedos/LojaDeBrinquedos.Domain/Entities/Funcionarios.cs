using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDeBrinquedos.Domain.Entities;
public class Funcionarios
{
    private int v1;
    private string v2;
    private string v3;
    private string v4;
    private string v5;

    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cargo { get; set; }
    public decimal Salario { get; set; }
    public DateTime DataContratacao { get; set; }
    public Funcionarios(int id, string nome, string cargo, decimal salario, DateTime dataContratacao)
    {
        Id = id;
        Nome = nome;
        Cargo = cargo;
        Salario = salario;
        DataContratacao = dataContratacao;
    }

    public Funcionarios(int v1, string v2, string v3, string v4, string v5)
    {
        this.v1 = v1;
        this.v2 = v2;
        this.v3 = v3;
        this.v4 = v4;
        this.v5 = v5;
    }
}

using InterfacePessoaFJ.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacePessoaFJ.Dto
{
    public class Pessoa : IPessoa
    {
        public int Id_Pessoa { get; set; }
        public string Nome { get; set; }
        public int idade { get; set; }
        public string Tipo { get; set; }
        public decimal RA { get; set; }
        public virtual void Mostrar(int ID) { }
        public virtual decimal IR() { return 0; }

        public virtual void Ler()
        {
            Console.Write("Digite o ID: "); Id_Pessoa = int.Parse(Console.ReadLine());
            Console.Write("Digite o Nome: "); Nome = Console.ReadLine();
            Console.Write("Digite o Idade: "); idade = int.Parse(Console.ReadLine());
            Console.Write("Digite a Renda Anual: "); RA = decimal.Parse(Console.ReadLine());
        }
    }
}

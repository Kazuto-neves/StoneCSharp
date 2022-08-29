using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using util;

namespace InterfacePessoaFJ.Dto
{
    public class PessoaFisica : Pessoa
    {
        public string CPF { get; set; }
        public int NumDep { get; set; }
        public string Profissao { get; set; }

        public override void Mostrar(int ID)
        {
            if (ID == this.Id_Pessoa) Console.WriteLine($"ID: {this.Id_Pessoa}\nNome: {this.Nome}\nRenda Anual: " + this.RA + $"\nIdade: {this.idade}\nTipo: {this.Tipo}\nCPF: {this.CPF}\nProfissao: {this.Profissao}\nDependentes: {this.NumDep}");
            else Console.WriteLine("ID invalido");
        }

        public override void Ler()
        {
            string cpf = string.Empty;
            base.Ler();
            Tipo = "Fisica";
            Console.Write("Digite o CPF: ");
            cpf = Console.ReadLine();
            while (CpfCnpjUtils.IsValid(cpf) == false)
            {
                Console.Write("Digite o CPF: ");
                cpf = Console.ReadLine();
            }
            CPF = cpf;
            Console.Write("Digite a Profissao: "); Profissao = Console.ReadLine();
            Console.Write("Digite o Numero de dependentes: "); NumDep = int.Parse(Console.ReadLine());
        }

        public override decimal IR() { return (decimal)0.07*RA; }
    }
}

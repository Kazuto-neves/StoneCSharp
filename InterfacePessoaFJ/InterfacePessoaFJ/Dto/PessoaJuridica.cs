using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using util;

namespace InterfacePessoaFJ.Dto
{
    public class PessoaJuridica : Pessoa
    {
        public string CNPJ { get; set; }
        public int NIN { get; set; }
        public int NIM { get; set; }
        public override void Mostrar(int ID)
        {
            if (ID == this.Id_Pessoa) Console.WriteLine($"ID: {this.Id_Pessoa}\nNome: {this.Nome}\nRenda Anual: "+this.RA+$"\nIdade: {this.idade}\nTipo: {this.Tipo}\nCNPJ: {this.CNPJ}\nInscr. Mun. : {this.NIM}\nInscr. Est. : {this.NIN}");
            else Console.WriteLine("ID invalido");
        }

        public override void Ler()
        {
            string cnpj = string.Empty;
            base.Ler();
            Tipo = "Juridica";
            Console.Write("Digite o CNPJ: ");
            cnpj = Console.ReadLine();
            while (CpfCnpjUtils.IsValid(cnpj) == false)
            {
                Console.Write("Digite o CNPJ: ");
                cnpj = Console.ReadLine();
            }
            CNPJ = cnpj;
            Console.Write("Digite o NIM: ");    NIM = int.Parse(Console.ReadLine());
            Console.Write("Digite o NIN: ");    NIN = int.Parse(Console.ReadLine());
        }

        public override decimal IR() { return (RA > 200000 ? RA *(decimal)0.25 : RA * (decimal)0.15); }
    }
}

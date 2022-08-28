using PessoaFJ.Bean;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PessoaFJ
{
    public class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        public static void Menu()
        {
            Console.WriteLine("Digite o tipo de Pessoa\nPF para pessoa fisica\nPJ para pessoa juridica\nDigite: ");
            switch (Console.ReadLine().ToUpper())
            {
                case "PF":
                    PessoaFisica();
                    break;
                case "PJ":
                    PessoaJuridica();
                    break;
            }
        }

        public static void PessoaFisica()
        {
            PF pf = new PF();
            pf.Nome = "Christian";
            pf.Idade = 22;
            pf.CPF = "104.444.592-76";
            Console.WriteLine($"Seu nome e: {pf.Nome}\nVocê tem: {pf.Idade}\nSeu CPF: {pf.CPF}");
            Console.ReadLine();
        }

        public static void PessoaJuridica()
        {
            PJ pj = new PJ();
            pj.Nome = "Christian";
            pj.Idade = 22;
            pj.CNPJ = "14.469.579/0001-40";
            Console.WriteLine($"Seu nome e: {pj.Nome}\nVocê tem: {pj.Idade}\nSeu CPF: {pj.CNPJ}");
            Console.ReadLine();
        }
    }
}

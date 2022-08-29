using InterfacePessoaFJ.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using util;

namespace InterfacePessoaFJ
{
    public class Program
    {
        private static int Menu()
        {
            int op = 0;
            do
            {
                Console.Clear();
                Console.Write("*MENU*\n" +
                    "1 - Inserir Pessoa Fisica\n" +
                    "2 - Inserir Pessoa Juridica\n" +
                    "3 - Mostrar Pessoa\n" +
                    "4 - Listar Pessoas\n" +
                    "5 - Sair\n" +
                    "Digite: ");
                op = int.Parse(Console.ReadLine());
            } while (op < 0 || op > 6);
            return op;
        }

        private static void Listar(List<PessoaFisica> pessoaFisicas,List<PessoaJuridica> pessoaJuridicas)
        {
            int op = 0;
            do
            {
                Console.Clear();
                Console.Write("1 - Listar os dois\n" +
                    "2 - Listar Pessoa Fisica\n" +
                    "3 - Listar Pessoa Juridica\n" +
                    "4 - Voltar\n" +
                    "Digite: ");
                op = int.Parse(Console.ReadLine());
            } while (op < 0 || op > 5);
            switch (op)
            {
                case 1:
                    Console.WriteLine("ID\tNome\tRenda\tIdade\tTipo\tCPF\tProfissao\tDependentes");
                    foreach (PessoaFisica pF in pessoaFisicas)
                    {
                        Console.WriteLine($"{pF.Id_Pessoa}\t{pF.Nome}\t"+pF.RA+$"\t{pF.idade}\t{pF.Tipo}\t{pF.CPF}\t{pF.Profissao}\t{pF.NumDep}");
                        Console.ReadKey();
                    }
                    Console.WriteLine("ID\tNome\tRenda\tIdade\tTipo\tCPF\tProfissao\tDependentes");
                    foreach (PessoaJuridica pJ in pessoaJuridicas)
                    {
                        Console.WriteLine($"{pJ.Id_Pessoa}\t{pJ.Nome}\t" + pJ.RA + $"\t{pJ.idade}\t{pJ.Tipo}\t{pJ.CNPJ}\t{pJ.NIN}\n{pJ.NIM}");
                        Console.ReadKey();
                    }
                    break;
                case 2:
                    Console.WriteLine("ID\tNome\tRenda\tIdade\tTipo\tCPF\tProfissao\tDependentes");
                    foreach (PessoaFisica pF in pessoaFisicas)
                    {
                        Console.WriteLine($"{pF.Id_Pessoa}\t{pF.Nome}\t" + pF.RA + $"\t{pF.idade}\t{pF.Tipo}\t{pF.CPF}\t{pF.Profissao}\t{pF.NumDep}");
                        Console.ReadKey();
                    }
                    break;
                case 3:
                    Console.WriteLine("ID\tNome\tRenda\tIdade\tTipo\tCNPJ\tNIN\tNIM");
                    foreach (PessoaJuridica pJ in pessoaJuridicas)
                    {
                        Console.WriteLine($"{pJ.Id_Pessoa}\t{pJ.Nome}\t" + pJ.RA + $"\t{pJ.idade}\t{pJ.Tipo}\t{pJ.CNPJ}\t{pJ.NIN}\n{pJ.NIM}");
                        Console.ReadKey();
                    }
                    break;
                case 4: break;
            }
        }

        private static void Mostrar(List<PessoaFisica> pessoaFisicas,List<PessoaJuridica> pessoaJuridicas)
        {
            int id;
            Console.Write("Digite o ID: ");
            id = int.Parse(Console.ReadLine());

            for (int i = 0; i < pessoaFisicas.Count; i++)
            {
                if (pessoaFisicas[i].Id_Pessoa == id)
                {
                    pessoaFisicas[i].Mostrar(id);
                    Console.ReadKey();
                }
            }

            for (int i = 0; i < pessoaJuridicas.Count; i++)
            {
                if (pessoaJuridicas[i].Id_Pessoa == id)
                {
                    pessoaJuridicas[i].Mostrar(id);
                    Console.ReadKey();
                }
            }
        }

        public static void Input(int OP,List<PessoaFisica> pessoaFisicas,List<PessoaJuridica> pessoaJuridicas, ref PessoaJuridica juridica, ref PessoaFisica fisica)
        {
            Console.WriteLine(pessoaFisicas.Count);
            Console.WriteLine(pessoaJuridicas.Count);
            if (OP == 1)
            {
                fisica.Ler();
                pessoaFisicas.Add(fisica);
            }
            else if (OP == 2)
            {
                juridica.Ler();
                pessoaJuridicas.Add(juridica);
            }
        }

        static void Main(string[] args)
        {
            //List<Pessoa> Pesssoas = new List<Pessoa>();
            List<PessoaFisica> pessoaFisicas = new List<PessoaFisica>();
            List<PessoaJuridica> pessoaJuridicas = new List<PessoaJuridica>();
            PessoaFisica fisica = new PessoaFisica();
            PessoaJuridica juridica = new PessoaJuridica();
            bool end = false;
            while (end != true)
            {
                switch (Menu())
                {
                    case 1:
                        Console.Clear();
                        Input(1,pessoaFisicas,pessoaJuridicas, ref juridica, ref fisica);
                        break;
                    case 2:
                        Console.Clear();
                        Input(2,pessoaFisicas,pessoaJuridicas, ref juridica, ref fisica);
                        break;
                    case 3:
                        Console.Clear();
                        Mostrar(pessoaFisicas,pessoaJuridicas);
                        break;
                    case 4:
                        Console.Clear();
                        Listar(pessoaFisicas,pessoaJuridicas);
                        break;
                    case 5:
                        Console.WriteLine("Programa encerrado");
                        end = true;
                        break;
                    default:
                        Menu();
                        break;
                }
            }
        }
    }
}

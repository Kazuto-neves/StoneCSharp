using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipo_Dados_Por_Valor
{
    class Program
    {
        static void Main(string[] args)
        {
            string Nome = string.Empty;
            decimal Valor = 0;

            Console.Write("Digite o nome: ");
            //atribuir valor a variavel
            Nome = Console.ReadLine();

            Console.Write("Digite o seu salario: ");
            Valor = decimal.Parse(Console.ReadLine());

            Menu(Nome,Valor);

            Console.ReadKey();
        }

        public static void Menu(string Nome,decimal Valor)
        {
            decimal Result = 0;
            Console.Write("1 para salario diario\n2 para mensal\n3 para anual\n4 para um ano não determinado\n Digite aqui: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Result = Diario(Valor);
                    Console.WriteLine($"O {Nome} ganha por Dia " + Result.ToString("C2"));
                    break;
                case "2":
                    Result = Mensal(Valor);
                    Console.WriteLine($"O {Nome} ganha por Mes " + Result.ToString("C2"));
                    break;
                case "3":
                    Result = Anual(Valor);
                    Console.WriteLine($"O {Nome} ganha por Ano " + Result.ToString("C2"));
                    break;
                case "4":
                    Result = Futuro(Valor);
                    Console.WriteLine($"O {Nome} num futuro distante " + Result.ToString("C2"));
                    break;

            }
        }

        public static decimal Diario(decimal valor)
        {
            return valor / 30;
        }

        public static decimal Mensal(decimal valor)
        {
            return valor;
        }

        public static decimal Anual(decimal valor)
        {
            return valor * 12;
        }

        public static decimal Futuro(decimal valor)
        {
            return valor * 365;
        }
    }
}

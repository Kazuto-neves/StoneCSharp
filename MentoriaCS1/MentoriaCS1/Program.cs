using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentoriaCS1
{
    class Program
    {
        public static void Main(string[] args)
        {
            string Nome = string.Empty;
            decimal Valor = 0;

            Console.Write("Digite o nome: ");
            //atribuir valor a variavel
            Nome = Console.ReadLine();

            Console.Write("Digite o seu salario: ");
            Valor = decimal.Parse(Console.ReadLine());

            Console.Write("Digite 1 para salario diario\n2 para mensal\n3 para anual\n Digite aqui: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine($"O {Nome} ganha por Dia " + (Valor / 30));
                    break;
                case "2":
                    Console.WriteLine($"O {Nome} ganha por Mes " + (Valor));
                    break;
                case "3":
                    Console.WriteLine($"O {Nome} ganha por Ano " + (Valor * 12));
                    break;

            }

            Console.ReadKey();
        }
    }
}
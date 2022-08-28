using ClassStone.Bean;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassStone
{
    class Program
    {
        static void Main(string[] args)
        {
            Funcionario funcionario = new Funcionario();
            Menu(funcionario);
        }

        static void Menu(Funcionario funcionario)
        {
            bool End = false, ON = false;
            do
            {
                if (ON)
                {
                    Console.Clear();
                    Console.Write("1 - inserir uma nova pessoa\n2 - Ver salario\n3 - sair\nDigite aqui: ");
                    switch (int.Parse(Console.ReadLine()))
                    {
                        case 1:
                            Console.Clear();
                            input(funcionario);
                            break;
                        case 2:
                            Console.Clear();
                            Opcao(funcionario);
                            Console.ReadKey();
                            break;
                        case 3:
                            Console.Clear();
                            Console.Write("Confirmar saida\n1 - Sim\n2 - Não\nDigite aqui: ");
                            End = int.Parse(Console.ReadLine()) == 1 ? true : false;
                            break;
                    }
                }
                else
                {
                    input(funcionario);
                    Opcao(funcionario);
                    Console.ReadKey();
                }
                if (ON == false)
                {
                    Console.Clear();
                    Console.Write("Deseja sair\n1 - Sim\n2 - Não\nDigite aqui: ");
                    End = int.Parse(Console.ReadLine()) == 1 ? true : false;
                }
                ON = true;
            } while (End == false);
        }
        public static void input(Funcionario funcionario)
        {
            do
            {
                Console.Write("Digite o nome: ");
                funcionario.Nome = Console.ReadLine();

            } while (funcionario.Nome == string.Empty);


            do
            {
                Console.Write("Digite o seu salario: ");
                funcionario.Salario = decimal.Parse(Console.ReadLine());

            } while (funcionario.Salario <= 0);

            do
            {
                Console.Write("Digite a carga Horaria diaria: ");
                funcionario.cargaHoraria = int.Parse(Console.ReadLine());

            } while (funcionario.cargaHoraria <= 0);
        }

        public static void Opcao(Funcionario funcionario)
        {
            decimal Result = 0;
            int carga = 0;
            Console.Write("1 para salario diario\n2 para mensal\n3 para anual\n4 para um ano não determinado\n Digite aqui: ");
            switch (Console.ReadLine())
            {
                case "1":
                    Result = funcionario.verSalarioDiario();
                    carga = funcionario.cargaHoraria;
                    Console.WriteLine($"O {funcionario.Nome} ganha por Dia " + Result.ToString("C2") + " Com a carga horaria de: " + carga);
                    break;
                case "2":
                    Result = funcionario.Salario;
                    carga = funcionario.verCargaGorariaMensal();
                    Console.WriteLine($"O {funcionario.Nome} ganha por Mes " + Result.ToString("C2") + "Com a carga horaria de: " + carga);
                    break;
                case "3":
                    Result = funcionario.verSalarioAnual();
                    carga = funcionario.verCargaGorariaAnual();
                    Console.WriteLine($"O {funcionario.Nome} ganha por Ano " + Result.ToString("C2") + " Com a carga horaria de: " + carga);
                    break;
                case "4":
                    Result = funcionario.verSalarioFuturo();
                    carga = funcionario.verCargaGorariaFuturo();
                    Console.WriteLine($"O {funcionario.Nome} num futuro distante " + Result.ToString("C2") + " Com a carga horaria de: " + carga);
                    break;

            }
        }
    }
}

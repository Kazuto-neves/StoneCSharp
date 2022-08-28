using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorReferencia
{
    class Program
    {
        static void Main(string[] args)
        {
            string Nome = string.Empty;
            decimal Valor = 0;
            int cargaHoraria = 0;

            Menu(ref Nome, ref Valor, ref cargaHoraria);
        }


        static void Menu(ref string Nome, ref decimal Valor, ref int cargaHoraria)
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
                            input(ref Nome, ref Valor, ref cargaHoraria);
                            break;
                        case 2:
                            Console.Clear();
                            Opcao(Nome, Valor, cargaHoraria);
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
                    input(ref Nome, ref Valor, ref cargaHoraria);
                    Opcao(Nome, Valor, cargaHoraria);
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
        public static void input(ref string Nome, ref decimal Valor, ref int cargaHoraria)
        {
            do
            {
                Console.Write("Digite o nome: ");
                Nome = Console.ReadLine();

            } while (Nome == string.Empty);


            do
            {
                Console.Write("Digite o seu salario: ");
                Valor = decimal.Parse(Console.ReadLine());

            } while (Valor <= 0);

            do
            {
                Console.Write("Digite a carga Horaria diaria: ");
                cargaHoraria = int.Parse(Console.ReadLine());

            } while (cargaHoraria <= 0);
        }

        public static void Opcao(string Nome, decimal Valor, int cargahoraria)
        {
            decimal Result = 0;
            int carga = 0;
            Console.Write("1 para salario diario\n2 para mensal\n3 para anual\n4 para um ano não determinado\n Digite aqui: ");
            switch (Console.ReadLine())
            {
                case "1":
                    Result = Diario(Valor);
                    carga = DiarioC(cargahoraria);
                    Console.WriteLine($"O {Nome} ganha por Dia " + Result.ToString("C2") + " Com a carga horaria de: " + carga);
                    break;
                case "2":
                    Result = Mensal(Valor);
                    carga = MensalC(cargahoraria);
                    Console.WriteLine($"O {Nome} ganha por Mes " + Result.ToString("C2") +  "Com a carga horaria de: " + carga);
                    break;
                case "3":
                    Result = Anual(Valor);
                    carga = AnualC(cargahoraria);
                    Console.WriteLine($"O {Nome} ganha por Ano " + Result.ToString("C2") + " Com a carga horaria de: " + carga);
                    break;
                case "4":
                    Result = Futuro(Valor);
                    carga = FuturoC(cargahoraria);
                    Console.WriteLine($"O {Nome} num futuro distante " + Result.ToString("C2") + " Com a carga horaria de: " + carga);
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

        public static int DiarioC(int cargaHoraria)
        {
            return cargaHoraria;
        }

        public static int MensalC(int cargaHoraria)
        {
            return cargaHoraria * 30;
        }

        public static int AnualC(int cargaHoraria)
        {
            return (cargaHoraria * 30) * 12;
        }

        public static int FuturoC(int cargaHoraria)
        {
            return cargaHoraria * 365;
        }
    }
}

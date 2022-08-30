using CadrastroProduto.Bean;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadrastroProduto
{
    class Program
    {
        private static int Menu()
        {
            int op = 0;
            do
            {
                Console.Clear();
                Console.Write("*MENU*\n" +
                    "1 - Comprar Produto\n" +
                    "2 - Vender Produto\n" +
                    "3 - lista Categorias de Produto\n" +
                    "4 - Listar Produtos\n" +
                    "5 - Listar Compras\n" +
                    "6 - Listar Vendas\n" +
                    "7 - Cancelar Venda\n" +
                    "8 - Cancelar Compra\n" +
                    "9 - Sair\n" +
                    "Digite: ");
                op = int.Parse(Console.ReadLine());
            } while (op < 0 || op > 9);
            return op;
        }

        private static void Listar(int op, List<pCompra> compras, List<pVenda> vendas, List<pCompra> produtos)
        {
            if (op == 1)
            {
                Console.Write("Gostaria de saber o subCategoria\n" +
                    "1 - Sim\n" +
                    "2 - Não\n" +
                    "Digite: ");
                int OP = int.Parse(Console.ReadLine());
                Console.WriteLine("Categoria");
                foreach (pCompra produto in produtos)
                {
                    Console.WriteLine($"{produto.Categoria}");
                    if (OP == 1)
                    {
                        Console.WriteLine($"\t{produto.SubCategoria}");
                    }

                }
                Console.ReadKey();
            }
            else if (op == 2)
            {
                Console.WriteLine("ID\tCategoria\tSub Categoria\tProduto\tStatus\nQuantidade");
                foreach (pCompra produto in produtos)
                {
                    Console.WriteLine($"{produto.ID}\t{produto.Categoria}\t{produto.SubCategoria}\t{produto.Nome}\t{produto.status}\t{produto.Qtd}");
                }
                Console.ReadKey();
            }
            else if (op == 3)
            {
                Console.WriteLine("ID\tCategoria\tSub Categoria\tProduto\tStatus\nQuantidade\tPreço");
                foreach (pCompra compra in compras)
                {
                    Console.WriteLine($"{compra.ID}\t{compra.Categoria}\t{compra.SubCategoria}\t{compra.Nome}\t{compra.status}\t{compra.Qtd}\t{compra.Preco}");
                }
                Console.ReadKey();
            }
            else if (op == 4)
            {
                Console.WriteLine("ID\tCategoria\tSub Categoria\tProduto\tStatus\nQuantidade\tLucro\tPreço\tDescrição");
                foreach (pVenda venda in vendas)
                {
                    Console.WriteLine($"{venda.ID}\t{venda.Categoria}\t{venda.SubCategoria}\t{venda.Nome}\t{venda.status}\t{venda.Qtd}\t{venda.Lucro}\t{venda.Preco}\t{venda.Descricao}");
                }
                Console.ReadKey();
            }
        }

        private static void Cancelar(int op,List<pCompra> compras,List<pVenda> vendas)
        {
            Console.Write("Digite o ID: ");
            int id = int.Parse(Console.ReadLine());

            if (op == 1)
            {
                for(int i = 0; i < vendas.Count; i++)
                {
                    if (vendas[i].ID == id)
                    {
                        vendas[i].cancelar(id);
                        Console.ReadKey();
                    }
                }
            }
            else
            {
                for (int i = 0; i < compras.Count; i++)
                {
                    if (compras[i].ID == id)
                    {
                        compras[i].cancelar(id);
                        Console.ReadKey();
                    }
                }
            }
        }

        private static void Mostrar(List<pCompra> compras, List<pVenda> vendas)
        {
            int id;
            Console.Write("Digite o ID: ");
            id = int.Parse(Console.ReadLine());

            for (int i = 0; i < vendas.Count; i++)
            {
                if (vendas[i].ID == id)
                {
                    vendas[i].Mostrar(id);
                    Console.ReadKey();
                }
            }

            for (int i = 0; i < compras.Count; i++)
            {
                if (compras[i].ID == id)
                {
                    compras[i].Mostrar(id);
                    Console.ReadKey();
                }
            }
        }

        public static void Input(int OP, List<pCompra> compras, List<pVenda> vendas, List<pCompra> produtos, pCompra compra, pVenda venda)
        {
            Console.WriteLine(compras.Count);
            Console.WriteLine(vendas.Count);
            if (OP == 1)
            {
                compra.Ler();
                compras.Add(compra);
                produtos.Add(compra);
            }
            else if (OP == 2)
            {
                Console.Write("Digite o ID: ");
                int Id = int.Parse(Console.ReadLine());
                foreach (pCompra produto in produtos)
                {
                    if (produto.ID == Id)
                    {
                        venda.Ler(produto.ID, produto.Categoria, produto.SubCategoria, produto.Nome, produto.status, produto.Qtd, produto.Preco);
                        vendas.Add(venda);
                        produto.Qtd -= venda.Qtd;
                    }
                    else
                    {
                        Console.WriteLine("Não existe esse Produto na Lista");
                    }
                }
                Console.ReadLine();
            }
        }
        static void Main(string[] args)
        {
            List<pCompra> compras = new List<pCompra>();
            List<pCompra> produtos = new List<pCompra>();
            List<pVenda> vendas = new List<pVenda>();
            pCompra compra = new pCompra();
            pVenda venda = new pVenda();

            bool end = false;
            while (end != true)
            {
                switch (Menu())
                {
                    case 1:
                        Console.Clear();
                        Input(1, compras, vendas, produtos, new pCompra(), new pVenda());
                        break;
                    case 2:
                        Console.Clear();
                        Input(2, compras, vendas, produtos, new pCompra(), new pVenda());
                        break;
                    case 3:
                        Console.Clear();
                        Listar(1, compras, vendas, produtos);
                        break;
                    case 4:
                        Console.Clear();
                        Listar(2, compras, vendas, produtos);
                        break;
                    case 5:
                        Console.Clear();
                        Listar(3, compras, vendas, produtos);
                        break;
                    case 6:
                        Console.Clear();
                        Listar(4, compras, vendas, produtos);
                        break;
                    case 7:
                        Console.Clear();
                        Cancelar(1, compras, vendas);
                        break;
                    case 8:
                        Console.Clear();
                        Cancelar(2, compras, vendas);
                        break;
                    case 9:
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

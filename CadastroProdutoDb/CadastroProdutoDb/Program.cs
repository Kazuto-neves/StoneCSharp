using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroProdutoDb
{
    class Program
    {

        private static string Input(string txt)
        {
            Console.Write(txt);
            return Console.ReadLine();
        }
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

        private static string categoria()
        {
            return Input("Digite a Categoria: ");
        }

        private static string subCategoria()
        {
            return Input("Digite a subCategoria: ");
        }

        private static string nome()
        {
            return Input("Digite o nome do Produto: ");
        }

        private static int Quantidade()
        {
            return int.Parse(Input("Digite a Quantidde: "));
        }

        private static decimal Preco()
        {
            return decimal.Parse(Input("Digite o Preco: "));
        }

        static void Main(string[] args)
        {
            using (var db = new LojaEntities())
            {
                bool End = false;
                string cat = string.Empty;
                string sub = string.Empty;
                int qtd;
                decimal Valor = 0;
                var query4 = from c in db.Products select c;
                string nome2 = string.Empty;
                var query7 = from c in db.Products where c.Nome == nome2 select c;

                do
                {
                    switch (Menu())
                    {
                        case 1:
                            cat = categoria();
                            sub = subCategoria();
                            qtd = Quantidade();
                            if (db.Categorias.Any(cus => cus.Descricao == cat))
                            {
                                Console.WriteLine("A Categoria já existe.");
                            }
                            else
                            {
                                Categoria categoria = new Categoria()
                                {
                                    Descricao = cat
                                };
                                db.Categorias.Add(categoria);
                                db.SaveChanges();
                                categoria.SubCategorias.Add(new SubCategoria
                                {
                                    Descricao = sub
                                });
                                db.SaveChanges();

                                var query9 = (from c in db.SubCategorias orderby c.Id_SubCategoria descending select c);
                                int id = 0;

                                foreach (SubCategoria subCategoria in query9)
                                {
                                    if (id == 0)
                                    {
                                        id = subCategoria.Id_SubCategoria;
                                    }
                                }

                                Product product = new Product()
                                {
                                    Nome = nome(),
                                    Qtd_Total = qtd,
                                    Id_SB = id
                                };
                                db.Products.Add(product);
                                db.SaveChanges();

                                product.Compras.Add(new Compra
                                {
                                    Cancelado = 0,
                                    Preco = Preco(),
                                    Qtd_Compra = qtd
                                });
                                db.SaveChanges();
                            }
                            break;
                        case 2:
                            string name = nome();
                            qtd = Quantidade();
                            if (db.Products.Any(cus => cus.Nome == name))
                            {
                                var query8 = from c in db.Products where c.Nome == name select c;
                                foreach (Product product in query8)
                                {
                                    Venda venda = new Venda()
                                    {
                                        Id_Product = product.Id_Product,
                                        Cancelado = 0,
                                        Qtd_Venda = qtd,
                                        Preco = 0
                                    };
                                    db.Vendas.Add(venda);
                                    foreach (var n in product.Compras)
                                    {
                                        Valor = n.Preco;
                                    }
                                    foreach (var n in product.Vendas)
                                    {
                                        n.Preco = (Valor * qtd);
                                        product.Qtd_Total -= n.Qtd_Venda;
                                    }
                                }

                            }
                            break;
                        case 3:
                            var query2 = from c in db.Categorias.Include("SubCategorias") select c;
                            foreach (Categoria categoria in query2)
                            {
                                Console.WriteLine($"Categoria: {categoria.Id_Categoria} - {categoria.Descricao}");
                                Console.WriteLine("=========================================================================");
                                foreach (var n in categoria.SubCategorias)
                                {
                                    Console.WriteLine($"\tSub Categoria =  {n.Descricao} =================== ");
                                }
                            }
                            break;
                        case 4:
                            var query3 = from c in db.Products select c;
                            foreach (Product produto in query3)
                            {
                                Console.WriteLine($"Produto: {produto.Id_Product} - {produto.Nome} QTD: {produto.Qtd_Total}");
                            }
                            Console.WriteLine("=========================================================================");
                            break;
                        case 5:
                            string v = string.Empty;
                            foreach (var compra in query4)
                            {
                                Console.Write($"Produto:{compra.Id_Product} {compra.Nome} ");
                                foreach (var n in compra.Compras)
                                {
                                    v = n.Cancelado == 0 ? "Ativo" : "Cancelado";
                                    Console.WriteLine($"QTD: {n.Qtd_Compra} Status: {v} Preco {n.Preco}");
                                }
                            }
                            Console.WriteLine("=========================================================================");
                            Console.ReadLine();
                            break;
                        case 6:
                            foreach (var venda in query4)
                            {
                                Console.Write($"Produto:{venda.Id_Product} {venda.Nome} ");
                                foreach (var n in venda.Vendas)
                                {
                                    v = n.Cancelado == 0 ? "Ativo" : "Cancelado";
                                    Console.WriteLine($"QTD: {n.Qtd_Venda} Status: {v} Preco {n.Preco}");
                                }
                            }
                            Console.WriteLine("=========================================================================");
                            Console.ReadLine();
                            break;
                        case 7:
                            nome2 = Input("Digite o Nome do Produto: ");
                            foreach (var venda in query7)
                            {
                                foreach (var n in venda.Vendas)
                                {
                                    n.Cancelado = 1;
                                }
                            }
                            db.SaveChanges();
                            break;
                        case 8:
                            nome2 = Input("Digite o Nome do Produto: ");
                            foreach (var compra in query7)
                            {
                                foreach (var n in compra.Compras)
                                {
                                    n.Cancelado = 1;
                                }
                            }
                            db.SaveChanges();
                            break;
                        case 9:
                            End = true;
                            Console.WriteLine("Programa encerrando");
                            break;
                        default:
                            Menu();
                            break;
                    }
                } while (End != true);
            }
        }
    }
}

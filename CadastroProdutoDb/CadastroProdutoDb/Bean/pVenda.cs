using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadrastroProduto.Bean
{
    public class pVenda: Produto
    {
        public string Lucro { get; set; }
        public decimal Preco { get; set; }
        public string Descricao { get; set; }


        public void Ler(int id,string categoria,string subCategoria,string nome,bool status,int qtd,decimal preco)
        {
            double valor = 0;
            base.Ler(id, categoria, subCategoria, nome,status,qtd);
            Console.Write("Digite a Porcentagem de Lucro: ");
            valor= double.Parse(Console.ReadLine());
            Lucro = (valor*(double)100).ToString();
            Console.Write("Digite Local onde está: ");
            Descricao = Console.ReadLine();
            Preco = preco * (1 + (decimal)valor);
            Console.Write($"Digite o Preco de Venda: {Preco}");
        }

        public void Mostrar(int Id)
        {
            if (Id == ID)Console.WriteLine($"ID: {this.ID}\nCategoria: {this.Categoria}Sub Categoria: {this.SubCategoria}\nProduto: {this.Nome}\nStatus: {this.status}\nQuantidade: {this.Qtd}\nLucro: {this.Lucro}%\nPreço{this.Preco}\nDescrição: {this.Descricao}");
            else Console.WriteLine("ID invalido");
        }

        public void cancelar(int Id)
        {
            if (Id == ID) status = false;
            else Console.WriteLine("ID invalido");
        }


    }


}

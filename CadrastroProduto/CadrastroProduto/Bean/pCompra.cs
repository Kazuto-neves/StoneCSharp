using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadrastroProduto.Bean
{
    public class pCompra : Produto
    {
        public decimal Preco { get; set; }

        public override void Ler()
        {
            base.Ler();
            Console.Write("Digite o Preco de Compra: ");
            Preco = decimal.Parse(Console.ReadLine());
        }

        public void Mostrar(int Id)
        {
            if (Id == ID) Console.WriteLine($"ID: {this.ID}\nCategoria: {this.Categoria}Sub Categoria: {this.SubCategoria}\nProduto: {this.Nome}\nStatus: {this.status}\nQuantidade: {this.Qtd}\nPreço: "+this.Preco.ToString("2C"));
            else Console.WriteLine("ID invalido");
        }

        public void cancelar(int Id)
        {
            if (Id == ID) status = false;
            else Console.WriteLine("ID invalido");
        }
    }
}

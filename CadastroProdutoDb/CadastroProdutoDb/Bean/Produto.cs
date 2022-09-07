using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadrastroProduto.Bean
{
    public class Produto
    {
        public int ID { get; set; }
        public string Categoria { get; set; }
        public string SubCategoria { get; set; }
        public string Nome { get; set; }
        public bool status { get; set; }
        public int Qtd { get; set; }

        public virtual void Ler()
        {
            Console.Write("Digite o Id: ");
            ID = int.Parse(Console.ReadLine());
            Console.Write("Digite Categoria: ");
            Categoria = Console.ReadLine();
            Console.Write("Digite SubCategoria: ");
            SubCategoria = Console.ReadLine();
            Console.Write("Digite Nome do Produto: ");
            Nome = Console.ReadLine();
            Console.Write("status: ");
            status = (int.Parse(Console.ReadLine()) == 0 ? true : false);
            Console.Write("Quantidade: ");
            Qtd = int.Parse(Console.ReadLine());
        }

        public virtual void Ler(int ID,string Categoria,string SubCategoria,string Nome,bool status,int Qtd)
        {
            this.ID = ID;
            this.Categoria = Categoria;
            this.SubCategoria = SubCategoria;
            this.Nome = Nome;
            this.status = status;
            do
            {
                Console.Write($"Quantidade  do maximo de {Qtd}: ");
                this.Qtd = int.Parse(Console.ReadLine());
            } while (this.Qtd > Qtd);
        }

    }
}

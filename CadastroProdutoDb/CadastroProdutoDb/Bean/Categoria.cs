using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadrastroProduto.Bean
{
    public class Categoria
    {
        public int idCategoria { get; set; }
        public string nomeCategoria { get; set; }


        public virtual void ler(int opS, int idS,int op, int id)
        {
            if (opS == 1)
            {
                if (idS == this.idCategoria)
                {
                    lerById(idCategoria, nomeCategoria);

                }
                else
                {
                    Console.WriteLine("Categoria não existe");
                    ler(2, idS, op, id);
                }
            }
            else
            {
                Console.Write("Id da Categoria: ");
                idCategoria = idS;
                Console.Write("\nDigite o Nome da Categoria: ");
                nomeCategoria = Console.ReadLine();
            }
        }

        public virtual void lerById(int Id, string Nome)
        {
            Console.Write("Digite o Id da Categoria: "); idCategoria = Id;
            Console.Write("\nDigite o Nome da Categoria: "); nomeCategoria = Nome;
        }
    }
}

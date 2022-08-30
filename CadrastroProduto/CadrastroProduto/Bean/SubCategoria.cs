using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadrastroProduto.Bean
{
    public class SubCategoria : Categoria
    {
        public int idSubCategoria { get; set; }
        public string nomeSubCategoria { get; set; }


        public override void ler(int opS, int idS,int op,int id)
        {
            Console.Write("Digite o Id do Sub Conjunto: ");
            base.ler(opS,idS,op,id);
            id = int.Parse(Console.ReadLine());
            if (op == 1)
            {
                if (id == this.idSubCategoria)
                {
                    lerById(idSubCategoria, nomeSubCategoria);
                }
                else
                {
                    Console.WriteLine("Sub Categoria não existe");
                    ler(opS, idS,2,id);
                }
            }
            else
            {
                Console.Write("Id da Sub Categoria: ");
                idSubCategoria = id;
                Console.Write("\nDigite o Nome da Sub Categoria: ");
                nomeSubCategoria = Console.ReadLine();
            }
        }

        public override void lerById(int Id, string Nome)
        {
            Console.Write("Digite o Id da Sub Categoria: "); idSubCategoria = Id;
            Console.Write("\nDigite o Nome da Sub Categoria: "); nomeSubCategoria = Nome;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacePessoaFJ.Interfaces
{
    interface IPessoa
    {
        decimal RA { get; set; }
        string Tipo { get; set; }
        void Mostrar(int ID);
        decimal IR();
        void Ler();


    }
}

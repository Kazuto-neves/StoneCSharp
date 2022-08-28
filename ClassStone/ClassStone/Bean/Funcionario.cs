using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassStone.Bean
{
    public class Funcionario
    {
        public string Nome { get; set; }
        public decimal Salario { get; set; }
        public int cargaHoraria { get; set; }

        public decimal verSalarioDiario()
        {
            return Salario / 30;
        }

        public decimal verSalarioAnual()
        {
            return Salario * 12;
        }

        public decimal verSalarioFuturo()
        {
            return Salario * 365;
        }

        public int verCargaGorariaMensal()
        {
            return cargaHoraria * 30;
        }

        public int verCargaGorariaAnual()
        {
            return (cargaHoraria * 30) * 12;
        }

        public int verCargaGorariaFuturo()
        {
            return cargaHoraria * 365;
        }
    }
}

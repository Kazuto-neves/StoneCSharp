//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CadastroProdutoDb
{
    using System;
    using System.Collections.Generic;
    
    public partial class Compra
    {
        public int Id_Compra { get; set; }
        public int Qtd_Compra { get; set; }
        public decimal Preco { get; set; }
        public byte Cancelado { get; set; }
        public int Id_Product { get; set; }
    
        public virtual Product Product { get; set; }
    }
}
using System;
using Ecommerce.enums;
using Ecommerce.interfaces;
using Ecommerce.servicos;
using Newtonsoft.Json;

namespace Ecommerce.models
{
    partial class Cliente
    {
        public void Salvar(IPersistencia persistencia)
        {
            ClientesServico.Salvar(this,persistencia);
        }

        public static List<Cliente> Todos(IPersistencia persistencia)
        {
            return ClientesServico.Todos(persistencia);
        }
    }
}

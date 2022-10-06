using Ecommerce.enums;
using Ecommerce.interfaces;
using Ecommerce.models;

namespace Ecommerce.servicos
{
    class ClientesServico
    {
        public static void Salvar(Cliente cliente, IPersistencia persistencia)
        {
            var clientes = ClientesServico.Todos(persistencia);
            var clienteExistente = clientes.Find(c => c.Id == cliente.Id);
            if (clienteExistente != null)
            {
                clientes.Remove(clienteExistente);
            }

            clientes.Add(cliente);

            persistencia.Salvar<Cliente>(clientes);
        }

        public static List<Cliente> Todos(IPersistencia persistencia)
        {
            return persistencia.Todos<Cliente>();
        }
    }
}
using Ecommerce.enums;
using Ecommerce.interfaces;
using Ecommerce.models;
using Ecommerce.servicos;
//using Ecommerce.entidades;

namespace Ecommerce
{
    class Program
    {
        static void Main(string[] args)
        {
            var f1 = new Fornecedor()
            {
                Id = 1,
                Nome = "RR",
                CNPJ = "1111111111",
                Email = "sys@gmail.com"
            };
            
            var jsonServico = new JsonServico();
            var lista = jsonServico.Todos<Fornecedor>();
            var formEncontrado = lista.Find(f => f.Id == f1.Id);
            if(formEncontrado != null) lista.Remove(formEncontrado);
            lista.Add(f1);
            jsonServico.Salvar<Fornecedor>(lista);

            var c1 = new Cliente();
            c1.Nome = "sss";
            c1.Salvar(new JsonServico());

            var c2 = new Cliente()
            {
                Id = 3,
                Nome = "Felipe",
                Email = "fe@tr.cp",
                EnderecoCompleto = "Rua gg"
            };

            ClientesServico.Salvar(c2, new CsvServico());

            var c3 = new Cliente()
            {
                Id = 3,
                Nome = "Felipe",
                Email = "fe@tr.cp",
                EnderecoCompleto = "Rua gg"
            };

            ClientesServico.Salvar(c2, new MySqlServico());

            new Cliente()
            {
                Id = 1,
                Nome = "Leandro",
                Email = "leandro@teste.com",
                EnderecoCompleto = "Rua teste 123 SP"
            }.Salvar(new JsonServico());

            new Cliente()
            {
                Id = 2,
                Nome = "Danilo",
                Email = "danilo@teste.com",
                EnderecoCompleto = "Rua teste 123 SP"
            }.Salvar(new JsonServico());

            new Cliente()
            {
                Id = 1,
                Nome = "Leandro",
                Email = "leandro@teste.com",
                EnderecoCompleto = "Rua teste 123 SP"
            }.Salvar(new CsvServico());

            new Cliente()
            {
                Id = 2,
                Nome = "Danilo",
                Email = "danilo@teste.com",
                EnderecoCompleto = "Rua teste 123 SP"
            }.Salvar(new CsvServico());

            new Cliente()
            {
                Id = 2,
                Nome = "Danilo",
                Email = "danilo@teste.com",
                EnderecoCompleto = "Rua teste 123 SP"
            }.Salvar(new CsvServico());

            Console.WriteLine("O cliente foi salvo com sucesso!");

            foreach (Cliente cliente in Cliente.Todos(new JsonServico()))
            {
                Console.WriteLine("===============================");
                Console.WriteLine($"Id: {cliente.Id}");
                Console.WriteLine($"Nome: {cliente.Nome}");
            }

            Console.WriteLine("============[Lendo do CSV]===================");
            foreach (Cliente cliente in Cliente.Todos(new CsvServico()))
            {
                Console.WriteLine("===============================");
                Console.WriteLine($"Id: {cliente.Id}");
                Console.WriteLine($"Nome: {cliente.Nome}");
            }

        }
    }
}

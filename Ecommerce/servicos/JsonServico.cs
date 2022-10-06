using System;
using Ecommerce.enums;
using Ecommerce.interfaces;
using Newtonsoft.Json;

namespace Ecommerce.servicos
{
    class JsonServico : IPersistencia
    {
        private string getArquivo<T>()
        {
            return "db/" + typeof(T).Name.ToLower() + "s.json";
        }
        public void Salvar<T>(List<T> lista)
        {
            var json = JsonConvert.SerializeObject(lista);
            File.WriteAllText(getArquivo<T>(), json);
        }

        public List<T> Todos<T>()
        {
            var arquivo = getArquivo<T>();
            if (!File.Exists(arquivo)) File.WriteAllText(arquivo, "[]");

            var json = File.ReadAllText(arquivo);
            var lista = JsonConvert.DeserializeObject(json, typeof(List<T>));
            return (List<T>)lista;
        }
    }


}

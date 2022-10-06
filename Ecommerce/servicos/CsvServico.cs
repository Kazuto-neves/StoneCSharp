using System;
using Ecommerce.enums;
using Ecommerce.interfaces;
using Newtonsoft.Json;

namespace Ecommerce.servicos
{
    class CsvServico : IPersistencia
    {

        private string getArquivo<T>()
        {
            return "db/" + typeof(T).Name.ToLower() + "s.csv";
        }
        private string getColunas<T>()
        {
            var colunas = string.Empty;
            foreach (var p in typeof(T).GetProperties())
            {
                colunas += p.Name + ";";
            }
            return colunas;
        }
        public void Salvar<T>(List<T> lista)
        {
            var colunas = getColunas<T>();
            var linhas = colunas + "\n";
            foreach (var obj in lista)
            {
                var colunasObj = string.Empty;
                linhas += $"{colunasObj}\n";
            }

            File.WriteAllText(this.getArquivo<T>(),linhas);
        }

        public List<T> Todos<T>()
        {
            var colunas = getColunas<T>();
            var arquivo = getArquivo<T>();
            if (!File.Exists(arquivo)) File.WriteAllText(arquivo, colunas);

            var lista = (List<T>)Activator.CreateInstance(typeof(List<T>));

            string text = File.ReadAllText(arquivo);
            string[] lines = text.Split(Environment.NewLine);

            foreach (string line in lines)
            {
                var coluns = line.Split(';');
                if (coluns[0].Trim().ToLower() == "id" || coluns[0].Trim().ToLower() == "") continue;

                var obj = Activator.CreateInstance(typeof(T));
                var i = 0;
                foreach (var p in obj.GetType().GetProperties())
                {
                    if (p.PropertyType == typeof(int))
                    {
                        p.SetValue(obj, int.Parse(coluns[i]));
                    }
                    else
                    {
                        p.SetValue(obj, coluns[i]);
                    }
                    i++;
                }
                lista.Add((T)obj);
            }
            return lista;
        }
    }
}
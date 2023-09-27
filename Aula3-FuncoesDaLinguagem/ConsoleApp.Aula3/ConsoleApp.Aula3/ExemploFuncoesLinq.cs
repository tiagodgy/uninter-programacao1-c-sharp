using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp.Aula3
{
    public class ExemploFuncoesLinq
    {
        public ExemploFuncoesLinq()
        {
            var listaValores = new List<int>();

            //poupula a lista com alguns valores
            for (int i = 0; i < 10; i++)
            {
                listaValores.Add(i);
            }

            //Exemplo de filtro com o WHERE:
            var listaFiltradaWhere = listaValores.Where(p => p > 5); //6,7,8,9

            //Exemplo de First encontrando o elemento:
            var elemento2 = listaValores.First(v => v == 2); // 2

            //Exemplo de FirstOrDefault de um elemento não existente:
            var elementoDefault = listaValores.FirstOrDefault(v => v > 10); // 0 (valor default do int)

            //Exemplo do Any e Max
            if (listaValores.Any())
            {
                var maxValue = listaValores.Max(); // 9
            }

            //-------------------------------------------------------------
            //Exemplo Query encadeada - Where + OrderBy + Select
            string[] names = { "Tom", "Huck", "Harry", "Mary", "Jay" };

            IEnumerable<string> query = names.Where(n => n.Contains("a"))
                                             .OrderBy(n => n.Length)
                                             .Select(n => n.ToUpper());

            foreach (string name in query) 
            {
                Console.WriteLine(name);
            }

            IEnumerable<string> filtered = names.Where(n => n.Contains("a"));
            IEnumerable<string> sorted = filtered.OrderBy(n => n.Length);
            IEnumerable<string> finalQuery = sorted.Select(n => n.ToUpper());

            //-------------------------------------------------------------
            //Exemplo de operador Select
            string[] nomes = { "Tom", "Huck", "Harry", "Mary", "Jay" };

            //Utilizando o select para fazer uma Projeção (modificando o tipo de retorno da lista)
            //de uma lista de string, transformamos em uma lista de inteiros
            //onde cada elemento representa o comprimento da string de seu indice
            IEnumerable<int> queryResultSelect = nomes.Select(n => n.Length);
            foreach (int length in queryResultSelect)
            {
                Console.Write(length + "|"); //Output no console:  3|4|5|4|3|
            }

            //-------------------------------------------------------------
            //Exemplo Take, Skip e Reverse
            int[] numerosExemplo = { 10, 9, 8, 7, 6 };
            IEnumerable<int> primeirosTres = numerosExemplo.Take(3); // { 10, 9, 8 }

            IEnumerable<int> ultimosDois = numerosExemplo.Skip(3); // { 7, 6 }

            IEnumerable<int> listaReversa = numerosExemplo.Reverse(); // { 6, 7, 8, 9, 10 }

            QuerySyntaxExemplos();
        }


        public void QuerySyntaxExemplos()
        {
            string[] nomes = { "Tom", "Dick", "Harry", "Mary", "Jay" };
            IEnumerable<string> query = from n in nomes
                                        where n.Contains("a") // Filtra os elementos
                                        orderby n.Length // Ordena pelo tamanho
                                        select n.ToUpper(); // Converte para string Upper (projeção)

            foreach (string nome in query) 
            {
                Console.WriteLine(nome); 
            }

            //-------------------------------------------------------------
            //Mix -> Fluent e Query Expression
            var quantidadeLetraA = (from n in nomes where n.Contains("a") select n).Count(); // 3
            var primeiroElementoDescrescente = (from n in nomes orderby n descending select n).First(); // Tom

            var mixQueries = (from n in nomes
                             join nomeY in nomes.Where(y => y.Contains("y")) on n equals nomeY
                             where n.Count() > 3
                             select n.ToUpper())
                             .OrderByDescending(x=> x); // MARY, HARRY

            Console.WriteLine(quantidadeLetraA);
            Console.WriteLine(primeiroElementoDescrescente);

            foreach (var item in mixQueries)
            {
                Console.WriteLine(item); // MARY, HARRY
            }
        }

    }

}

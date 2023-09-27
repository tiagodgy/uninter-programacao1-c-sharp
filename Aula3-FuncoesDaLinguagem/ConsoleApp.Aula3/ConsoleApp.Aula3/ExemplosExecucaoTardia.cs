using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp.Aula3
{
    public class ExemplosExecucaoTardia
    {
        public ExemplosExecucaoTardia()
        {
            //Exemplo 1:
            //lista de números com um único elemento
            var numeros = new List<int> { 1 };

            //construímos uma query LINQ com o operador de projeção SELECT
            //observe que estamos multiplicando cada elemento da coleção
            //por 10
            var query = numeros.Select(n => n * 10); // construção da query

            numeros.Add(2); // Adicionamos 1 elemento a mais na coleção

            foreach (int n in query)
            {
                Console.Write(n + "|"); // 10|20|
            }

            //-----------------------------------------------------------------
            //Exemplo 2:
            Action a = () => Console.WriteLine("Teste");
            
            // Até esta linha nada foi executado ou escrito no console ainda!
            //apenas quando executarmos a Action!
            a(); // Execução tardia (Deferred execution)!


            //-----------------------------------------------------------------
            //Exemplo 3:
            var numeros2 = new List<int>() { 1, 2 };
            var queryExemplo2 = numeros2.Select(n => n * 10);

            foreach (int n in query)
            { 
                Console.Write(n + "|"); //Output no console: 10|20|
            }

            //Limpamos a lista!
            numeros2.Clear();

            foreach (int n in query)
            {
                Console.Write(n + "|"); //Output no console: <nothing>
            }
            Console.Write(query.Count()); //Output no console: 0

            //-----------------------------------------------------------------
            //Exemplo 4:
            var numeros3 = new List<int>() { 1, 2 };

            // o ToList força a enumeração e executa a query imediatamente
            var listaMultiplicadaPor10 = numeros3.Select(n => n * 10).ToList();
            
            // limpamos a lista
            numeros3.Clear();

            //Observe que a listaMultiplicadaPor10 continua com 2 elementos
            Console.WriteLine(listaMultiplicadaPor10.Count); // 2

            foreach (int n in listaMultiplicadaPor10)
            {
                Console.Write(n + "|"); //Output no console: 10|20|
            }

            //-----------------------------------------------------------------
            //Exemplo 5:
            ExemploVariaveisContexto();

            //-----------------------------------------------------------------
            //Exemplo 6:
            ExemploVariaveisContextoComBug();

            //-----------------------------------------------------------------
            //Exemplo 7:
            ExemploVariaveisContextoOk();
        }

        public void ExemploVariaveisContexto()
        {
            int[] numeros = { 1, 2 };
            int fator = 10;

            //construímos a query, onde factor nesse momento
            //esta com o valor de 10
            var query = numeros.Select(n => n * fator);

            //alteramos o valor do factor para 20
            fator = 20;

            //Enumeramos a query
            foreach (int n in query) 
            {
                Console.Write(n + "|"); //Output no console: 20|
            }
        }

        public void ExemploVariaveisContextoComBug()
        {
            try
            {
                Console.WriteLine("Query com BUG:");

                var texto = "Um texto extenso com vários caracteres e letras e números (1,3,4,5,6,7,8,9,0)";
                var numeros = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };

                var query = texto.Where(c => c != '(' && c != ')');

                for (int i = 0; i < numeros.Length; i++)
                {
                    query = query.Where(caractere => caractere != numeros[i]);
                }

                foreach (var caractere in query)
                {
                    Console.Write(caractere);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


        }

        public void ExemploVariaveisContextoOk()
        {
            try
            {
                Console.WriteLine("Query com Sem Bug:");

                var texto = "Um texto extenso com vários caracteres e letras e números (1,3,4,5,6,7,8,9,0)";
                var numeros = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };

                var query = texto.Where(c => c != '(' && c != ')');

                for (int i = 0; i < numeros.Length; i++)
                {
                    char digito = numeros[i];
                    query = query.Where(caractere => caractere != digito);
                }

                foreach (var caractere in query)
                {
                    Console.Write(caractere);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

      
    }
}

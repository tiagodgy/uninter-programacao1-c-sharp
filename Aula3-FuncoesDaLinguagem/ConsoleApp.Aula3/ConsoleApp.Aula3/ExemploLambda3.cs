using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp.Aula3
{
    public static class ListExtensions
    {
        public static int BuscaMaiorValorEmTextosComNumeros(this ICollection<string> textos, Func<string, int> GetValor, Func<List<int>, int> GetMax)
        {
            var valoresInt = new List<int>(textos.Count);
            foreach (var texto in textos)
            {
                var valorInt = GetValor(texto);
                if (valorInt > 0)
                {
                    valoresInt.Add(valorInt);
                }
            }

            return GetMax(valoresInt);
        }
    }

    public class ExemploLambda3
    {
        public ExemploLambda3()
        {
            var textos = new List<string>();
            textos.Add("texto 1");
            textos.Add("texto 2");
            textos.Add("texto");
            textos.Add("texto 10");
            textos.Add("xxxx 150");
            textos.Add("12");

            var maiorValor = textos.BuscaMaiorValorEmTextosComNumeros( 
                (texto) => 
                {
                    var numeros = new string(texto.ToCharArray()
                                                    .Where(c => char.IsDigit(c))
                                                    .ToArray());

                    return string.IsNullOrEmpty(numeros)? 0 : int.Parse(numeros);
                }, 
                (lista) => 
                {
                    lista.Sort();

                    return lista.Last();
                });


            Console.WriteLine("Maior valor: " + maiorValor);
        }
    }

 
}

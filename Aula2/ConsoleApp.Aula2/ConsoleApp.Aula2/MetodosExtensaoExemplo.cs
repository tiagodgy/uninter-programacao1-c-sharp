using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Aula2
{
    public class MetodosExtensaoExemplo
    {
        public MetodosExtensaoExemplo()
        {
            bool isCaps = "aula 2".IsCapitalized();

            Console.WriteLine(isCaps); // false

            string exemplo2 = "String Caps";

            if (exemplo2.IsCapitalized())
            {
                Console.WriteLine("exemplo 2 está em Maiúscula!");
            }


            //Lista de strings
            var listaExemplo = new List<string>();

            //Vamos carregar a lista com 10 objetos
            for (int i = 0; i < 10; i++)
            {
                listaExemplo.Add("item: " + i);
            }

            //Conversão de uma lista para um HashSet utilizando métodos de extensão
            var hashSetExemplo = listaExemplo.ToHashSet();

            var stack = new Stack<string>(listaExemplo);
            stack.ToList();

            var arrayExemplo = new string[100];
            listaExemplo = arrayExemplo.ToList();

            arrayExemplo = listaExemplo.ToArray();
        }
    }

    
    public static class StringHelper
    {
        public static bool IsCapitalized(this string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return false;
            }
            
            return char.IsUpper(s[0]);
        }
    }
}

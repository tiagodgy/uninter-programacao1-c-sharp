using System;
using System.Collections;

namespace ConsoleApp.Aula2
{
    public class IEnumeratorExemplo
    {
        public IEnumeratorExemplo()
        {
            string helloString = "Hello";

            // Uma vez que a classe string implementa a interface IEnumerable, podemos chamar o método GetEnumerator():
            IEnumerator enumerator = helloString.GetEnumerator();
            while (enumerator.MoveNext())
            {
                char c = (char)enumerator.Current;
                Console.Write(c + ".");
            }

            // Resultado no console : H.e.l.l.o.

            foreach (char c in helloString)
            {
                Console.Write(c + ".");
            }
            // Resultado no console : H.e.l.l.o.

        }
    }
}

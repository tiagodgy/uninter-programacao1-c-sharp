using System;
using System.Collections.Generic;

namespace ConsoleApp.Aula2
{
    public class Sets_Dictionarys
    {
        public Sets_Dictionarys()
        {

            //inicia uma string (que também pode ser interpretada como uma coleção de caracteres - char)
            var listaChars = "programação 1 - collections";

            //inicia um HashSet de caracteres
            var letters = new HashSet<char>(listaChars);

            //Verifica se a coleção contém alguma letra
            Console.WriteLine(letters.Contains('p')); // true
            Console.WriteLine(letters.Contains('z')); // false

            //percorre a coleção escrevendo os caracteres no console
            //Observe:
            // NÃO há caracteres repetidos
            foreach (char c in letters)
            {
                Console.Write(c); 
            }
            //Output do Console: progamça 1-cletins


            //--------------------------------------------------------------------------
            // Exemplo dicionario usando uma chave do tipo int
            // e um valor do tipo string
            var dicionario1 = new Dictionary<int, string>();

            //adicionando valores
            dicionario1.Add(1, "primeiro valor");
            dicionario1.Add(2000, "segundo valor");
            dicionario1.Add(50, "terceiro valor");

            //atualizando valores pela cahve
            dicionario1[2000] = "segundo valor - atualizado";

            //exemplo chamando o contains
            Console.WriteLine(dicionario1.ContainsKey(50)); // true
            Console.WriteLine(dicionario1.ContainsKey(4)); // false
            Console.WriteLine(dicionario1.ContainsKey(2)); // false

            //exemplo do TryAdd de uma chave duplicada (50)
            //observe que o retorno é false
            Console.WriteLine(dicionario1.TryAdd(50, "valor repetido de chave")); //false

            //exemplo do TryGetValue. Observe a notação de parâmetro out do c#
            //o parâmetro out é utilizado para que um método possa retornar 
            //mais de um valor de sua execução
            if (dicionario1.TryGetValue(2000, out string valorOutput))
            {
                //o valor da variavel "valorOutput" foi recuperado dentro do TryGetValue
                Console.WriteLine(valorOutput); //segundo valor - atualizado
            }

            //Exemplo de retorno false do TryGetValue para uma chave inesistente
            Console.WriteLine(dicionario1.TryGetValue(300, out string valorOutput2)); //false
            Console.WriteLine(dicionario1.TryGetValue(10, out string valorOutput3)); //false

            //Exemplo do foreach nos elementos KeyValuePair
            foreach (var elementoKeyPairVlue in dicionario1)
            {
                //Monta string através do principal método ToString()
                Console.WriteLine(elementoKeyPairVlue.ToString());

                //Exemplo de acesso Key e Value
                Console.WriteLine(elementoKeyPairVlue.Key);
                Console.WriteLine(elementoKeyPairVlue.Value);
            }

            //Exemplo de foreach nas chaves
            foreach (var chave in dicionario1.Keys)
            {
                Console.WriteLine(chave);
            }

            //Exemplo de foreach de valores
            foreach (var valor in dicionario1.Values)
            {
                Console.WriteLine(valor);
            }


            //--------------------------------------------------------------------------
            //Exemplo Stack
            var stackExemplo = new Stack<int>();
            stackExemplo.Push(1); // Pilha = 1
            stackExemplo.Push(2); // Pilha = 1,2
            stackExemplo.Push(3); // Pilha = 1,2,3

            Console.WriteLine(stackExemplo.Count); // 3
            Console.WriteLine(stackExemplo.Peek()); // Output: 3, Pilha = 1,2,3
            Console.WriteLine(stackExemplo.Pop()); // Output 3, Pilha = 1,2
            Console.WriteLine(stackExemplo.Pop()); // Output 2, Pilha = 1
            Console.WriteLine(stackExemplo.Pop()); // Output 1, Pilha = <empty>
            //Console.WriteLine(stackExemplo.Pop()); // throws exception


            //--------------------------------------------------------------------------
            //Exemplo Queue
            var queueExemplo = new Queue<int>();
            queueExemplo.Enqueue(10); // adiciona um elemento
            queueExemplo.Enqueue(20); // adiciona um elemento

            // Exporta para um array os elementos da fila
            int[] data = queueExemplo.ToArray(); 

            Console.WriteLine(queueExemplo.Count); // "2"
            Console.WriteLine(queueExemplo.Peek()); // "10"
            Console.WriteLine(queueExemplo.Dequeue()); // "10"
            Console.WriteLine(queueExemplo.Dequeue()); // "20"
            Console.WriteLine(queueExemplo.Dequeue()); // throws an exception (fila vazia)
        }
    }
}

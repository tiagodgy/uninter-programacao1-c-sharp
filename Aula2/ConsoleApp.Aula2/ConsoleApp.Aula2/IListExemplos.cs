using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ConsoleApp.Aula2
{
    public class IListExemplos
    {
        public IListExemplos()
        {
            //Exemplo 1:
            //declaração de uma variável IList com sua inicialização pelo tipo concreto
            IList<int> lista1 = new List<int>();

            lista1.Add(1);
            lista1.Add(1000000);

            Console.WriteLine("Count da lista1: " + lista1.Count);
            //Output no Console: Count da lista1: 2

            //verificamos se a lista contém um elemento
            if (lista1.Contains(1000000))
            {
                //removemos o elemento
                lista1.Remove(1000000);
            }

            //Verificamos a quantidade presenta na lista
            Console.WriteLine("Count da lista1: " + lista1.Count);
            //Output no Console: Count da lista1: 1

            //-------------------------------------------------------------------------------------------------------------------
            //Exemplo2:
            //declaração de variável concreta com quantidade inicial alocada
            List<string> lista2 = new List<string>(10);

            lista2.Add("olá");
            lista2.Add("mundo!");

            Console.WriteLine("Count da lista2: " + lista2.Count);
            Console.WriteLine("Capacidade da lista2: " + lista2.Capacity);
            //Output no Console: 
            //Count da lista2: 2
            //Capacidade da lista2: 10

            lista2.AddRange(new string[] { "exemplo","de multiplos","valores","em uma lista","ao mesmo","tempo!"," ","Observe",
                            "que estamos","passando", "multiplas strings em um array,","podemos fazer isso,","pois o método AddRange",
                            "recebe um IEnumerable<T>"});

            
            //Agora observe que inicializamos a Lista com o valor 10 no construtor
            //isso significa que ela começou alocando 10 espaços na memória
            //mas ao realizar o AddRange, vamos passar desse limite
            //a lista irá se auto-dimensionar sozinha para comportar o novo tamanho

            Console.WriteLine("Count da lista2: " + lista2.Count);
            Console.WriteLine("Capacidade da lista2: " + lista2.Capacity);
            //Output no Console: 
            //Count da lista2: 16
            //Capacidade da lista2: 20


            //Abaixo vamos fazer um foreach nos elementos e
            //escreve-los no console, separados por um espaço
            foreach (var elemento in lista2)
            {
                Console.Write(elemento + " ");
            }
            //Output no console:
            //olá mundo! exemplo de multiplos valores em uma lista ao mesmo tempo!   Observe que estamos passando multiplas strings em um array, podemos fazer isso, pois o método AddRange recebe um IEnumerable<T>

            Console.WriteLine();
            Console.WriteLine("Exemplo 3:");
            //-------------------------------------------------------------------------------------------------------------------
            //Exemplo 3
            //Inicializando a lista já com conteúdo alocado
            var lista3 = new List<string>() { "elemento1", "elemento2", "elemento3", "elemento4", "elemento5" };
            
            //O método Insert insere um elemento em uma posição da lista, deslocando o index dos demais a sua direita
            lista3.Insert(2, "elemento6");

            //Escrevemos no console o index do elemento4
            //ele começou com o index 3 e agora estará com o index 4
            Console.WriteLine(lista3.IndexOf("elemento3"));

            //Remove um elemento de um index específico
            lista3.RemoveAt(1);

            //Inverte a ordem dos indices de uma lista
            lista3.Reverse();

            foreach (var elemento in lista3)
            {
                Console.Write(elemento + ", ");
            }

            //Output no console:
            //elemento5, elemento4, elemento3, elemento6, elemento1,

            Console.WriteLine();
            Console.WriteLine("Exemplo 4:");
            //-------------------------------------------------------------------------------------------------------------------
            //Exemplo 4
            var lista4 = new List<string>() { "elemento1", "elemento2", "elemento3" };

            //Aqui estamos usando a propriedade de indexador da lista para buscar um elemento em uma posição específica do array
            //passando o index do elemento a lista realiza uma busca "ótima" e nos retorna rapidamente o elemento
            var elementoEncontrado = lista4[2];

            Console.WriteLine("elementoEncontrado: " + elementoEncontrado);

            //Vamos popular a lista com mais 3 milhões de registros
            for (int i = 4; i < 3000000; i++)
            {
                lista4.Add("elemento" + i);
            }

            //Agora vamos usar dois meios de busca:

            //1: 
            //busca pelo conteúdo, usando o "contains". Nesse caso a lista deve comparar o HashCode dos elementos
            //a fim de encontrar um elemento igual na lista, fazendo isso linearmente (1 por 1) até encontrar o primeiro
            //vamos mensurar também o tempo que levamos para encontrar o elemento dessa forma

            var stopwatch4 = Stopwatch.StartNew();

            if (lista4.Contains("elemento2500000"))
            {
                stopwatch4.Stop();
                Console.WriteLine($"Encontramos o elemento 9000! O seu computador levou: {stopwatch4.ElapsedMilliseconds} milisegundos para encontrar!");
            }

            //2: 
            //busca pelo index do elemento. Vamos usar o indexador para buscar o mesmo elemento anterior
            //nesse caso a lista irá realizar uma busca ótima, retornando "instantaneamente" o elemento
            //vamos mensurar também o tempo que levamos para encontrar o elemento dessa forma

            stopwatch4.Reset();
            stopwatch4.Start();

            //como a lista começa em 0, para buscar o elemento 2500000 devemos buscar o index 2500000-1 (2499999)
            if (lista4[2500000-1] != null)
            {
                stopwatch4.Stop();
                Console.WriteLine($"Encontramos o elemento 9000! O seu computador levou: {stopwatch4.ElapsedMilliseconds} milisegundos para encontrar!");
            }
        }
    }
}

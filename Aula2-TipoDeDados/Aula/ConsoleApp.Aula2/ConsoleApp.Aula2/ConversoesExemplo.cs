using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp.Aula2
{
    public class ConversoesExemplo
    {
        public class Pessoa
        {
            public int Idade { get; set; }
            public string Nome { get; set; }

            public override string ToString()
            {
                return $"Nome: {Nome} - Idade: {Idade}";
            }
        }

        public ConversoesExemplo()
        {
            var arrayBaseExemplo = new Pessoa[5000000];
            var listaExemplo = new List<Pessoa>();
            var hashSetExemplo = new HashSet<Pessoa>();
            var dicionarioExemplo = new Dictionary<int, Pessoa>();


            //vamos popular o array base de forma simples:
            //interando seus endereços e populando com um número de 1 a 5M
            for (int i = 0; i < arrayBaseExemplo.Length; i++)
            {
                arrayBaseExemplo[i] = new Pessoa()
                {
                    Idade = i,
                    Nome = "Pessoa " + i
                };
            }

            //adiciona todos os elementos do nosso Array para uma List
            listaExemplo.AddRange(arrayBaseExemplo);

            //como a lista armazena as referências para tipos de Reference Types
            //se modificarmos o valor de um elemento de nosso array
            //o elemento que a lista referencia também será alterado

            //Observe que o elemento 1000 escreverá no console: Nome: Pessoa 1000 - Idade: 1000
            Console.WriteLine(arrayBaseExemplo[1000]); // Nome: Pessoa 1000 - Idade: 1000

            //Vamos atualizar o nome da pessoa
            arrayBaseExemplo[1000].Nome = "atualizado";

            //Observe que a lista e o array apontam para a mesma referência de objetos
            Console.WriteLine(arrayBaseExemplo[1000]); //Nome: atualizado - Idade: 1000
            Console.WriteLine(listaExemplo[1000]); // Nome: atualizado - Idade: 1000

            //Inicializa o HashSet usando uma lista (ou qualquer ICollection/IEnumerable)
            hashSetExemplo = new HashSet<Pessoa>(listaExemplo);

            //vamos alterar o nome e idade da pessoa 1000
            var pessoa1000 = arrayBaseExemplo[1000];
            pessoa1000.Idade = -1;
            pessoa1000.Nome = "atualizado 1000";

            //Veja que a referência utilizada pela lista já foi alterada
            Console.WriteLine(listaExemplo[1000]); // Nome: atualizado 1000 - Idade: -1

            //Como o HashSet não fornece uma propriedade indexadora (acessar via [])
            //por questões de conceito, vamos usar o TryGetValue para
            //obter o valor do elemento.
            if (hashSetExemplo.TryGetValue(pessoa1000, out Pessoa pessoaOutput))
            {
                //Observe que o HashSet também manteve a referência para o mesmo objeto
                //mesmo tendo uma estrutura de amrazenamento de dados diferente de listas

                Console.WriteLine(pessoaOutput); // Nome: atualizado 1000 - Idade: -1
            }

            //Inicializando um Dictionary
            dicionarioExemplo = new Dictionary<int, Pessoa>(listaExemplo.Count);

            foreach (var pessoa in listaExemplo)
            {
                //estamos usando a "idade da pessoa" como TKey (int)
                //para adicionar no dicionário a KeyValuePair<int,Pessoa> (idade, pessoa)
                //onde o valor da idade esta representando o indice/chave do dicionário
                //lembre-se: caso hajam valores duplicados o dicionário irá lançar uma exceção

                dicionarioExemplo.Add(pessoa.Idade, pessoa);
            }

            //Acessando a pessoa1000
            Console.WriteLine(dicionarioExemplo[pessoaOutput.Idade]); // Nome: atualizado 1000 - Idade: -1
        }
    }
}

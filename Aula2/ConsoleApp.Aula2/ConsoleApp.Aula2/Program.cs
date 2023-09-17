using System;

namespace ConsoleApp.Aula2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Alula 2 - Collections!");

            //Você pode comentar as linhas de exemplo para manter apenas o exemplo desejado
            //de output no console


            //Inicializando um array nativo
            int[] inteiros = new int[10]; //um array de inteiros contendo 10 posições
            var caracteres = new char[2] { 'o', 'i' }; //um array de caracteres com 2 posições já inicializadas na construção
            var versoes = new Version[5]; //um array de uma classe qualquer
            var matriz = new int[3,2];//uma matriz 3x2 (array bi-dimensional)
            var matriz3D = new int[3,3,3];//uma matriz 3x3x3 (array tri-dimensional)


            //Exemplo de Stack para Generics
            ExemploStack exemploStack = new ExemploStack();

            //Exemplo IEnumerator
            IEnumeratorExemplo enumeratorExemplo = new IEnumeratorExemplo();

            //Exemplo de IList
            IListExemplos listExemplos = new IListExemplos();

            //Exemplos de Sets e Dictionarys
            Sets_Dictionarys sets_Dictionarys = new Sets_Dictionarys();

            //Exemplos d econversão entre tipos de coleções
            ConversoesExemplo conversoesExemplo = new ConversoesExemplo();

            //Exemplos de métodos de extensao
            MetodosExtensaoExemplo metodosExtensaoExemplo = new MetodosExtensaoExemplo();

        }
    }
}

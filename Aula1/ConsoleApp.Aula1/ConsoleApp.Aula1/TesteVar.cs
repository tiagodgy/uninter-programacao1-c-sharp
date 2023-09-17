using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Aula1
{
    public class TesteVar
    {
        public void Metodo1()
        {
            //declaração sem usar o var
            Dictionary<string, string> dicionario = new Dictionary<string, string>();

            //declaração usando o var
            var dicionarioComVar = new Dictionary<string, string>();

            if(dicionario.GetType() == dicionarioComVar.GetType())
            {
                //veja que o tipo das duas veriáveis é o MESMO
                //o var apenas ajuda/abstraí a declaração delas
                Console.WriteLine("C# Rocks!");
            }

            //neste caso abaixo o compilador irá lançar um erro em tempo de build
            var x = 5;
            //x = "hello";

            //cuidar com a legibilidade e facilidade de entendimento do código ao usar var
            //o exemplo abaixo demonstra um típico caso de onde devemos procurar ser o mais claro possíveis em nossos nomes de variáveis
            var r = new Random();
            var y = r.Next();
        }
    }
}

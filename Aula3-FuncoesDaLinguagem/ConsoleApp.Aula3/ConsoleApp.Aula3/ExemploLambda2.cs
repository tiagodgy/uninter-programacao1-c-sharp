using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Aula3
{
    public class ExemploLambda2
    {
        public ExemploLambda2()
        {
            Func<int, int, int> multiplicador = (int x, int y) => x * y;

            //Passando a function como referência
            ProcessaNumeros(5, multiplicador, (int result) =>
            {
                Console.WriteLine("resultado: " + result);
            });
            //Output no console:
            //resultado: 0
            //resultado: 33
            //resultado: 132
            //resultado: 300
            //resultado: 532

            //Passando a func e action anonimamente
            ProcessaNumeros(5, 
            //func anonima
            (int x, int y) =>
            {
                return x * y;
            },
            //action anonima
            (int result) =>
            {
                Console.WriteLine("resultado: " + result);
            });

        }

        public void ProcessaNumeros(int quantidade, Func<int, int, int> processador,  Action<int> outputAction)
        {
            for (int i = 0; i < quantidade; i++)
            {
                outputAction(processador(i, i * 100 / 3));
            }
        }
    }
}

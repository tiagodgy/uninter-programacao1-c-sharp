using System;

namespace ConsoleApp.Aula1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Utilizando o "//" podemos adicionar comentários em nosso código, tal como no Java
            Console.WriteLine("Hello World - Declaração de variáveis no c#!");


            //Declaração de tipos primitivos:

            //bool:
            bool a = true;
            bool b = false;
            bool resultBool = a && b; // true AND false = false - operação básica com booleanos
            Console.WriteLine(resultBool);

            //int (inteiros):
            int v1 = 10;
            int v2 = -20;
            int resultInt = v1 + v2; //10 -20 = -10
            uint uv3 = 10 + 10;
            Console.WriteLine(resultInt);
            Console.WriteLine(uv3);

            //long:
            long l1 = 100000000;
            long l2 = -5000;
            long resultLong = l1 + (l2 * l1); //100000000 - 5000 * 100000000 = -499900000000
            Console.WriteLine(resultLong);

            //float:
            float f1 = 10.5f; //note usamos o final (f) para indicar o compilador que trata-se de um float 
            float pi = 3.1415926535f;
            float resultFloat = pi * f1; // 10,5 * 3.1415926535 = 32.9867249
            resultFloat = resultFloat / v2; // -1.64933622
            Console.WriteLine(resultFloat);

            //double
            double d1 = 2000000.1231231313;
            double d2 = 100;
            double resultDouble = d1 * d2; // 2000000.1231231313 * 100 = 200000012.31231311

            //* Notem que aqui usamos o resultado de um float para multiplicar por um double
            //* O compilador realiza um processo boxing e converte o tipo float para um tipo double, resultando em um novo double
            resultDouble = resultDouble * resultFloat; // -329867264.07392859
            Console.WriteLine(resultDouble);

            //char
            char o = 'o';
            char i = 'i';
            char exc = (char)33;

            //Não podemos "somar dois caracteres", pois isso corresponde a uma string
            //então vamos iniciarlizar uma string a partir de um array (lista) de caracteres:
            string resultChar = new string(new char[] { o, i, exc });

            //escrevendo no console:
            Console.WriteLine(resultChar);


            //Declaração de referencia types, ou seja, objetos:

            //string:
            string s1 = "oi!";
            string s2 = new string('x', 5); // "xxxxx"
            string s3 = s1 + s2; // "oi!" + "xxxxx" = "oi!xxxxx"
            Console.WriteLine(s3);

            //objetos
            object obj1 = new object();
            Console.WriteLine(obj1.ToString()); // System.Object - este é um objeto vazio (com um valor default na memória)

            object obj2 = s3;
            Console.WriteLine(obj2.ToString()); // "oi!xxxxx" - este objeto aponta para a mesma referência da string s3



            //Blocos de decisão if:
            int val1 = 10;
            int val2 = 100;
            if (val1 + val2 > 0)
            {
                //executa: "Condição 1 verdadeira"
                Console.WriteLine("Condição 1 verdadeira");
            }

            val2 = int.MinValue;
            if (val1 + val2 > 0)
            {
                Console.WriteLine("Condição 2 verdadeira");
            }
            else
            {
                //executa: "Condição 2 falsa"
                Console.WriteLine("Condição 2 falsa");
            }

            //bloco switch/case
            int teste1 = 1;
            bool csharpRocks = true;

            //teste lógico, se 1 > 0 e a variável csharpRocks for veradeira
            //decidirá em qual "case" cair
            switch (teste1 > 0 && csharpRocks)
            {
                case true:
                    //executa:
                    Console.WriteLine("C# Rocks!");
                    break;
                case false:
                    Console.WriteLine("C# é ruim!");
                    break;
                default:
                    //repare que o compilador lhe ajuda marcadando embaio da palavra console
                    //pois como é uma condição lógica, só temos true e false
                    //o default do bloco switch/case nunca será executado para esta situação
                    Console.WriteLine("Não pode cair aqui!");
                    break;
            }


            //blocos de loop: for
            for (int counter = 0; counter < 5; counter++)
            {
                Console.WriteLine($"Olá, este é um for e esta é a iteração: {counter}");
            }
            //resultado:
            //Olá, este é um for e esta é a iteração: 0
            //Olá, este é um for e esta é a iteração: 1
            //Olá, este é um for e esta é a iteração: 2
            //Olá, este é um for e esta é a iteração: 3
            //Olá, este é um for e esta é a iteração: 4

            //blocos de loop: foreach
            string stringForLoop = "c# is the best!";
            foreach (var caractere in stringForLoop)
            {
                Console.WriteLine(caractere);
            }
            //resultado:
            //c
            //#
            //
            //i
            //s
            //
            //t
            //h
            //e
            //
            //b
            //e
            //s
            //t
            //!


            //blocos de loop - while
            string stringForWhile = "c# rocks!";

            while (stringForWhile.Length > 0)
            {
                Console.WriteLine(stringForWhile);

                stringForWhile = stringForWhile.Substring(0, stringForWhile.Length-1);

                if (stringForWhile.EndsWith("#"))
                {
                    stringForWhile = string.Empty;
                }
            }

            /*
             c# rocks!
             c# rocks
             c# rock
             c# roc
             c# ro
             c# r
             c# 
             c#
            */
        }
    }
}

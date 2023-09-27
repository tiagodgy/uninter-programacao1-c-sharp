using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Aula3
{
    public class ExemploLambda
    {
        public ExemploLambda()
        {
            //cria uma Action (delegate) para o método MostrarData() - sem parametros
            Action acaoMostrarData = MostraData;

            //Executa a action
            //como a Action apenas é um delegate (encapsula) o método original
            //ela executará o método MostrarData
            acaoMostrarData();

            //Cria uma nova action que recebe um parâmetro DateTime
            //Repare que estamos usando o método MostrarData
            //Porém o compilador já entendeu que deve usar o overload (versão do método): MostrarData(Datetime data)
            Action<DateTime> acaoMostrarDataProximoDia = MostraData;

            //Cria uma função que retorna um Datetime
            //Observe que a declaração da função segue o modelo Lambda:
            //•	(input-parameters) => expression
            //No nosso caso é uma função sem parâmetros, então apenas declaramos
            //os parenteses vazios, assim: () => expression
            Func<DateTime> funcDataProx = () => CalculaDataDoProximoDia();

            //Aqui executamos a função e pegamos seu retorno em uma variável
            DateTime dataProximoDia = funcDataProx();

            //Executamos a Action que recebe um Datetime como parâmetro
            //Observe que a chamada se assemelha a um método qualquer
            //porém esta encapsulado pelo delegate (Action<T>)
            acaoMostrarDataProximoDia(dataProximoDia);
        }

        public void MostraData()
        {
            Console.WriteLine($"A data atual é: {DateTime.Now}");
        }

        public void MostraData(DateTime data)
        {
            Console.WriteLine($"A data é: {data}");
        }


        public DateTime CalculaDataDoProximoDia()
        {
            DateTime dataProximoDia = DateTime.Now.AddDays(1);
            return dataProximoDia;
        }
    }
}

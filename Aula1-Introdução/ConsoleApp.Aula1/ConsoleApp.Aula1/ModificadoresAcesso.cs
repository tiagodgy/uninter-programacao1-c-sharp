using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Aula1
{
    public class ModificadoresAcesso
    {
        //torna a variável "quantidade" privada, ou seja, de leitura e escrita exclusiva da classe "ModificadoresAcesso"
        private int quantidade;

        //isso limita o set para que apenas a classe "ModificadoresAcesso" possa alterar seu valor, enquanto o get fica público
        //é como ter um método público de get e outro privado de set
        //muito útil para expor o valor de um campo mas limitar seu acesso a escrita à outras classes
        public bool SetPrivado { get; private set; }

        //torna a variável "nome" publica, ou seja, de leitura e escrita aberta a todas as classes
        public string nome;

        //deixa a propriedade idade visível e alterável apenas à suas subclasses
        protected int Idade { get; set; }

        //limita o acesso a todas as classes e tipos que herdem desta classe 
        protected internal int RecuperarPeso()
        {
            return 10;
        }

        //limita o acesso apenas a classe "ModificadoresAcesso"
        private void CalcularPeso()
        {
            //inicializa uma classe interna aninhada com a classe "ModificadoresAcesso"
            ClasseInterna objeto = new ClasseInterna();
            
            //chama um método com visibilidade interna
            objeto.Calcular();

            //Não podemos executar a linha abaixo pois isso geraria um erro de compilação
            //a variável quantidadeInterna pertecente apenas a "ClasseInterna" pois esta com visibilidade private
            //objeto.quantidadeInterna = 1;
        }


        internal class ClasseInterna
        {
            private int quantidadeInterna;

            //méotodo com visibilidade interna apenas
            internal void Calcular()
            { 
            
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Aula1
{
    interface IComestivel
    {
        void Mastigar(object comida);
        int MaximoComida { get;}
        string Descrever()
        {
            return "Possibilita o comportamento de mastigar um alimento";
        }
    }
}

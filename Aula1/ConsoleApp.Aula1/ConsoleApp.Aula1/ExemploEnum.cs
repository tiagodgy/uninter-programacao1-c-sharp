using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Aula1
{
    /// <summary>
    /// Observe que foi setado um valor explícito para cada item do enum
    /// </summary>
    public enum Direcoes
    { 
        Cima = 1,
        Baixo = 10,
        LadoEsquerdo = 20,
        LadoDireiro = 67
    }

    public class ExemploEnum
    {
        public void MetodoExemploEnum()
        {
            var direcaoCima = Direcoes.Cima;
            var direcaoBaixo = Direcoes.Baixo;

            if ((int)direcaoCima > 20)
            {
                return;
            }

            switch (direcaoCima)
            {
                case Direcoes.Cima:
                    break;
                case Direcoes.Baixo:
                    break;
                case Direcoes.LadoEsquerdo:
                    break;
                case Direcoes.LadoDireiro:
                    break;
                default:
                    break;
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Aula1
{
    public class Boxing_UnBoxing
    {
        public void Exemplo()
        {
            int x = 9;
            object obj = x; // "box"(empacota) o int dentro de um objeto

            // Unboxing reverses the operation, by casting the object back to the original value type:
            // Desempacota a operação acima. Fazendo um "cast" (conversão) do objeto para seu tipo original (int)
            // que neste caso é um value type.
            int y = (int)obj; // Unbox  (desempacota)
        }

        public void ExemploErroCast()
        {
            // O processo de Unboxing requer um cast "explicito". O CLR (runtime) verifica
            // que o value type é do mesmo tipo do objeto. Caso ele não seja, uma exceção 
            // do tipo InvalidCastException é lançada.
            // O exemplo abaixo lançaria uma exeção, pois o value type "long" não é do mesmo tipo que o int

            object obj = 9; // 9 é um int (quando apenas digitamos o valor "cru" na IDE)
            long x = (long)obj; // InvalidCastException será lançada em tempo de execução pelo CLR
        }

        public void ExemploCastOK()
        {
            //O código abaixo funciona sem problemas:
            object obj = 9; // 9 é um int
            long x = (int)obj; //unbox do int e cast implicíto para long
            
            //Assim como o exemplo abaixo também funciona:
            object objeto = 3.5; // 3.5 é automaticamente inferido pela IDE como tipo: double

            // unbox de objeto para double. Depois cast implicíto para int.
            // o valor do y será 3 (pois é apenas a parte inteira do valor 3.5)
            int y = (int)(double)objeto; 
        }

    }
}

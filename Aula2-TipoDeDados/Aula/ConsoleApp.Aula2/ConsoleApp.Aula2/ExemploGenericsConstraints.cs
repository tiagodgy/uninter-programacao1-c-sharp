using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Aula2
{
    public class ExemploGenericsConstraints
    {
        public class Classe1 { }
        public interface Interface1 { }

        public class GenericClass<T, U> where T : Classe1, IEnumerable<T>
                                        where U : new()
        { 
        }


        public class Classe2<T> where T : struct
        {
            public T Clone<T>(T parametro1, T parametro2) where T : IComparable
            {
                return parametro1.CompareTo(parametro2) > 0 ? parametro1 : parametro2;
            }
        }
    }
}

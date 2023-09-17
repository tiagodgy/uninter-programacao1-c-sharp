using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Aula1
{
    abstract class Animal : IComestivel
    {
        public int MaximoComida => 10;

        public abstract void Mastigar(object comida);
    }

    class Cachorro : Animal, ICloneable
    {
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public override void Mastigar(object comida)
        {
        }
    }

    class PetShop
    {
        public void Teste()
        {
            Cachorro cachorro = new Cachorro();

            cachorro.Clone();
            cachorro.Mastigar(new object());
            int maximo = cachorro.MaximoComida;
        }
    }
}

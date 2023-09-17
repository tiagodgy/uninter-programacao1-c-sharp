using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Aula1
{
    class Pessoa
    {
        string Nome { get; set; }

        int idade;

        void SetIdade(int idade)
        {
            this.idade = idade;
        }

        int GetIdade()
        {
            return idade;
        }

        string nomeCompleto;
        public string NomeCompleto
        {
            get 
            {
                return nomeCompleto;
            }
            set 
            {
                if (value.Contains(" "))
                {
                    nomeCompleto = value.Replace(" ", "-");
                    return;
                }

                nomeCompleto = value;
            }
        }

    }
}

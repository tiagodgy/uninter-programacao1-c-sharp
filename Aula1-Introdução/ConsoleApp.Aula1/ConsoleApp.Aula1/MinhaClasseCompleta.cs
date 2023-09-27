using System;

namespace ConsoleApp.Aula1
{
    /// <summary>
    /// Nossa classe abstrata mae. Repare que a herança de System.Object fica marcada com uma cor opaca pelo Visual Studio.
    /// Isso significa que a herença é redundante, ou seja, todas as classes herdam de system.object, mesmo não declararando explicitamente.
    /// </summary>
    public abstract class ClasseMae : System.Object
    {
        //propriedade com protected (visível a todas as subclasses)
        protected long Quantidade { get; set; }

        //construtor
        public ClasseMae(long qtd)
        {
            Quantidade = qtd;
        }

        //método abstrato
        public abstract void MetodoAbstrato(string nome, string sobreNome);

        //método stático (não requer inicialização)
        public static long CalcularTicks(int valor)
        {
            return DateTime.Now.Ticks * valor;
        }
    }

    /// <summary>
    /// Classe filha. Repare no "sealed" que significa que a classe não pode ser herdada ou modificada. Este é um tipo de modificador de acesso
    /// especial de classes.
    /// Observe que ela HERDA da ClasseMae e implementa a interface IColonable
    /// </summary>
    public sealed class MinhaClasseCompleta : ClasseMae, ICloneable
    {
        //propriedade privada
        private string Nome { get; set; }

        //campo/field auxiliar interno (privado)
        string nomeCompletoAuxiliar;

        //Repare que o construtor recebe um valor inteiro e chama o construtor da classe mãe usando a referência "base"
        //passa como parâmetro o valor para um método estático (que não requer que a classe esteja inicializada para executar)
        //passando como retorno deste método o valor para o construtor
        public MinhaClasseCompleta(int qtd) : base(MinhaClasseCompleta.CalcularTicks(qtd))
        {
            //iniciliazação de campos e propriedades
            nomeCompletoAuxiliar = string.Empty;
            Nome = nomeCompletoAuxiliar;
        }

        //método público da interface
        public object Clone()
        {
            return MemberwiseClone();
        }

        //implementação do método abstrato
        public override void MetodoAbstrato(string nome, string sobreNome)
        {
            nomeCompletoAuxiliar = string.Join(" ", nome, sobreNome);
            Nome = nomeCompletoAuxiliar;
        }

        //destrutor/finalizador da classe
        ~MinhaClasseCompleta()
        {
            Nome = null;
        }
    }
}

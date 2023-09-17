using BibliotecaComum.DAL;

namespace ConsoleApp.Aula1
{
    public class ClasseExemplo
    {
        SubDir.Item item = new SubDir.Item();
    }

    public class ClasseExemplo2
    {
        ClasseExemplo3 exemplo3 = new ClasseExemplo3();
    }

    public class ClasseExemplo3
    {
        ClasseExemplo exemplo1 = new ClasseExemplo();
    }
}


namespace ConsoleApp.Aula1.SubDir
{
    public class Item
    {
        ClasseExemplo3 ClasseExemplo2 = new ClasseExemplo3();

        BibliotecaComum.DAL.Comum.Repositorio Repositorio = new BibliotecaComum.DAL.Comum.Repositorio();
        RepositorioConfiguracao configuracao = new RepositorioConfiguracao();
    }
}

namespace BibliotecaComum.DAL.Comum
{
    public class Repositorio
    { 
    
    }
}

namespace BibliotecaComum.DAL
{
    public class RepositorioConfiguracao
    {

    }
}
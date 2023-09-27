using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace ConsoleApp.Aula3
{
    public class ExemploQuerysLinq
    {
        public  ExemploQuerysLinq()
        {
            Projecao();
            Ordenacao();
            Agregacao();
            Join();
        }

        private void Projecao()
        {
            var queryCulturas = CultureInfo.GetCultures(CultureTypes.InstalledWin32Cultures).Select(culture => new
            {
                Nome = culture.DisplayName,
                NomeTecnico = culture.Name,
                NomeEmIngles = culture.EnglishName,
                HashCode = culture.GetHashCode()
            });

            foreach (var cultura in queryCulturas)
            {
                Console.WriteLine($"Nome: {cultura.Nome} - Cultura: {cultura.NomeTecnico} - HashCode: {cultura.HashCode}");
            }
            //Exemplo de output do console:
            //Nome: Dari (Afghanistan) - Cultura: prs-AF - HashCode: -1236946826
            //Nome: Pashto - Cultura: ps - HashCode: -386241222
            //Nome: Pashto(Afghanistan) - Cultura: ps - AF - HashCode: 1214151744
            //Nome: ???? (???????) - Cultura: ps - PK - HashCode: -1365220246
            //Nome: Portuguese - Cultura: pt - HashCode: -1525760948
            //Nome: português(Angola) - Cultura: pt - AO - HashCode: 2058183436
            //Nome: Portuguese(Brazil) - Cultura: pt - BR - HashCode: -96748476
            //Nome: português(Suíça) - Cultura: pt - CH - HashCode: 1345421020
            //Nome: português(Cabo Verde) - Cultura: pt - CV - HashCode: 67000352
            //Nome: português(Guiné Equatorial) - Cultura: pt - GQ - HashCode: 504403706
            //Nome: português(Guiné - Bissau) - Cultura: pt - GW - HashCode: -1070921970
            //Nome: português(Luxemburgo) - Cultura: pt - LU - HashCode: -2086256120
            //Nome: português(RAE de Macau) - Cultura: pt - MO - HashCode: 625552102
            //Nome: português(Moçambique) - Cultura: pt - MZ - HashCode: -1039145068
            //Nome: Portuguese(Portugal) - Cultura: pt - PT - HashCode: -1789600550
            //Nome: português(Sao Tomé e Príncipe) - Cultura: pt - ST - HashCode: 271551798
            //Nome: português(Timor - Leste) - Cultura: pt - TL - HashCode: -219208036
            //Nome: K'iche' - Cultura: quc - HashCode: 1186898704
        }

        private void Join()
        {
            var clientes = new List<Cliente>() { new Cliente() { Id = 1, Nome = "Tiago" }, new Cliente() { Id = 2, Nome = "Pedro" }, new Cliente() { Id = 3, Nome = "Maria" }, };
            var pedidos = new List<Pedido>(100);

            
            int idClienteAuxiliar = 0;
            //gera 100 pedidos distribuindo para os 3 clientes
            for (int i = 0; i < 100; i++)
            {
                idClienteAuxiliar++; //incrementa o auxiliar para o prox. cliente

                var pedido = new Pedido() { Id = i, IdClinte = idClienteAuxiliar, DataPedido = DateTime.Now.AddDays(i * -1) };
                if (idClienteAuxiliar >= 3)
                    idClienteAuxiliar = 0;

                pedidos.Add(pedido); //adiciona o pedido na lista
            }

            //produz um resultado usando LINQ unificando as duas
            //coleções de clientes e pedidos:
            var queryJoin = from p in pedidos
                            join c in clientes on p.IdClinte equals c.Id
                            select new
                            {
                                IdPedido = p.Id,
                                IdCliente = c.Id,
                                NomeCliente = c.Nome,
                                DataPedido = p.DataPedido
                            };

            //enumera resultado
            foreach (var item in queryJoin)
            {
                Console.WriteLine($"IdPedido: {item.IdPedido} | IdCliente: {item.IdCliente} | NomeCliente: {item.NomeCliente} | DataPedido: {item.DataPedido}");
            }

            //Output no console:
            //IdPedido: 0 | IdCliente: 1 | NomeCliente: Tiago | DataPedido: 16 / 05 / 2021 12:04:26
            //IdPedido: 1 | IdCliente: 2 | NomeCliente: Pedro | DataPedido: 15 / 05 / 2021 12:04:26
            //IdPedido: 2 | IdCliente: 3 | NomeCliente: Maria | DataPedido: 14 / 05 / 2021 12:04:26
            //IdPedido: 3 | IdCliente: 1 | NomeCliente: Tiago | DataPedido: 13 / 05 / 2021 12:04:26
            //IdPedido: 4 | IdCliente: 2 | NomeCliente: Pedro | DataPedido: 12 / 05 / 2021 12:04:26
            //IdPedido: 5 | IdCliente: 3 | NomeCliente: Maria | DataPedido: 11 / 05 / 2021 12:04:26
            //IdPedido: 6 | IdCliente: 1 | NomeCliente: Tiago | DataPedido: 10 / 05 / 2021 12:04:26
            //....

        }

        public void Agregacao()
        {
            string[] nomes = { "João", "Silva", "Paulo", "Antonio", "Maria", "Joana" };

            // equivalente ao Lenght ou Count 
            int qtdColecao = nomes.Count();

            // Conta os a minusculos
            int qtdLetraA = nomes.Sum(n => n.Count(c => c == 'a'));

            // Max e Min 
            int[] numeros = { 28, 32, 14 };
            int menor = numeros.Min(); // 14;
            int maior = numeros.Max(); // 32;
        }

        public void Ordenacao()
        {
            string[] nomes = { "João", "Silva", "Paulo", "Antonio", "Maria", "Joana" };

            //exemplo de ordenação ascendente
            var listaAsc = nomes.OrderBy(a=> a).ToList();

            //exemplo de ordenação descendente
            var listaDesc = nomes.OrderByDescending(a=> a).ToList();

            //exemplo de ordenação pelo tamanho da string e depois por ordem alfabética
            var ordenacao2 = nomes.OrderBy(a => a.Length).ThenBy(l => l);
        }

        public void GetDirs()
        {
            DirectoryInfo[] dirs = new DirectoryInfo(@"d:\source").GetDirectories();
            var query =
            from d in dirs
            where (d.Attributes & FileAttributes.System) == 0
            select new
            {
                DirectoryName = d.FullName,
                Created = d.CreationTime,
                Files = from f in d.GetFiles()
                        where (f.Attributes & FileAttributes.Hidden) == 0
                        select new { FileName = f.Name, f.Length, }
            };

            foreach (var dirFiles in query)
            {
                Console.WriteLine("Directory: " + dirFiles.DirectoryName);
                foreach (var file in dirFiles.Files)
                    Console.WriteLine(" " + file.FileName + " Len: " + file.Length);
            }
        }


        public class Cliente
        {
            public int Id { get; set; }
            public string Nome { get; set; }
        }

        public class Pedido
        {
            public int Id { get; set; }
            public int IdClinte { get; set; }
            public DateTime DataPedido { get; set; }
        }

    }
}

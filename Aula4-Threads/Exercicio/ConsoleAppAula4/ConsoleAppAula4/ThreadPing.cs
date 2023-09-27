using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppAula4
{
    public class ThreadPing
    {
        private string endereco = "google.com";
        int countPing = 0;
        bool executePing = false;

        public void StartPing()
        {
            Console.WriteLine("Digite S a qualquer momento para interromper!");

            var threadPingger = new Thread(ExecutePing);
            threadPingger.Start();
            executePing = true;

            var comandoSair = "S";
            var comando = string.Empty;

            /*while(!comandoSair.Equals(comando))
            {
               
                comando = Console.ReadLine();
            }
            executePing = false;*/

            while (threadPingger.IsAlive)
            {
                Console.WriteLine("Aguardando finalizar a thread");

                threadPingger.Join();
            }

            Console.WriteLine("Fim do programa");
        }

        public void ExecutePing()
        {
            while (executePing && countPing < 4)
            {
                Ping pingger = new Ping();
                var pingResponde = pingger.Send(endereco);

                Console.WriteLine($"Ping {countPing}:  {endereco} | Status: {pingResponde.Status} - {pingResponde.RoundtripTime}");
                countPing++;

                Thread.Sleep(2000);
            }
        }
    }
}

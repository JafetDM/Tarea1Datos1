using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Server s = new Server("localhost", 4404); //se crea una instancia de un servidor 
            s.Start(); //inicia al servidor para que espere mensaje
            Console.ReadKey();
            

            while (true)
            {
                Console.Write("Esperando mensaje: ");
                
                Console.ReadKey();
            }
        }
    }
}

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
            Console.Write("Ingrese un puerto válido: ");
            string port = Console.ReadLine();
            int puerto = int.Parse(port); //convierte la entrada en un int 
            Server s = new Server("localhost", puerto); //se crea una instancia de un servidor 
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

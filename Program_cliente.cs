using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese un puerto válido: ");
            string port = Console.ReadLine();
            int puerto = int.Parse(port); //convierte la entrada en un int 
            Cliente c = new Cliente("localhost", puerto); //crea la instancia del cliente
            string msg; //mensaje a enviar
            string nombre; // nombre a enviar
           
            c.Start(); //inicia al cliente.
            



            while (true)


            {

                
                Console.Write("Escriba su mensaje: ");
                msg = Console.ReadLine();
                c.Enviar(msg);
                Console.Write("Ingrese su nombre: ");
                nombre = Console.ReadLine();
                c.EnviarNombre(nombre);
                Console.ReadKey();
            }
        }
    }
}

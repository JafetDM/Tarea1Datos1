using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets; //librerias de .Net para uso de sockets
using System.Threading; //para permitir que mas clientes se conecten

namespace Server
{
    class Server
    {
        IPHostEntry host; //atributo para almacenar información del host
        IPAddress ipAddr; //atributo para escuchar una dirección IP
        IPEndPoint endPoint; // endpoint de la red de comunicación (definido por IP y puerto)

        Socket s_Server;
        Socket s_Cliente; //objetos de cliente y servidor usando socket
        public Server(string ip, int port) //metodo que contiene ip por la cual va a escuchar y el puerto a identificar
        {
            host = Dns.GetHostByName(ip); //DNS Domain Name System resuelve los "nombres" de los host. GetHostByName obtiene el nombre local
            ipAddr = host.AddressList[0]; //devuelve lista de direcciones IP asociadas con el host
            endPoint = new IPEndPoint(ipAddr, port); //define el endpoint

            s_Server = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp); //
            s_Server.Bind(endPoint); //recibe un endpoint para escuchar
            s_Server.Listen(10); //cuantas conexiones van a haber pendientes antes de que empiece a rechazar

        }

        public void Start() //metodo que inicia el server
        {
            Thread t;
            while (true)
            {
                s_Cliente = s_Server.Accept(); //inicializar el cliente para que el servidor acepte al cliente
                t = new Thread(clientConnect); //iniciar un hilo de clientes aceptables
                t.Start(s_Cliente); //iniciarlo
            }

           


        }

        public void clientConnect(object s) //metodo que recibe mensajes de clientes
        {
            Socket s_Cliente = (Socket)s; //crea un socket
            byte[] buffer;
            byte[] buffer2;
            string nombre;
            string mensaje; //variable string para los mensajes
            int endIndex; //variable entera para manejar donde termine el mensaje

            


            while (true)
            {
                Console.Write("Esperando...");
                buffer = new byte[1024]; //máximo de bytes a recibir
                s_Cliente.Receive(buffer); //recibir un buffer de un array de bytes
                mensaje = Encoding.ASCII.GetString(buffer); //Encoding  proporciona métodos para convertir datos
                                                            //ASCCI imprime ciertos caracteres, GetString convirttr los bytes en cadena de texto
                buffer2 = new byte[1024];
                s_Cliente.Receive(buffer2);
                nombre = Encoding.ASCII.GetString(buffer2);
                endIndex = nombre.IndexOf("/0"); //metodo que devuelve el primer caracter "vacio"
                if (endIndex >0)
                    nombre = nombre.Substring(0, endIndex); //metodo que elimina la cadena de caracteres innecesarias 
                Console.WriteLine("Se recibió un  mensaje de: "+nombre+": " + mensaje); //escribe en la consola el mensaje del cliente
            }
        }
    }
}

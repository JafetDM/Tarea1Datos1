using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets; //clases para los sockets

namespace Cliente
{
    class Cliente
    {
        IPHostEntry host; //atributo para almacenar información del host
        IPAddress ipAddr; //atributo para escuchar una dirección IP
        IPEndPoint endPoint; // endpoint de la red de comunicación (definido por IP y puerto)

       
        Socket s_Cliente; //atributo de cliente usando socket

        public Cliente(string ip, int port) //constructor que contiene ip por la cual va a conectar y el puerto a identificar
        {
            host = Dns.GetHostByName(ip); //DNS Domain Name System resuelve los "nombres" de los host. GetHostByName obtiene el nombre local
            ipAddr = host.AddressList[0]; //devuelve lista de direcciones IP asociadas con el host
            endPoint = new IPEndPoint(ipAddr, port); //define el endpoint

            s_Cliente = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp); //se define el tipo de socket
            
           

        }

        public void Start()
        {
            s_Cliente.Connect(endPoint);//recibe un endpoint al cual conectar

        }

        public void Enviar(string msg)
        {
            byte[] byteMsg = Encoding.ASCII.GetBytes(msg); //bytes a enviar
            s_Cliente.Send(byteMsg);
            Console.WriteLine("Mensaje enviado:" + msg);
        }
    }

}

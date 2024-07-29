using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets; //librerias de .Net para uso de sockets

namespace Server
{
    class Server
    {
        IPHostEntry host; //atributo para almacenar información del host
        IPAddress ipAddr; //atributo para escuchar una dirección IP
        IPEndPoint endPoint; // endpoint de la red de comunicación (definido por IP y puerto)

        Socket s_Server;
        Socket s_Cliente; //objetos de cliente y servidor usando socket

    }
}

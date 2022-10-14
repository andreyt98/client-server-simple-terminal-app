// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Net.Sockets;

Console.WriteLine("--------SERVIDOR--------\n");
Console.WriteLine("Esperando mensajes...\n\n");

IPAddress hostEscuchando =  IPAddress.Parse("127.0.0.1");

TcpListener canalDeEscucha = new TcpListener(hostEscuchando, 3000);

Thread hiloDeEscucha = new Thread(new ThreadStart(accionHiloDeEscucha));

hiloDeEscucha.Start();

void accionHiloDeEscucha() {
    canalDeEscucha.Start();
    TcpClient tcpClient = canalDeEscucha.AcceptTcpClient();

    StreamReader streamReader = new StreamReader(tcpClient.GetStream());

    var datoRecibido = streamReader.ReadLine();

    while (datoRecibido != "exit") {
        Console.WriteLine("Nuevo mensaje: " + datoRecibido.ToUpper());
        datoRecibido = streamReader.ReadLine();
    }
}
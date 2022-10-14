// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Net.Sockets;

Console.WriteLine("--------CLIENTE--------\n");
Console.WriteLine("Envie mensajes o escriba 'exit' para finalizar...\n\n");

IPAddress ipServerAddress = IPAddress.Parse("127.0.0.1");

TcpClient tcpClient = new TcpClient();

IPEndPoint ipEndPoint = new IPEndPoint(ipServerAddress, 3000);

tcpClient.Connect(ipEndPoint);

StreamWriter streamWriter = new StreamWriter(tcpClient.GetStream());

String mensaje = "";

while (mensaje != "exit") {
    mensaje = Console.ReadLine();
    streamWriter.WriteLine(mensaje);
    streamWriter.Flush();
}
using System.Net;
using System.Net.Sockets;
using System.Text;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("This is the server");

IPAddress ipaddress = IPAddress.Parse("128.198.219.214");

Int32 port = 7777;

Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

IPEndPoint localEndPoint = new IPEndPoint(ipaddress, port);

listener.Bind(localEndPoint);

listener.Listen(10);

Console.WriteLine("Waiting for message");

Socket socket = listener.Accept();

byte[] buffer = new byte[1024];

int bytesRec = socket.Receive(buffer);

string message = Encoding.ASCII.GetString(buffer, 0, bytesRec);

byte[] msg = Encoding.ASCII.GetBytes(message);

Console.WriteLine("Message from clieht");
Console.WriteLine(message);

socket.Send(msg);


socket.Shutdown(SocketShutdown.Both);
socket.Close();


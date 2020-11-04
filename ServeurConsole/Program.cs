using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;

namespace ServeurConsole
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string connString = "server=127.0.0.1;uid=root;pwd=Tuvexz78$;database=mill";
            ////Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ////System.Net.IPEndPoint ep = new System.Net.IPEndPoint(System.Net.IPAddress.Any, 15);
            ////socket.Bind(ep);
            ////int clientCount;
            ////List<Socket> clientsList = new List<Socket>();
            ////byte[] buffer = new byte[1024];
            ////clientsList.Add(socket);
            ////BinaryFormatter binFormatter = new BinaryFormatter();
            ////var mStream = new MemoryStream();
            //string txt = "ALLO";
            //binFormatter.Serialize(mStream, );
            //byte[] b = mStream.ToArray();
            //for(int i=0; i<b.Length;i++)
            //{
            //    Console.Write(b[i]);
            //}
            ////socket.Listen(0);
            ////Socket newConnection = socket.Accept();
            ////newConnection.Receive(buffer);
            ////binFormatter.Deserialize(mStream);
            ////buffer = mStream.ToArray();
            ////string txt = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
            ////Console.WriteLine(txt);
            ////Console.WriteLine("Done");
            //foreach(Socket x in clientsList)
            //{
            //    Console.WriteLine(x.ToString());
            //}
            //Console.WriteLine("");
        }
    }
}

using System.Net.Sockets;
using Godot;

namespace Telraam_sim
{
    public class LiveStreamer
    {
        private static LiveStreamer _myInstance;
        private TcpClient tcpClient;

        public bool Streaming { get; set; }

        private LiveStreamer()
        {
            tcpClient = new TcpClient();
        }

        public static LiveStreamer GetInstance()
        {
            return _myInstance ?? (_myInstance = new LiveStreamer());
        }

        public void Start()
        {
            Streaming = true;
            tcpClient.Connect("localhost", 4564);
        }

        public void Stop()
        {
            Streaming = false;
            tcpClient.Close();
        }

        public void Send(byte[] message)
        {
            tcpClient.GetStream().Write(message, 0, message.Length);
        }

        public void SendString(string message)
        {
            Send(message.ToUTF8());
        }
    }
}
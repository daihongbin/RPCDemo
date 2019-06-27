using Grpc.Core;
using System;

namespace GrpcDemo.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var channel = new Channel("localhost:50051", ChannelCredentials.Insecure);
            var client = new Server.Greeter.GreeterClient(channel);

            var reply =  client.SayHello(
                new Server.HelloRequest { Name = "客户端" });
            Console.WriteLine("回复：" + reply.Message);

            Console.WriteLine("任意键退出。。。。");
            Console.ReadKey();
        }
    }
}

using GrpcDemo.Server.Services;
using System;

namespace GrpcDemo.Server
{
    class Program
    {
        const int Port = 50051;

        public static void Main(string[] args)
        {
            Grpc.Core.Server server = new Grpc.Core.Server
            {
                Services =
                {
                    Greeter.BindService(new GreeterService())
                },
                Ports = {new Grpc.Core.ServerPort("localhost", Port, Grpc.Core.ServerCredentials.Insecure)}
            };
            server.Start();

            Console.WriteLine("gRPC服务开启的端口 " + Port);
            Console.WriteLine("任意键退出");
            Console.ReadKey();

            server.ShutdownAsync().Wait();
        }
    }
}

using GrpcDemo.AspGrpcServer.Services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;

namespace GrpcDemo.AspGrpcServer
{
    public class Program
    {
        const int Port = 50051;

        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            Grpc.Core.Server server = new Grpc.Core.Server
            {
                Services =
                {
                    Greeter.BindService(new GreeterService())
                },
                Ports = { new Grpc.Core.ServerPort("localhost", Port, Grpc.Core.ServerCredentials.Insecure) }
            };
            server.Start();

            Console.WriteLine("gRPC服务开启的端口 " + Port);
            Console.WriteLine("任意键退出");
            Console.ReadKey();

            host.Run();

            server.ShutdownAsync().Wait();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}

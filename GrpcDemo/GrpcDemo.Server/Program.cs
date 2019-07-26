using Consul;
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

            RegisterConsul();

            Console.ReadKey();

            server.ShutdownAsync().Wait();
        }

        public static void RegisterConsul()
        {
            //请求注册的Consul地址
            var consulClient = new ConsulClient(x => x.Address = new Uri($"http://202.135.136.193:8500"));

            //grpc用的check，基于tcp的
            var grpcCheck = new AgentServiceCheck
            {
                DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5),
                Interval = TimeSpan.FromSeconds(10),
                TCP = $"localhost:50051", //TCP健康监测
                Timeout = TimeSpan.FromSeconds(5)
            };

            //注册服务到Consul里去
            var registration = new AgentServiceRegistration
            {
                Checks = new[] { grpcCheck },
                ID = Guid.NewGuid().ToString(),
                Name = "GrpcConsul",
                Address = "127.0.0.1",
                Port = 50051,
                Tags = new[] { $"urlprefix-/GrpcConsul" } ////添加 urlprefix-/servicename 格式的 tag 标签，以便 Fabio 识别
            };

            consulClient.Agent.ServiceRegister(registration).Wait(); //服务启动时注册，内部实现其实就是使用 Consul API 进行注册（HttpClient发起）
            //lifetime.ApplicationStopping.Register(() =>
            //{
            //    consulClient.Agent.ServiceDeregister(registration.ID).Wait(); //服务停止时取消注册
            //});
        }
    }
}

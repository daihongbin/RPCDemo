using System;
using System.Net.Http;
using System.Threading.Tasks;
using Grpc.Core;
using GrpcGreeter;
using Grpc.Net.Client;

namespace GrpcGreeterClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //第一种调用方式
            //实例化 HttpClient，其包含用于创建与 gRPC 服务的连接的信息。
            //使用 HttpClient 构造 Greeter 客户端，监听本地的50051端口。
            // AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport",true);
            // var httpClient = new HttpClient();
            // // The port number(50051) must match the port of the gRPC server.
            // httpClient.BaseAddress = new Uri("http://localhost:50051");
            // var client = GrpcClient.Create<Greeter.GreeterClient>(httpClient);

            // //调用服务并输出返回内容
            // var reply = await client.SayHelloAsync(
            //                   new HelloRequest { Name = "客户端" });
            // Console.WriteLine("Greeting: " + reply.Message);
            // Console.WriteLine("Press any key to exit...");
            // Console.ReadKey();

            var channel = new Channel("localhost:50051", ChannelCredentials.Insecure);
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(
                            new HelloRequest { Name = "客户端" });
            Console.WriteLine("Greeting: " + reply.Message);
            await channel.ShutdownAsync();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}

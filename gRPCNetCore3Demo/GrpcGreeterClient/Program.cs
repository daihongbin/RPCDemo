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
            AppContext.SetSwitch(
                "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport",
                true);
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:50051");
            var client = GrpcClient.Create<Greeter.GreeterClient>(httpClient);
            var reply = await client.SayHelloAsync(
                new HelloRequest {Name = "GreeterClient"});
            Console.WriteLine("你好:" + reply.Message);
            Console.WriteLine("按任意键退出！");
            Console.ReadKey();
            
            //请求调用的时候也可以进行一些设置
            /*var channel = new Channel("localhost:5001",ChannelCredentials.Insecure,new[]
            {
                new ChannelOption(ChannelOptions.MaxSendMessageLength,2 * 1024 * 1024),
                new ChannelOption(ChannelOptions.MaxReceiveMessageLength,5 * 1024 * 1024)
            });
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(
                new HelloRequest {Name = "dd"});
            Console.WriteLine("回复：" + reply.Message);
            await channel.ShutdownAsync();
            Console.WriteLine("任意键退出。。。。");
            Console.ReadKey();*/
        }
    }
}
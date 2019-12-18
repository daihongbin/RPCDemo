using AspNetCoregRpcService;
using Grpc.Net.Client;
using System;
using System.Threading.Tasks;

namespace AspNetCoregRpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(new HelloRequest { Name = "Michael" });
            Console.WriteLine("Greeter 服务返回数据：" + reply.Message);

            var catClient = new LuCat.LuCatClient(channel);
            var catReply = await catClient.SuckingCatAsync(new Google.Protobuf.WellKnownTypes.Empty());
            Console.WriteLine("调用撸猫服务：" + catReply.Message);
        }
    }
}

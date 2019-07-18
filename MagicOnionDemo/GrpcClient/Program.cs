using Grpc.Core;
using MagicOnion.Client;
using ServerDefinition.Service;
using System;

namespace GrpcClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var channel = new Channel("202.135.136.193", 8080,ChannelCredentials.Insecure);
            var testClient = MagicOnionClient.Create<ITest>(channel);
            var helloClient = MagicOnionClient.Create<IHello>(channel);
            var worldClient = MagicOnionClient.Create<IWorld>(channel);

            var result = testClient.Sum(100, 200).ResponseAsync.Result;
            Console.WriteLine("Test调用结果：" + result);
            Console.WriteLine($"Hello调用结果：{helloClient.Hello("李四").ResponseAsync.Result}");
            Console.WriteLine($"World调用结果：{worldClient.World("李四").ResponseAsync.Result}");


            //var channel2 = new Channel("202.135.136.193", 8081, ChannelCredentials.Insecure);
            //var client2 = MagicOnionClient.Create<ITest>(channel2);
            //var result2 = client2.SumAsync(100, 200).ResponseAsync.Result;
            //Console.WriteLine("客户端接收：" + result2);
        }
    }
}

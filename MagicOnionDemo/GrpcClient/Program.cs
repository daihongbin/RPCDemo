using System;
using Grpc.Core;
using MagicOnion.Client;
using ServerDefinition;

namespace GrpcClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var channel = new Channel("202.135.136.193", 8080,ChannelCredentials.Insecure);
            var client = MagicOnionClient.Create<ITest>(channel);
            var result = client.SumAsync(100, 200).ResponseAsync.Result;
            Console.WriteLine("客户端接收：" + result);

            //var channel2 = new Channel("202.135.136.193", 8081, ChannelCredentials.Insecure);
            //var client2 = MagicOnionClient.Create<ITest>(channel2);
            //var result2 = client2.SumAsync(100, 200).ResponseAsync.Result;
            //Console.WriteLine("客户端接收：" + result2);
        }
    }
}

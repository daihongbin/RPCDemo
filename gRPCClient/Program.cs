﻿using System;
using Grpc.Core;
using GRPCDemo;

namespace gRPCClient
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Channel channel = new Channel("127.0.0.1:9007",ChannelCredentials.Insecure);
            
            var client = new gRPC.gRPCClient(channel);
            var reply = client.SayHello(new HelloRequest {Name = "LineZero"});
            Console.WriteLine("来自" + reply.Message);

            channel.ShutdownAsync().Wait();
            Console.WriteLine("任意键退出...");
            Console.ReadKey();
        }
    }
}
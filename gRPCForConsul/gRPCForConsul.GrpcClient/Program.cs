﻿using gRPCForConsul.GrpcClient.Framework;
using gRPCForConsul.GrpcClient.RpcClient;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace gRPCForConsul.GrpcClient
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection service = new ServiceCollection();

            //注册对象
            service.AddImplement();

            //注入使用对象
            var provider = service.BuildServiceProvider();

            var exeArg = string.Empty;
            Console.WriteLine("Grpc调用！");
            Console.WriteLine("-c\t调用Grpc服务;");
            Console.WriteLine("-q\t退出服务;");

            while (true)
            {
                exeArg = Console.ReadKey().KeyChar.ToString();
                Console.WriteLine();

                if (exeArg.ToLower().Equals("c",StringComparison.CurrentCultureIgnoreCase))
                {
                    //调用服务
                    var rpcClient = provider.GetService<IMsgClient>();
                    rpcClient.GetSum(10,1);
                }
                else if (exeArg.ToLower().Equals("q",StringComparison.CurrentCultureIgnoreCase))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("参数异常");
                }
            }
        }
    }
}

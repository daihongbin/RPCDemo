using gRPCForConsul.GrpcClient.Consul;
using gRPCForConsul.GrpcClient.Framework.Entity;
using gRPCForConsul.GrpcClient.LoadBalance;
using gRPCForConsul.GrpcClient.RpcClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace gRPCForConsul.GrpcClient.Framework
{
    public static class DependencyInitialize
    {

        //注册对象
        public static void AddImplement(this IServiceCollection services)
        {
            //添加json文件路径
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");

            //创建配置根对象
            var configurationRoot = builder.Build();

            //注册全局配置
            services.AddConfigImplement(configurationRoot);

            //注册服务发现
            services.AddScoped<IAppFind,AppFind>();

            //注册负载均衡
            if (configurationRoot["LoadBalancer"].Equals("WeightRound",StringComparison.CurrentCultureIgnoreCase))
            {
                services.AddSingleton<ILoadBalance,WeightRoundBalance>();
            }

            //注册rpc客户端
            services.AddTransient<IMsgClient, MsgClient>();
        }

        //注册全局配置扩展方法
        public static void AddConfigImplement(this IServiceCollection services,IConfigurationRoot configurationRoot)
        {
            //注册配置对象
            services.AddOptions();

            services.Configure<GrpcServiceSettings>(configurationRoot.GetSection(nameof(GrpcServiceSettings)));
            services.Configure<ConsulService>(configurationRoot.GetSection(nameof(ConsulService)));
        }
    }
}

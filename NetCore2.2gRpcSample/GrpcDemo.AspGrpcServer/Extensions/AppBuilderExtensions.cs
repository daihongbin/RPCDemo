using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System;
using WebAppForConsul.Entities;

namespace GrpcDemo.AspGrpcServer.AspGrpcServerExtensions
{
    public static class AppBuilderExtensions
    {
        public static IApplicationBuilder RegisterConsul(this IApplicationBuilder app, IApplicationLifetime lifetime,ServiceEntity serviceEntity)
        {
            //请求注册的Consul地址
            var consulClient = new ConsulClient(x => x.Address = new Uri($"http://{serviceEntity.ConsulIP}:{serviceEntity.ConsulPort}"));

            //普通restful用的check
            //var httpCheck = new AgentServiceCheck
            //{
            //    DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5),//服务启动多久后注册
            //    Interval = TimeSpan.FromSeconds(10),//健康检查时间间隔，或者称之为心跳间隔
            //    HTTP = $"http://{serviceEntity.IP}:{serviceEntity.Port}/api/health",//健康检查地址
            //    //HTTP = $"http://{serviceEntity.IP}:5000/api/health",//健康检查地址，这里因为集成在asp.net core里，所有健康监测地址的端口和rpc不一样
            //    Timeout = TimeSpan.FromSeconds(5)
            //};

            //grpc用的check，基于tcp的
            var grpcCheck = new AgentServiceCheck
            {
                DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5),
                Interval = TimeSpan.FromSeconds(10),
                TCP = $"{serviceEntity.IP}:{serviceEntity.Port}", //TCP健康监测
                Timeout = TimeSpan.FromSeconds(5)
            };

            //注册服务到Consul里去
            var registration = new AgentServiceRegistration
            {
                Checks = new[] {grpcCheck},
                ID = Guid.NewGuid().ToString(),
                Name = serviceEntity.ServiceName,
                Address = serviceEntity.IP,
                Port = serviceEntity.Port,
                Tags = new[] { $"urlprefix-/{serviceEntity.ServiceName}" } ////添加 urlprefix-/servicename 格式的 tag 标签，以便 Fabio 识别
            };

            consulClient.Agent.ServiceRegister(registration).Wait(); //服务启动时注册，内部实现其实就是使用 Consul API 进行注册（HttpClient发起）
            lifetime.ApplicationStopping.Register(() => 
            {
                consulClient.Agent.ServiceDeregister(registration.ID).Wait(); //服务停止时取消注册
            });
            
            return app;
        }
    }
}

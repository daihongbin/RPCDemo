using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using GrpcGreeter.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GrpcGreeter
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //简易注册Grpc服务
            services.AddGrpc();

            //这样配置，会覆盖所有的服务配置
//            services.AddGrpc(options =>
//            {
//                options.EnableDetailedErrors = true;
//                options.ReceiveMaxMessageSize = 2 * 1024 * 1024;
//                options.SendMaxMessageSize = 5 * 1024 * 1024;
//            });
            
            //可以为单个服务进行配置
//            services.AddGrpc().AddServiceOptions<GreeterService>(options =>
//            {
//                options.ReceiveMaxMessageSize = 2 * 1024 * 1024;
//                options.SendMaxMessageSize = 2 * 1024 * 1024;
//            });

            //所有配置
//            services.AddGrpc(options =>
//            {
//                //可以从服务器发送的最大邮件大小（以字节为单位）。尝试发送超过配置的最大邮件大小的邮件会导致异常。
//                options.SendMaxMessageSize = 5 * 1024 * 1024;
//                //服务器可以接收的最大邮件大小（以字节为单位）。如果服务器收到超过此限制的消息，则会引发异常。增加此值可使服务器接收更大的消息，但可能会对内存消耗产生负面影响。
//                options.ReceiveMaxMessageSize = 2 * 1024 * 1024;
//                //如果true在服务方法中抛出异常，则会向客户端返回详细的异常消息。默认是false。设置EnableDetailedErrors为true可以泄露敏感信息。
//                options.EnableDetailedErrors = false;
//                //用于压缩和解压缩消息的压缩提供程序的集合。可以创建自定义压缩提供程序并将其添加到集合中。默认配置的提供程序支持gzip压缩。
//                options.CompressionProviders = null;
//                //压缩算法用于压缩从服务器发送的消息。该算法必须与压缩提供程序匹配CompressionProviders。对于压缩响应的算法，客户端必须通过在grpc-accept-encoding标头中发送它来指示它支持该算法。
//                options.ResponseCompressionAlgorithm = null;
//                //用于压缩从服务器发送的消息的压缩级别。
//                options.ResponseCompressionLevel = CompressionLevel.Fastest;
//            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // Communication with gRPC endpoints must be made through a gRPC client.
                // To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909
                endpoints.MapGrpcService<GreeterService>(); //每个gRPC服务通过MapGrpcService方法进行注册
                endpoints.MapGrpcService<TestService>();
            });
        }
    }
}
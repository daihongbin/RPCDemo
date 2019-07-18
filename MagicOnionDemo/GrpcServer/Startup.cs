using Grpc.Core;
using MagicOnion.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServerDefinition;
using ServerDefinition.Service;
using System;

namespace GrpcServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            #region 注册Grpc
            //通过反射去拿
            MagicOnionServiceDefinition service = MagicOnionEngine.BuildServerServiceDefinition(
                    new[] {typeof(ITest).Assembly}, //如果实现的服务层在另一个程序集，需添加此项
                    new MagicOnionOptions(true)
                    {
                        MagicOnionLogger = new MagicOnionLogToGrpcLogger()
                    }
                );

            var serverAddress = this.Configuration["Service:LocalIPAddress"];
            var serverPort = Convert.ToInt32(this.Configuration["Service:Port"]);
            Server server = new Server
            {
                Services = { service },
                Ports =
                {
                    new ServerPort(serverAddress,serverPort,ServerCredentials.Insecure)//读取配置文件
                }
            };
            server.Start();
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

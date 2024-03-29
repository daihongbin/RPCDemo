﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gRPCForConsul.Hosting.Consul.Entity;
using gRPCForConsul.Hosting.Extensions;
using gRPCForConsul.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace gRPCForConsul.Hosting
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //注册全局配置
            services.AddOptions();
            services.Configure<Server.Entity.GrpcService>(Configuration.GetSection(nameof(Server.Entity.GrpcService)));
            services.Configure<HealthService>(Configuration.GetSection(nameof(HealthService)));
            services.Configure<ConsulService>(Configuration.GetSection(nameof(ConsulService)));

            //注册rpc服务
            services.AddSingleton<IRpcConfig, RpcConfig>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,IApplicationLifetime lifetime,IOptions<HealthService> healthService,IOptions<ConsulService> consulService,
            IRpcConfig rpc)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //添加健康检查路由地址
            app.Map("/health",HealthMap);

            //服务注册
            app.RegisterConsul(lifetime,healthService,consulService);

            //启动rpc服务
            rpc.Start();
        }

        #region private_method
        private static void HealthMap(IApplicationBuilder app)
        {
            app.Run(async (context) => 
            {
                await context.Response.WriteAsync("OK");
            });
        }
        #endregion
    }
}

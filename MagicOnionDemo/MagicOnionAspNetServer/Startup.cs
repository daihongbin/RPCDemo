using Grpc.Core;
using MagicOnion;
using MagicOnion.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;
using MagicOnion.HttpGateway.Swagger;
using MagicOnion.HttpGateway.Swagger.Schemas;

namespace MagicOnionAspNetServer
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //添加服务
            var service = MagicOnionEngine.BuildServerServiceDefinition(new MagicOnionOptions(true)
            {
                MagicOnionLogger = new MagicOnionLogToGrpcLogger()
            });

            var server = new Server
            {
                Services = {service},
                Ports = {new ServerPort("202.135.136.193",8800, ServerCredentials.Insecure) }
            };

            services.AddSwaggerGen(c => 
            {
                var filePath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath,"Swagger.xml");
                c.IncludeXmlComments(filePath);
            });

            server.Start();

            //添加服务
            services.Add(new ServiceDescriptor(typeof(MagicOnionServiceDefinition),service));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var magicOnion = app.ApplicationServices.GetService<MagicOnionServiceDefinition>();

            ///使用MagicOnion的Swagger扩展，就是让你的rpc接口也能在swagger页面上显示
            //下面这些东西你可能乍一看就懵逼，但你看到页面的时候就会发现，一个萝卜一个坑。
            //注意：swagger原生用法属性都是大写的，这里是小写。
            app.UseMagicOnionSwagger(magicOnion.MethodHandlers,new SwaggerOptions("MagicOnion.Server", "Swagger Integration Test", "/")
            {
                Info = new Info
                {
                    title = "MGrpc",
                    version = "v1",
                    description = "This is the API-Interface for MGrpc",
                    termsOfService = "By xxx",
                    contact = new Contact
                    {
                        name = "xxx",
                        email = "xxxxxxx@xx.com"
                    }
                },
                //使用Swagger生成的xml，就是你接口的注释
                XmlDocumentPath = PlatformServices.Default.Application.ApplicationBasePath + "Swagger.xml"
            });

            app.UseMagicOnionHttpGateway(magicOnion.MethodHandlers,new Channel("202.135.136.193:8800",ChannelCredentials.Insecure));

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger(c => 
            {
                c.RouteTemplate = "swagger/{documentName}/swagger.json";
            });

            app.UseSwaggerUI(c => 
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API-v1");
                //c.ShowJsonEditor();
                //c.ShowRequestHeaders();
            });
            app.UseSwagger();
            app.UseMvc();
        }
    }
}

using Grpc.Core;
using gRPCForConsul.Server.RpcService;
using GRPCForConsul.Server;
using Microsoft.Extensions.Options;
using System;

namespace gRPCForConsul.Server
{
    public class RpcConfig:IRpcConfig
    {
        private Grpc.Core.Server _server;

        static IOptions<Entity.GrpcService> GrpcSettings;

        public RpcConfig(IOptions<Entity.GrpcService> grpcSettings)
        {
            GrpcSettings = grpcSettings;
        }

        public void Start()
        {
            _server = new Grpc.Core.Server
            {
                Services =
                {
                    MsgService.BindService(new MsgServiceImpl())
                },
                Ports = { new ServerPort(GrpcSettings.Value.IP, GrpcSettings.Value.Port, ServerCredentials.Insecure) }
            };

            _server.Start();

            Console.WriteLine($"Grpc ServerListening On Port {GrpcSettings.Value.Port}");
        }
    }
}

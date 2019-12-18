using System.Threading.Tasks;
using Grpc.Core;

namespace GrpcDemo.AspGrpcServer.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply { Message = $"你好，{request.Name},这里是asp.net server" });
        }
    }
}

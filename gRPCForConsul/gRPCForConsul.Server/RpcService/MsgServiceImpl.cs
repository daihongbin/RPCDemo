using Grpc.Core;
using Snai.GrpcService.Protocol;
using System;
using System.Threading.Tasks;

namespace gRPCForConsul.Server.RpcService
{
    public class MsgServiceImpl:MsgService.MsgServiceBase
    {
        public override Task<GetMsgSumReply> GetSum(GetMsgNumRequest request, ServerCallContext context)
        {
            var result = new GetMsgSumReply
            {
                Sum = request.Num1 + request.Num2
            };

            Console.WriteLine(request.Num1 + "+" + request.Num2 + "=" + result.Sum);

            return Task.FromResult(result);
        }
    }
}

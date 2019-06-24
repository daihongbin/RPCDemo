using System;
using System.Threading.Tasks;
using Grpc.Core;
using GRPCNetCoreDemo.Protocol;

namespace gRPCNetCoreDemo.Impl
{
    public class MsgServiceImpl : MsgService.MsgServiceBase
    {
        public MsgServiceImpl()
        {

        }

        public override async Task<GetMsgSumReply> GetSum(GetMsgNumRequest request, ServerCallContext context)
        {
            var result = new GetMsgSumReply();
            result.Sum = request.Num1 + request.Num2;

            return result;
        }
    }
}

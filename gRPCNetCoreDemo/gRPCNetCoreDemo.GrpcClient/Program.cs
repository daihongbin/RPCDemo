using System;
using GRPCNetCoreDemo.Protocol;

namespace gRPCNetCoreDemo.GrpcClient
{
    class Program
    {
        static void Main(string[] args)
        {
            GetMsgSumReply msgSum = MsgServiceClient.GetSum(10,2);

            Console.WriteLine("grpc client Call GetSum():" + msgSum.Sum);
            Console.WriteLine("任意键退出...");
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace gRPCForConsul.GrpcClient.RpcClient
{
    public interface IMsgClient
    {
        void GetSum(int num1,int num2);
    }
}

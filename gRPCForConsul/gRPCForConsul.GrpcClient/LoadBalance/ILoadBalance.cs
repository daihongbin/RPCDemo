using System;
using System.Collections.Generic;
using System.Text;

namespace gRPCForConsul.GrpcClient.LoadBalance
{
    public interface ILoadBalance
    {
        string GetGrpcService(string serviceName);
    }
}

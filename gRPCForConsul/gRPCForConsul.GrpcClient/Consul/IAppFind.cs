using System.Collections.Generic;

namespace gRPCForConsul.GrpcClient.Consul
{
    public interface IAppFind
    {
        IEnumerable<string> FindConsul(string serviceName);
    }
}

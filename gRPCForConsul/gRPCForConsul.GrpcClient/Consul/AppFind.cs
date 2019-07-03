using gRPCForConsul.GrpcClient.Framework.Entity;
using gRPCForConsul.GrpcClient.Utils;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Newtonsoft.Json;
using gRPCForConsul.GrpcClient.Consul.Entity;

namespace gRPCForConsul.GrpcClient.Consul
{
    /*
     * 服务发现
     * (服务和健康信息)http://localhost:8500/v1/health/service/GrpcService
     * (健康信息)http://localhost:8500/v1/health/checks/GrpcService
     */
    public class AppFind:IAppFind
    {
        static IOptions<GrpcServiceSettings> GrpcSettings;

        static IOptions<ConsulService> ConsulSettings;

        public AppFind(IOptions<GrpcServiceSettings> grpcSettings,IOptions<ConsulService> consulSettings)
        {
            GrpcSettings = grpcSettings;

            ConsulSettings = consulSettings;
        }

        public IEnumerable<string> FindConsul(string serviceName)
        {
            var headers = new Dictionary<string, string>();
            var timeout = 5;

            var consul = ConsulSettings.Value;
            var findUrl = $"http://{consul.IP}:{consul.Port}/v1/health/checks/{serviceName}";

            var findResult = HttpHelper.HttpGet(findUrl,headers,timeout);
            if ("".Equals(findResult))
            {
                var grpcServices = GrpcSettings.Value.GrpcServices;
                return grpcServices.Where(w => w.ServiceName.Equals(serviceName,StringComparison.CurrentCultureIgnoreCase))
                                    .Select(s => s.ServiceID);
            }

            var findCheck = JsonConvert.DeserializeObject<List<HealthCheck>>(findResult);

            return findCheck.Where(w => w.Status.Equals("passing",StringComparison.CurrentCultureIgnoreCase)).Select(s => s.ServiceID);
        }
    }
}

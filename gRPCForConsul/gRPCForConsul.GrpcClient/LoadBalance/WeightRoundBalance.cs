using gRPCForConsul.GrpcClient.Consul;
using gRPCForConsul.GrpcClient.Framework.Entity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace gRPCForConsul.GrpcClient.LoadBalance
{
    public class WeightRoundBalance : ILoadBalance
    {
        int Balance;

        IOptions<GrpcServiceSettings> GrpcSettings;

        IAppFind AppFind;

        public WeightRoundBalance(IOptions<GrpcServiceSettings> grpcSettings,IAppFind appFind)
        {
            Balance = 0;

            GrpcSettings = grpcSettings;

            AppFind = appFind;
        }

        public string GetGrpcService(string serviceName)
        {
            var grpcServices = GrpcSettings.Value.GrpcServices;

            var healthServiceID = AppFind.FindConsul(serviceName);

            if (grpcServices == null || grpcServices.Count <= 0
                || healthServiceID == null || healthServiceID.Count() <= 0)
            {
                return string.Empty;
            }

            //健康的服务
            var healthServices = new List<Framework.Entity.GrpcService>();
            foreach (var service in grpcServices)
            {
                foreach (var health in healthServiceID)
                {
                    if (service.ServiceID.Equals(health,StringComparison.CurrentCultureIgnoreCase))
                    {
                        healthServices.Add(service);
                        break;
                    }
                }
            }
            if (healthServices == null || healthServices.Count() <= 0)
            {
                return string.Empty;
            }

            //加权轮询
            var services = new List<string>();
            foreach (var service in healthServices)
            {
                services.AddRange(Enumerable.Repeat(service.IP + ":" + service.Port, service.Weight));
            }

            var servicesArray = services.ToArray();
            Balance = Balance % servicesArray.Length;

            var grpcUrl = servicesArray[Balance];
            Balance = Balance + 1;

            return grpcUrl;
        }
    }
}

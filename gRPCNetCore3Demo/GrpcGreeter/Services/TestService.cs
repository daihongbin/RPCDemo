using Grpc.Core;
using System.Threading.Tasks;

namespace GrpcGreeter.Services
{
    public class TestService : Test.TestBase
    {
        public override Task<HiReply> Hi(HiRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HiReply
            {
                Msg = request.Person.Name
            });
        }
    }
}

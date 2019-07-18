using MagicOnion;
using MagicOnion.Server;
using ServerDefinition.Service;

namespace ServerDefinition.Impl
{
    public class HelloService : ServiceBase<IHello>, IHello
    {
        public UnaryResult<string> Hello(string name)
        {
            return new UnaryResult<string>($"你好 {name}");
        }
    }
}

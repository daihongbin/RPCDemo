using MagicOnion;
using MagicOnion.Server;
using ServerDefinition.Service;

namespace ServerDefinition.Impl
{
    public class Test : ServiceBase<ITest>,ITest
    {
        public UnaryResult<string> Sum(int x, int y)
        {
            return new UnaryResult<string>((x + y).ToString());
        }
        
    }
}

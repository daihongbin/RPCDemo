using MagicOnion;
using MagicOnion.Server;

namespace ServerDefinition
{
    public class Test : ServiceBase<ITest>,ITest
    {
        public async UnaryResult<string> SumAsync(int x, int y) => (x + y).ToString();
        
    }
}

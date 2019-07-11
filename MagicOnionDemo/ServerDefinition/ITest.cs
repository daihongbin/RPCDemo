using MagicOnion;

namespace ServerDefinition
{
    public interface ITest:IService<ITest>
    {
        UnaryResult<string> SumAsync(int x,int y);
    }
}

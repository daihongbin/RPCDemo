using MagicOnion;

namespace ServerDefinition.Service
{
    public interface ITest:IService<ITest>
    {
        UnaryResult<string> Sum(int x,int y);
    }
}

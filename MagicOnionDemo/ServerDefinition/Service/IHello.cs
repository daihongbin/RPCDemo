using MagicOnion;

namespace ServerDefinition.Service
{
    public interface IHello:IService<IHello>
    {
        UnaryResult<string> Hello(string name);
    }
}

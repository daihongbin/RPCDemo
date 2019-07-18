using MagicOnion;

namespace ServerDefinition.Service
{
    public interface IWorld : IService<IWorld>
    {
        UnaryResult<string> World(string name);
    }
}

using MagicOnion;
using MagicOnion.Server;
using ServerDefinition.Service;

namespace ServerDefinition.Impl
{
    class WorldService : ServiceBase<IWorld>, IWorld
    {
        public UnaryResult<string> World(string name)
        {
            return new UnaryResult<string>($"这里是{name}的世界！");
        }
    }
}

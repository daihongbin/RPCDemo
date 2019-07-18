using MessagePack;

namespace MagicOnionAspNetServer.Model
{
    [MessagePackObject(true)]
    public struct ReturnResult
    {
        public string Msg;

        public int Status;

        public object Data;
    }
}

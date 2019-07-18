using MessagePack;

namespace MagicOnionAspNetServer.Model
{
    [MessagePackObject(true)]
    public struct Student
    {
        public string Name;

        public int Sid;
    }
}

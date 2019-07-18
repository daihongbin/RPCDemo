using MagicOnion;
using MagicOnion.Server;
using MagicOnionAspNetServer.Model;
using MagicOnionAspNetServer.Service;

namespace MagicOnionAspNetServer.Impl
{
    public class Test : ServiceBase<ITest>, ITest
    {
        public UnaryResult<ReturnResult> GetStudent(int sid)
        {
            Student student;
            student.Name = "Test_小明";
            student.Sid = sid;

            ReturnResult result = new ReturnResult
            {
                Data = student,
                Status = 0
            };

            return UnaryResult(result);
        }
    }
}

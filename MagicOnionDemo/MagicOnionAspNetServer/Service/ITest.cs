using MagicOnion;
using MagicOnionAspNetServer.Model;

namespace MagicOnionAspNetServer.Service
{
    public interface ITest:IService<ITest>
    {
        /// <summary>
        /// 获取一个学生
        /// </summary>
        /// <param name="sid">学生id</param>
        /// <returns>一个学生</returns>
        UnaryResult<ReturnResult> GetStudent(int sid);
        
    }
}

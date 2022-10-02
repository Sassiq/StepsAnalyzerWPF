using StepsAnalyzer.Models;

namespace StepsAnalyzer.Interfaces
{
    public interface IUserSerializer
    {
        void Serialize(IEnumerable<User> users, string path);
    }
}

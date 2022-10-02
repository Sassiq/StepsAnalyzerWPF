using StepsAnalyzer.Models;

namespace StepsAnalyzer.Interfaces
{
    public interface IUserDeserializer
    {
        IEnumerable<User> GetUsers();
    }
}

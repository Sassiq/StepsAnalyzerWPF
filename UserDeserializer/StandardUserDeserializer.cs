using StepsAnalyzer.Interfaces;
using StepsAnalyzer.Models;

namespace UserDeserializer
{
    public class StandardUserDeserializer : IUserDeserializer
    {
        private readonly string deserializationPath;

        public StandardUserDeserializer(string path)
        {
            deserializationPath = path;
        }

        public IEnumerable<User> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}
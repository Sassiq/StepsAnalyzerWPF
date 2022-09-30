using StepsAnalyzer.Interfaces;
using StepsAnalyzer.Models;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

namespace UserJsonSerializer
{
    public class UserJSONSerializer : IUserSerializer
    {
        public void Serialize(IEnumerable<User> users, string path)
        {
            using (FileStream fs = new(path, FileMode.Open))
            {
                JsonSerializer.Serialize(fs, users, new JsonSerializerOptions() 
                {
                    WriteIndented = true,
                    Converters = { new JsonStringEnumConverter() },
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                });
            }
        }
    }
}
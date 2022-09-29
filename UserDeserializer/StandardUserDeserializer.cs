using StepsAnalyzer.Interfaces;
using StepsAnalyzer.Models;
using System.Text.Json;
using System.Text.RegularExpressions;

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
            var users = new List<User>();
            List<DataObject>? dataObjects;

            foreach (var filePath in Directory.EnumerateFiles(deserializationPath))
            {
                Regex regex = new(@"day\d{1,2}\.json");
                if (!regex.IsMatch(filePath))
                {
                    continue;
                }

                using (FileStream fs = new(filePath, FileMode.Open))
                {
                    dataObjects = JsonSerializer.Deserialize<List<DataObject>>(fs);
                }

                if(dataObjects is null)
                {
                    continue;
                }

                uint dayNumber = CalculateDayNumber(Path.GetFileName(filePath));

                foreach (var dataObject in dataObjects)
                {
                    var user = users.Find(u => u.Name == dataObject.User);
                    if (user is null)
                    {
                        user = new User() { Name = dataObject.User };
                        users.Add(user);
                    }

                    user.Days.Add(new Day()
                    {
                        Number = dayNumber,
                        Status = GetStatus(dataObject.Status),
                        UserSteps = (uint)dataObject.Steps,
                        UserRank = (uint)dataObject.Rank,
                    });
                }
            }
            
            return users;
        }

        private static uint CalculateDayNumber(string dayFileName)
        {
            var str = Regex.Matches(dayFileName, @"\d{1,2}")[0].Value;

            return Convert.ToUInt32(str);
        }

        private static Status GetStatus(string status)
        {
            return status switch
            {
                "Finished" => Status.Finished,
                "InProgress" => Status.InProgress,
                "Refused" => Status.Refused,
                _ => throw new ArgumentException("Incorrect status."),
            };
        }
    }
}
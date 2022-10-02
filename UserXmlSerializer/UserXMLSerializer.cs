using StepsAnalyzer.Interfaces;
using StepsAnalyzer.Models;
using System.Xml;

namespace UserXmlSerializer
{
    public class UserXMLSerializer : IUserSerializer
    {
        public void Serialize(IEnumerable<User> users, string path)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";

            using (StreamWriter streamWriter = new StreamWriter(path, false))
            using (XmlWriter writer = XmlWriter.Create(streamWriter, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Users");

                foreach (User user in users)
                {
                    writer.WriteStartElement("User");

                    SerializeUserInfo(writer, user);
                    SerializeProgress(writer, user.Days);

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        private void SerializeUserInfo(XmlWriter writer, User user)
        {
            writer.WriteStartElement("Name");
            writer.WriteString(user.Name);
            writer.WriteEndElement();

            writer.WriteStartElement("AverageResult");
            writer.WriteString(user.AverageSteps.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("BestResult");
            writer.WriteString(user.BestStepsResult.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("WorstResult");
            writer.WriteString(user.WorstStepsResult.ToString());
            writer.WriteEndElement();
        }

        private void SerializeProgress(XmlWriter writer, IEnumerable<Day> days)
        {
            writer.WriteStartElement("Days");

            foreach (Day day in days)
            {
                writer.WriteStartElement("Day");

                writer.WriteStartElement("Number");
                writer.WriteString(day.Number.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("Rank");
                writer.WriteString(day.UserRank.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("Steps");
                writer.WriteString(day.UserSteps.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("Status");
                writer.WriteString(day.Status.ToString());
                writer.WriteEndElement();

                writer.WriteEndElement();
            }

            writer.WriteEndElement();
        }
    }
}
using CheatSheetProject.Models;
using System.Data.SQLite;

namespace CheatSheetProject.Repositories
{
    public class TopicRepository
    {
        private static readonly string topic = "Topic";
        public TopicRepository()
        {

        }
        public static void AddNewTopic(string topicName)
        {
            var id = Guid.NewGuid();
            SQLTableManagement.InsertData(topic, "Id, Name", $"\"{id}\",\"{topicName}\"");
        }

        public static List<Topic> GetAllTopics()
        {
            var allTopics = new List<Topic>();
            var sqlite_datareader = SQLTableManagement.ReadData(topic, null);
            while (sqlite_datareader.Read())
            {
                string id = sqlite_datareader.GetString(0);
                string name = sqlite_datareader.GetString(1);
                allTopics.Add(new Topic 
                { 
                    Id = id,
                    Name = name
                });
            }
            SQLTableManagement.CloseConnections(sqlite_datareader);
            return allTopics;
        }

        public static Topic? GetTopic(string id)
        {
            SQLTableManagement.GetSQLiteConnection();
            var clause = $"Id = \"{id}\"";
            var sqlite_datareader = SQLTableManagement.ReadData(topic, null);
            while (sqlite_datareader.Read())
            {
                string name = sqlite_datareader.GetString(1);

                SQLTableManagement.CloseConnections(sqlite_datareader);
                return new Topic
                {
                    Id = id,
                    Name = name
                };
            }
            SQLTableManagement.CloseConnections(sqlite_datareader);
            return null;
        }

        public static void UpdateNameById(string id, string name)
        {
            var clause = $"Id = \"{id}\"";
            var setName = $"Name = \"{name}\"";
            SQLTableManagement.UpdateData(topic, setName, clause);
        }


        public static void DeleteTopicById(string id)
        {
            var clause = $"Id = \"{id}\"";
            SQLTableManagement.DeleteData(topic, clause);
        }

        public static void DeleteTopicByName(string name)
        {
            var clause = $"Name = \"{name}\"";
            SQLTableManagement.DeleteData(topic, clause);
        }
    }

}

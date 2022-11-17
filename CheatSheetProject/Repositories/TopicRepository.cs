using CheatSheetProject.Models;
using System.Data.SQLite;
using System.Linq;

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

        public static Topic? GetTopicWithAllItems(string id)
        {
            var clause = $"Id = \"{id}\"";
            var statement = "SELECT Topic.Id AS TopicId, Topic.Name, CheatSheetItem.Id AS ItemId, CheatSheetItem.Name, CheatSheetItem.CodeSnippet, CheatSheetItem.AdditionalInfo, UsefulLinks.Id AS LinkId, UsefulLinks.LinkAddress, UsefulLinks.LinkOrder \r\nFROM Topic\r\nLEFT JOIN CheatSheetItem ON Topic.Id = CheatSheetItem.TopicId\r\nLEFT JOIN UsefulLinks ON CheatSheetItem.Id = UsefulLinks.CheatSheetItemId" +
                $"WHERE Topic.Id = \"{id}\";";
            Topic topic = null;
            var cheatSheetItem = new LinkedList<CheatSheetItem>();
            var sqlite_datareader = SQLTableManagement.ReadCustomData(statement);
            while (sqlite_datareader.Read())
            {
                var topicId = sqlite_datareader.GetString(0);
                var topicName = sqlite_datareader.GetString(1);

                CheatSheetItem item = null;
                if (sqlite_datareader[2] != DBNull.Value)
                {
                    var itemId = sqlite_datareader.GetString(2);
                    var itemName = sqlite_datareader.GetString(3);
                    var itemCode = sqlite_datareader.GetString(4);
                    var additionInfo = sqlite_datareader.GetString(5);
                   
                    item = new CheatSheetItem
                    {
                        Id = itemId,
                        Name = itemName,
                        CodeSnippet = itemCode,
                        AdditionalInfo = additionInfo
                    };
                    if (!cheatSheetItem.Contains(item))
                    {
                        cheatSheetItem.AddLast(item);
                    }
                    else
                    {
                        item = cheatSheetItem.Where(i => i.Id == itemId).FirstOrDefault();
                    }

                    UsefulLink link = null;
                    if (sqlite_datareader[6] != DBNull.Value)
                    {
                        var linkId = sqlite_datareader.GetString(6);
                        var address = sqlite_datareader.GetString(7);
                        var order = sqlite_datareader.GetInt32(8);

                        link = new UsefulLink
                        {
                            Id = linkId,
                            LinkAddress = address,
                            LinkOrder = order
                        };
                        item.UsefulLinks.Add(link);
                    }
                }

                if(topic == null)
                {
                    topic = new Topic
                    {
                        Id = topicId,
                        Name = topicName
                    };
                }
                if(item !=null)
                {
                    if (!topic.CheatSheetItem.Contains(item))
                    {
                        topic.CheatSheetItem.Add(item);
                    }
                }
            }
            return topic;
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

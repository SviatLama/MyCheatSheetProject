using CheatSheetProject.Models;

namespace CheatSheetProject.Repositories
{
    public class CheatSheetItemRepository
    {
        public CheatSheetItemRepository()
        {
        }
        private static readonly string cheatSheetItemTable = "CheatSheetItem";
        public static void AddNewCheatSheetItem(CheatSheetItem cheatSheetItem, string? TopicId)
        {
            string id;
            if(cheatSheetItem.Id == null)
            {
                id = Guid.NewGuid().ToString();
            }
            else
            {
                id = cheatSheetItem.Id;
            }
            
            SQLTableManagement.InsertData(cheatSheetItemTable, "Id, Name, CodeSnippet, AdditionalInfo, TopicId", 
                $"\"{id}\",\"{cheatSheetItem.Name}\",\"{cheatSheetItem.CodeSnippet}\",\"{cheatSheetItem.AdditionalInfo}\", \"{TopicId}\"");
        }

        public static void DeleteItemById(string id)
        {
            var clause = $"Id = \"{id}\"";
            SQLTableManagement.DeleteData(cheatSheetItemTable, clause);
        }

        public static void UpdateItemById(string id, CheatSheetItem cheatSheetItem)
        {
            var whereClause = $"Id = \"{id}\"";
            var setClause = "";
            if (cheatSheetItem.Name != null)
                setClause += $"Name = \"{cheatSheetItem.Name}\", ";
            setClause += $"CodeSnippet = \"{cheatSheetItem.CodeSnippet}\", ";
            setClause += $"AdditionalInfo = \"{cheatSheetItem.AdditionalInfo}\"";
            SQLTableManagement.UpdateData(cheatSheetItemTable, setClause, whereClause);
        }





        public static List<CheatSheetItem> GetAllItems()
        {
            var allCheatSheetItems = new List<CheatSheetItem>();
            var sqlite_datareader = SQLTableManagement.ReadData(cheatSheetItemTable, null);
            while (sqlite_datareader.Read())
            {
                string id = sqlite_datareader.GetString(0);
                string name = sqlite_datareader.GetString(1);
                string codeSnippet = sqlite_datareader.GetString(2);
                string additionalInfo = sqlite_datareader.GetString(3);
                allCheatSheetItems.Add(new CheatSheetItem 
                {
                    Id = id,
                    Name = name,
                    CodeSnippet = codeSnippet,
                    AdditionalInfo = additionalInfo
                });
            }
            SQLTableManagement.CloseConnections(sqlite_datareader);
            return allCheatSheetItems;
        }


        public static CheatSheetItem? GetItem(string id)
        {
            SQLTableManagement.GetSQLiteConnection();
            var clause = $"Id = \"{id}\"";

            var sqlite_datareader = SQLTableManagement.ReadData(cheatSheetItemTable, clause);
            while (sqlite_datareader.Read())
            {
                string name = sqlite_datareader.GetString(1);
                string codeSnippet = sqlite_datareader.GetString(2);
                string additionalInfo = sqlite_datareader.GetString(3);

                SQLTableManagement.CloseConnections(sqlite_datareader);
                return new CheatSheetItem
                {
                    Id = id,
                    Name = name,
                    CodeSnippet = codeSnippet,
                    AdditionalInfo = additionalInfo
                };
            }
            SQLTableManagement.CloseConnections(sqlite_datareader);
            return null;
        }

        public static List<CheatSheetItem> GetAllItemsByTopicId(string topicId)
        {
            var allCheatSheetItemsForTopic = new List<CheatSheetItem>();
            var clause = $"TopicId = \"{topicId}\"";
            var sqlite_datareader = SQLTableManagement.ReadData(cheatSheetItemTable, null);
            while (sqlite_datareader.Read())
            {
                string id = sqlite_datareader.GetString(0);
                string name = sqlite_datareader.GetString(1);
                string codeSnippet = sqlite_datareader.GetString(2);
                string additionalInfo = sqlite_datareader.GetString(3);
                allCheatSheetItemsForTopic.Add(new CheatSheetItem
                {
                    Id = id,
                    Name = name,
                    CodeSnippet = codeSnippet,
                    AdditionalInfo = additionalInfo
                });
            }
            SQLTableManagement.CloseConnections(sqlite_datareader);
            return allCheatSheetItemsForTopic;
        }




    }
}

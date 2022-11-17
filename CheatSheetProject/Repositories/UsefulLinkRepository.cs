using CheatSheetProject.Models;

namespace CheatSheetProject.Repositories
{
    public class UsefulLinkRepository
    {
        public static readonly string usefulLinksTable = "UsefulLinks";
        public UsefulLinkRepository()
        {

        }


        public static void AddNewUsefulLink(UsefulLink usefulLink, string? CheatSheetItemID)
        {
            var id = Guid.NewGuid();
            SQLTableManagement.InsertData(usefulLinksTable, "Id, LinkAddress, LinkOrder, CheatSheetItemId",
                $"\"{id}\",\"{usefulLink.LinkAddress}\",\"{usefulLink.LinkOrder}\", \"{CheatSheetItemID}\"");
        }

        public static void DeleteLinkById(string id)
        {
            var clause = $"Id = \"{id}\"";
            SQLTableManagement.DeleteData(usefulLinksTable, clause);
        }

        public static void UpdateLinkById(string id, UsefulLink link)
        {
            var whereClause = $"Id = \"{id}\"";
            var setClause = "";
            if (link.LinkOrder != null)
                setClause += $"LinkOrder = \"{link.LinkOrder}\", ";
            if (link.CheatSheetItemId != null)
                setClause += $"CheatSheetItemId = \"{link.CheatSheetItemId}\", ";
            setClause += $"LinkAddress = \"{link.LinkAddress}\"";
            
            SQLTableManagement.UpdateData(usefulLinksTable, setClause, whereClause);
        }



        public static List<UsefulLink> GetAllLinks()
        {
            var allUsefulLinks = new List<UsefulLink>();
            var sqlite_datareader = SQLTableManagement.ReadData(usefulLinksTable, null);
            while (sqlite_datareader.Read())
            {
                string id = sqlite_datareader.GetString(0);
                string linkAddress = sqlite_datareader.GetString(1);
                int linkOrder = sqlite_datareader.GetInt32(2);
                string cheatSheetItemId = sqlite_datareader.GetString(3);
                allUsefulLinks.Add(new UsefulLink
                {
                    Id = id,
                    LinkAddress = linkAddress,
                    LinkOrder = linkOrder,
                    CheatSheetItemId = cheatSheetItemId
                });
            }
            SQLTableManagement.CloseConnections(sqlite_datareader);
            return allUsefulLinks;
        }


        public static UsefulLink? GetLink(string id)
        {
            SQLTableManagement.GetSQLiteConnection();
            var clause = $"Id = \"{id}\"";

            var sqlite_datareader = SQLTableManagement.ReadData(usefulLinksTable, null);
            while (sqlite_datareader.Read())
            {
                string linkAddress = sqlite_datareader.GetString(1);
                int linkOrder = sqlite_datareader.GetInt32(2);
                string cheatSheetItemId = sqlite_datareader.GetString(3);

                SQLTableManagement.CloseConnections(sqlite_datareader);
                return new UsefulLink
                {
                    Id = id,
                    LinkAddress = linkAddress,
                    LinkOrder = linkOrder,
                    CheatSheetItemId = cheatSheetItemId
                };
            }
            SQLTableManagement.CloseConnections(sqlite_datareader);
            return null;
        }

        public static List<UsefulLink> GetAllUsefulLinksByItemId(string cheatSheetItemID)
        {
            var linksByItem = new List<UsefulLink>();
            var clause = $"CheatSheetItemId = \"{cheatSheetItemID}\"";
            var sqlite_datareader = SQLTableManagement.ReadData(usefulLinksTable, null);
            while (sqlite_datareader.Read())
            {
                string id = sqlite_datareader.GetString(0);
                string linkAddress = sqlite_datareader.GetString(1);
                int linkOrder = sqlite_datareader.GetInt32(2);
                string cheatSheetItemId = sqlite_datareader.GetString(3);
                linksByItem.Add(new UsefulLink
                {
                    Id = id,
                    LinkAddress = linkAddress,
                    LinkOrder = linkOrder,
                    CheatSheetItemId = cheatSheetItemId
                });
            }
            SQLTableManagement.CloseConnections(sqlite_datareader);
            return linksByItem;
        }


    }
}

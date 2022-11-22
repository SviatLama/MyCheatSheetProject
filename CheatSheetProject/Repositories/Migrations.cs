
using CheatSheetProject.Models;
using System.Data.SQLite;
using System.Security.Cryptography.Xml;

namespace CheatSheetProject.Repositories
{
    public class Migrations
    {
        public Migrations()
        {
        }

        public static void run()
        {
            SQLTableManagement.ExecuteSQL("DROP TABLE Topic");
            SQLTableManagement.ExecuteSQL("CREATE TABLE Topic (Id VARCHAR(20), Name VARCHAR(200), PRIMARY KEY(ID))");

            SQLTableManagement.ExecuteSQL("DROP TABLE CheatSheetItem");
            SQLTableManagement.ExecuteSQL("CREATE TABLE CheatSheetItem (Id VARCHAR(20), Name VARCHAR(200), CodeSnippet TEXT, AdditionalInfo TEXT, TopicId VARCHAR(20),PRIMARY KEY(ID),FOREIGN KEY(TopicId) REFERENCES Topic(Id))");

            SQLTableManagement.ExecuteSQL("DROP TABLE UsefulLinks");
            SQLTableManagement.ExecuteSQL("CREATE TABLE UsefulLinks (Id VARCHAR(20) NOT NULL, LinkAddress VARCHAR(200), LinkOrder INT, CheatSheetItemId VARCHAR(20),\r\nPRIMARY KEY (ID),\r\nFOREIGN KEY(CheatSheetItemId)REFERENCES CheatSheetItem(Id))");
          
        }
    }
}

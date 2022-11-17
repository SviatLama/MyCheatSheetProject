
using System.Data.SQLite;

namespace CheatSheetProject.Repositories
{
    public class Migrations
    {
        public Migrations()
        {
        }

        public static void run()
        {
            SQLTableManagement.CreateTable("CREATE TABLE Topic (Id VARCHAR(20), Name VARCHAR(200))");
            SQLTableManagement.CreateTable("CREATE TABLE UsefulLinks (Id VARCHAR(20), LinkAddress VARCHAR(200), LinkOrder INT, CheatSheetItemId VARCHAR(20))");
            SQLTableManagement.CreateTable("CREATE TABLE CheatSheetItem (Id VARCHAR(20), Name VARCHAR(200), CodeSnippet TEXT, UsefulLinks TEXT, AdditionalInfo TEXT, TopicId VARCHAR(20))");
        }
    }
}

using System.Collections.Generic;
namespace CheatSheetProject.Models
{
    public class CheatSheetItem
    {

        public string ID { get; set; }
        public string Name { get; set; }
        public string CodeSnippet { get; set; }
        public string AdditionalInfo { get; set; }
        public List<UsefulLink> UsefulLinks { get; set; }
        public CheatSheetItem()
        {

        }
    }
}

using System.Collections.Generic;
namespace CheatSheetProject.Models
{
    public class Topic
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<CheatSheetItem> CheatSheetItem { get; set; }
        public Topic()
        {
            CheatSheetItem = new List<CheatSheetItem>();
        }

    }
}

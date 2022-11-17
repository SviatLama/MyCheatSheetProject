namespace CheatSheetProject.Models
{
    public class UsefulLink
    {
        public string Id { get; set; }
        public string LinkAddress { get; set; }
        public int? LinkOrder { get; set; } 
        public string CheatSheetItemId { get; set; }
        public UsefulLink()
        {

        }

    }
}

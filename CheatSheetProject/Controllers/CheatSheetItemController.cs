using CheatSheetProject.Models;
using CheatSheetProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CheatSheetProject.Controllers
{
    [Route("api/cheatCheetItem")]
    public class CheatSheetItemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public List<CheatSheetItem> GetAllItems()
        {
            return CheatSheetItemRepository.GetAllItems();
        }

        [HttpGet("{id}")]
        public CheatSheetItem? GetOneItemById(string id)
        {
            var cheatSheetItem = CheatSheetItemRepository.GetItem(id);
            if (cheatSheetItem != null)
            {
                var usefulLinks = UsefulLinkRepository.GetAllUsefulLinksByItemId(id);
                cheatSheetItem.UsefulLinks = usefulLinks;
            }
            return cheatSheetItem;
        }

        [HttpGet("topics/{topicId}")]
        public List<CheatSheetItem> GetItemsByTopicId(string topicId)
        {
            return CheatSheetItemRepository.GetAllItemsByTopicId(topicId);
        }
        [HttpPut("{id}")]
        public CheatSheetItem? UpdateItem(string id, [FromBody] CheatSheetItem cheatSheetItem)
        {
            CheatSheetItemRepository.UpdateItemById(id, cheatSheetItem);
            return CheatSheetItemRepository.GetItem(id);
        }
        [HttpDelete("{id}")]
        public void DeleteItem(string id)
        {
            UsefulLinkRepository.DeleteByItemId(id);
            CheatSheetItemRepository.DeleteItemById(id);
        }
        [HttpPost]
        public void AddNewItem([FromBody] CheatSheetItem cheatSheetItem, [FromQuery] string? topicId)
        {
            CheatSheetItemRepository.AddNewCheatSheetItem(cheatSheetItem, topicId);
            foreach(UsefulLink usefulLink in cheatSheetItem.UsefulLinks)
            {
                UsefulLinkRepository.AddNewUsefulLink(usefulLink, cheatSheetItem.Id);
            }
        }
    }
}

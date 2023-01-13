using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//CheatSheetProject.Repositories.Migrations.run();
//CheatSheetProject.Repositories.TopicRepository.AddNewTopic("If statement");
//CheatSheetProject.Repositories.TopicRepository.AddNewTopic("Classes");
//CheatSheetProject.Repositories.TopicRepository.AddNewTopic("While");
//var topics = CheatSheetProject.Repositories.TopicRepository.GetAllTopics();
//var firstTopic = CheatSheetProject.Repositories.TopicRepository.GetTopic("b98df574-0344-4a62-a29b-4a3e03946329");
//Console.WriteLine(firstTopic);
/*if (firstTopic != null)
{
    CheatSheetProject.Repositories.TopicRepository.UpdateNameById(firstTopic.Id, "Cheat Sheet Project");
}*/
//firstTopic = CheatSheetProject.Repositories.TopicRepository.GetTopic(topics[0].Id);
//CheatSheetProject.Repositories.TopicRepository.UpdateNameById(firstTopic.Id, "Cheat Sheet Project");
//CheatSheetProject.Repositories.TopicRepository.DeleteTopicByName("if statement");
/*var cheatSheetItem = new CheatSheetProject.Models.CheatSheetItem()
{
    Name = "Difference while&forLoop",
    CodeSnippet = "smth",
    AdditionalInfo = "d",
};
CheatSheetProject.Repositories.CheatSheetItemRepository.AddNewCheatSheetItem(cheatSheetItem, "80659dc1-c693-4ae6-900b-2aa36de782cc");*/
//CheatSheetProject.Repositories.CheatSheetItemRepository.UpdateItemById("ce73c9ee-e29a-4190-99ef-14557567fd4a", cheatSheetItem);
//CheatSheetProject.Repositories.CheatSheetItemRepository.DeleteItemById("ce73c9ee-e29a-4190-99ef-14557567fd4a");
var item = CheatSheetProject.Repositories.CheatSheetItemRepository.GetItem("472531cd-ff02-4029-9f09-7464bca60f21");
//var allItems = CheatSheetProject.Repositories.CheatSheetItemRepository.GetAllItems();
//var allItemsById = CheatSheetProject.Repositories.CheatSheetItemRepository.GetAllItemsByTopicId("32fa4115-2d75-4cb0-8c29-3007077ff541");
/*var usefulLink = new CheatSheetProject.Models.UsefulLink()
   {
       LinkAddress = "w3school",
       LinkOrder = 2,
       CheatSheetItemId = "1531eab1-5dbb-45fa-89d9-f8f76e0543e0"
   };*/
//CheatSheetProject.Repositories.UsefulLinkRepository.AddNewUsefulLink(usefulLink, "1531eab1-5dbb-45fa-89d9-f8f76e0543e0");
//CheatSheetProject.Repositories.UsefulLinkRepository.UpdateLinkById("82eed8c6-e9c1-4ef2-86e4-42337d3617df", usefulLink);
//CheatSheetProject.Repositories.UsefulLinkRepository.DeleteLinkById("3bc6c371-349c-4a09-a77c-de19e3679ee9");
//var allLinks = CheatSheetProject.Repositories.UsefulLinkRepository.GetAllLinks();

//var allLinksByItemId = CheatSheetProject.Repositories.UsefulLinkRepository.GetAllUsefulLinksByItemId("013b626f-abd3-4232-a230-80862a0e047a");
//var link = CheatSheetProject.Repositories.UsefulLinkRepository.GetLink("82eed8c6-e9c1-4ef2-86e4-42337d3617df");

//var topicWithAllData = CheatSheetProject.Repositories.TopicRepository.GetTopicWithAllItems("348eeaeb-a47a-463f-8007-ef10775c9c9e");

app.Run();

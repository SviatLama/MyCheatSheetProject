using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
//CheatSheetProject.Repositories.TopicRepository.AddNewTopic("For loop");
//CheatSheetProject.Repositories.TopicRepository.AddNewTopic("if statement");
//CheatSheetProject.Repositories.TopicRepository.AddNewTopic("while");
/*var topics = CheatSheetProject.Repositories.TopicRepository.GetAllTopics();
var firstTopic = CheatSheetProject.Repositories.TopicRepository.GetTopic(topics[0].Id);

Console.WriteLine(firstTopic);

if (firstTopic != null)
{
    CheatSheetProject.Repositories.TopicRepository.UpdateNameById(firstTopic.Id, "Cheat Sheet Project");
}

firstTopic = CheatSheetProject.Repositories.TopicRepository.GetTopic(topics[0].Id);
CheatSheetProject.Repositories.TopicRepository.UpdateNameById(firstTopic.Id, "Cheat Sheet Project");
CheatSheetProject.Repositories.TopicRepository.DeleteTopicByName("if statement");*/

var cheatSheetItem = new CheatSheetProject.Models.CheatSheetItem()
{
    Name = "if else",
    CodeSnippet = "if (a < b) {... code} else {... some code} ",
    AdditionalInfo = "If statements else"
};
//CheatSheetProject.Repositories.CheatSheetItemRepository.AddNewCheatSheetItem(cheatSheetItem, "32fa4115-2d75-4cb0-8c29-3007077ff541");
//CheatSheetProject.Repositories.CheatSheetItemRepository.UpdateItemById("013b626f-abd3-4232-a230-80862a0e047a", cheatSheetItem);
//CheatSheetProject.Repositories.CheatSheetItemRepository.DeleteItemById("5db9a064-76d5-4823-bc08-f26f10d4b8f8");
var item = CheatSheetProject.Repositories.CheatSheetItemRepository.GetItem("ce73c9ee-e29a-4190-99ef-14557567fd4a");
var allItems = CheatSheetProject.Repositories.CheatSheetItemRepository.GetAllItems();
var allItemsById = CheatSheetProject.Repositories.CheatSheetItemRepository.GetAllItemsByTopicId("32fa4115-2d75-4cb0-8c29-3007077ff541");

app.Run();

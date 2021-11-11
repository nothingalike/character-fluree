using BlazingFlureeCharacters.Data;
using FlureeDotnetLibrary;
using FlureeDotnetLibrary.FlureeCommand;
using FlureeDotnetLibrary.FlureeDatabase;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
//Fluree Setup
builder.Services.AddFlureeDotnetService();
builder.Services.AddTransient<ICharacterService, CharacterService>();

var serviceProvider = builder.Services.BuildServiceProvider();

var fDatabaseService = serviceProvider.GetRequiredService<IFlureeDatabaseService>();
try
{
    var newDb = fDatabaseService.CreateANewLedgerDatabase("bfc", "main").Result;
}
catch (Exception) { }

var fCommandService = serviceProvider.GetRequiredService<IFlureeCommandService>();
try
{
    fCommandService.CreateFlureeCollectionCommand("bfc", "main", "characters", "A collection to store BFC Characters!").Wait();
    fCommandService.CreateFlureePredicateCommand("bfc", "main", "characters", "name", "The name of the Character", "string").Wait();
    fCommandService.CreateFlureePredicateCommand("bfc", "main", "characters", "description", "The description of the Character", "string").Wait();
    fCommandService.CreateFlureePredicateCommand("bfc", "main", "characters", "class", "The class of the Character", "string").Wait();
    fCommandService.CreateFlureePredicateCommand("bfc", "main", "characters", "race", "The race of the Character", "string").Wait();
    fCommandService.CreateFlureePredicateCommand("bfc", "main", "characters", "hp", "The hp of the Character", "int").Wait();
    fCommandService.CreateFlureePredicateCommand("bfc", "main", "characters", "strength", "The strength of the Character", "int").Wait();
    fCommandService.CreateFlureePredicateCommand("bfc", "main", "characters", "dexterity", "The dexterity of the Character", "int").Wait();
    fCommandService.CreateFlureePredicateCommand("bfc", "main", "characters", "constitution", "The constitution of the Character", "int").Wait();
    fCommandService.CreateFlureePredicateCommand("bfc", "main", "characters", "intelligence", "The intelligence of the Character", "int").Wait();
    fCommandService.CreateFlureePredicateCommand("bfc", "main", "characters", "wisdom", "The wisdom of the Character", "int").Wait();
    fCommandService.CreateFlureePredicateCommand("bfc", "main", "characters", "charisma", "The charisma of the Character", "int").Wait();
}
catch (Exception) { }


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

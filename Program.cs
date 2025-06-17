using dotenv.net;
using Microsoft.EntityFrameworkCore;
using Todo.Data;

DotEnv.Load();

var envVars = DotEnv.Read();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var folder = Environment.SpecialFolder.LocalApplicationData;
var path = Environment.GetFolderPath(folder);
var dbName = envVars["dbName"];
var dbPath = Path.Join(path, dbName);

builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlite($"Data Source ={dbPath}");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();

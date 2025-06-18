using dotenv.net;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todo.Data;
using Todo.Interfaces;
using Todo.Models;
using Todo.Repositories;

DotEnv.Load();

var envVars = DotEnv.Read();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<User>()
                .AddEntityFrameworkStores<ApplicationDBContext>();

builder.Services.AddScoped<IActivityRepository, ActivityRepository>();
builder.Services.AddControllers();

var AllowFrontendDomain = "_allowFrontendDomain";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowFrontendDomain,
    policy =>
    {
        policy.WithOrigins("http://localhost:4321")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    });
});


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

app.UseCors(AllowFrontendDomain);

app.UseAuthentication();

app.UseAuthorization();

app.UseHttpsRedirection();

app.MapControllers();

// Auth endpoints
app.MapIdentityApi<User>();

app.MapPost("/logout", async (SignInManager<User> signInManager,
    [FromBody] object empty) =>
{
    if (empty != null)
    {
        await signInManager.SignOutAsync();
        return Results.Ok();
    }
    return Results.Unauthorized();
})
.WithOpenApi()
.RequireAuthorization();


app.Run();

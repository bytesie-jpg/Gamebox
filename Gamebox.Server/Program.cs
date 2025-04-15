using Gamebox.Server.Models;
using Gamebox.Server.Services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


// Add services to the container.
builder.Services.Configure<GameboxDatabaseSettings>(
    builder.Configuration.GetSection("GameboxDatabase"));

builder.Services.AddSingleton<RatingsService>();
builder.Services.AddSingleton<UserService>();

builder.Services.AddOpenApi();

var app = builder.Build();


app.UseDefaultFiles();
app.MapStaticAssets();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();

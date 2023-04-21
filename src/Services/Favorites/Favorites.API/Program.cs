using MongoDB.Driver;
using IlayMor.Bookshelf.Services.Favorites.API.Models;
using IlayMor.Bookshelf.Services.Favorites.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var dBSettings = builder.Configuration.GetSection("DBSettings").Get<FavoritesDBSettings>();
builder.Services.AddSingleton(dBSettings);
builder.Services.AddScoped<IFavoritesRepo, FavoritesRepo>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

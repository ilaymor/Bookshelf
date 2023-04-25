using MongoDB.Driver;
using MassTransit;
using IlayMor.Bookshelf.Services.Catalog.API.Models;
using IlayMor.Bookshelf.Services.Catalog.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var dBSettings = builder.Configuration.GetSection("MongoDBSettings").Get<CatalogDBSettings>();
builder.Services.AddSingleton(dBSettings);
builder.Services.AddScoped<ICatalogRepo, CatalogRepo>();
builder.Services.AddMassTransit( x =>
{
    x.UsingRabbitMq();
});
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

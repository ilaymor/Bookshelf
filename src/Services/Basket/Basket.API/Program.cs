using IlayMor.Bookshelf.Services.Basket.API.Models;
using IlayMor.Bookshelf.Services.Basket.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var dBSettings = builder.Configuration.GetSection("MongoDBSettings").Get<CustomerBasketDBSettings>();
builder.Services.AddSingleton(dBSettings);
builder.Services.AddScoped<ICustomerBasketRepo, CustomerBasketRepo>();

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

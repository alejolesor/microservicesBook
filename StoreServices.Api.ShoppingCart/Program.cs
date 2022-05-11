using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreServices.Api.ShoppingCart.Application;
using StoreServices.Api.ShoppingCart.Persitence;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(New.Managment).Assembly);

builder.Services.AddDbContext<CartContext>(options => {
    options.UseMySql(builder.Configuration.GetConnectionString("ConnectionMySql"),ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("ConnectionMySql")));
});

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

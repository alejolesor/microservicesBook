global using StoreService.Api.Author.Persistence;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreService.Api.Author.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<New>());
builder.Services.AddDbContext<ContextAuthor>(options => {

    options.UseNpgsql(builder.Configuration.GetConnectionString("ConnectionPostgress"));

});


builder.Services.AddMediatR(typeof(New.Managment).Assembly);
builder.Services.AddAutoMapper(typeof(Query.Managment));

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

app.UseAuthorization();

app.MapControllers();

app.Run();

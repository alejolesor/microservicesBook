using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreServices.Api.Book.Application;
using StoreServices.Api.Book.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<New>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ContextLibrary>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionSqlServer"));
});

builder.Services.AddMediatR(typeof(New.Managment).Assembly);
builder.Services.AddAutoMapper(typeof(Query.Execute));

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

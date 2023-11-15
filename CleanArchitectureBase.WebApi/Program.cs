using CleanArchitectureBase.persistence;
using Microsoft.EntityFrameworkCore;
using MediatR;
using CleanArchitectureBase.Application.Interfaces;
using FluentValidation.AspNetCore;
using CleanArchitectureBase.Application.Customers.Commands.Create;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<IApplicationDbContext ,ApplicationDbContext>(
dbContextOptions => dbContextOptions
    .UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    ).EnableDetailedErrors());


builder.Services.AddMediatR(typeof(ApplicationDbContext).Assembly);
builder.Services.AddMediatR(typeof(AddNewCustomerCommand).Assembly);
//builder.Services.AddControllers();


builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddNewCustomersCommandValidator>());

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

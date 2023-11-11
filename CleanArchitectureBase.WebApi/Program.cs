using CleanArchitectureBase.Application.Interfaces.Users.Commands;
using CleanArchitectureBase.persistence;
using Microsoft.EntityFrameworkCore;
using MediatR;
using CleanArchitectureBase.Application.Interfaces;
using FluentValidation.AspNetCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<IApplicationDbContext ,ApplicationDbContext>(
dbContextOptions => dbContextOptions
    .UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    ).EnableDetailedErrors());


builder.Services.AddMediatR(typeof(ApplicationDbContext).Assembly);
builder.Services.AddMediatR(typeof(AddNewUserCommand).Assembly);
//builder.Services.AddControllers();

builder.Services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddNewUserCommandValidator>());

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

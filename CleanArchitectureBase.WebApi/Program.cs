using CleanArchitectureBase.persistence;
using Microsoft.EntityFrameworkCore;
using MediatR;
using CleanArchitectureBase.Application.Interfaces;
using FluentValidation.AspNetCore;
using CleanArchitectureBase.Application.Customers.Commands.Create;
using CleanArchitectureBase.Domin.Repositories;
using CleanArchitectureBase.Infrastructure.Presistence;
using CleanArchitectureBase.WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<IApplicationDbContext ,ApplicationDbContext>(
dbContextOptions => dbContextOptions
    .UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    ).EnableDetailedErrors());


builder.Services.AddMediatR(typeof(ApplicationDbContext).Assembly);
builder.Services.AddMediatR(typeof(AddNewCustomerCommand).Assembly);

builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
//builder.Services.AddControllers();


builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddNewCustomersCommandValidator>());



var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                       builder =>
                       {
                           builder.WithOrigins("http://localhost:4200")
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                       });
});
var app = builder.Build();


app.UseMiddleware<ExceptionHandling>();
// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseCors(MyAllowSpecificOrigins);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

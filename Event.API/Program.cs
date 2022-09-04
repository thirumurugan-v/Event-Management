using Event.API.Services;
using Event.API.Services.Interface;
using Event.Domain.Models.GroupAggregate;
using Event.Domain.Models.GroupAggregate.Validator;
using Event.Infrastructure.Context;
using Event.Infrastructure.Extensions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Add database context
builder.Services.AddDbContext<EventContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetValue<string>("ConnectionString"),
    x => x.MigrationsAssembly(typeof(EventContext).Assembly.FullName));
});

builder.Services.SetupUnitOfWork();

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddScoped<IValidator<Group>, GroupValidator>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(
      "CorsPolicy",
      builder => builder.WithOrigins("http://localhost:4200")
      .AllowAnyMethod()
      .AllowAnyHeader()
      .AllowCredentials());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("CorsPolicy");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

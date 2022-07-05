using Event.API.Services;
using Event.API.Services.Interface;
using Event.Infrastructure.Context;
using Event.Infrastructure.Extensions;
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

using Microsoft.EntityFrameworkCore;
using OMS.Data.Access.DAL;
using OMS.DI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

string connString = builder.Configuration.GetConnectionString("SQLServer");
builder.Services.AddDbContext<OMSDbContext>(options => options.UseSqlServer(connString));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
ContainerSetup.Setup(builder.Services);

var app = builder.Build();
IConfiguration configuration = app.Configuration;

// Add services to the container.
//ContainerSetup.Setup(builder.Services);

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
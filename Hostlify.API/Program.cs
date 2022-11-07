using Hostlify.Domain;
using Hostlify.Infraestructure;
using Hostlify.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependency injection
builder.Services.AddScoped<IPlanDomain, PlanDomain>();
builder.Services.AddScoped<IRoomDomain, RoomDomain>();
builder.Services.AddScoped<IPlanRepository, PlanRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();

var connectionString = builder.Configuration.GetConnectionString("HostlifyConnection");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));//VARIA DEACUERDO A LA VERSION

//Conexion a MySQL
builder.Services.AddDbContext<HostlifyDB>(
        dbContextOptions => dbContextOptions.UseMySql(connectionString, serverVersion));

var app = builder.Build();

using (var scope= app.Services.CreateScope())
using (var context =scope.ServiceProvider.GetService<HostlifyDB>())//Validando si exite una BD sino la crea 4
{
    context.Database.EnsureCreated();
}



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
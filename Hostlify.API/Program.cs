using System.Text.Json.Serialization;
using Hostlify.API.Mapper;
using Hostlify.API.Middleware;
using Hostlify.Domain;
using Hostlify.Infraestructure;
using Hostlify.Infraestructure.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependency injection
builder.Services.AddScoped<IPlanDomain, PlanDomain>();
builder.Services.AddScoped<IUserDomain, UserDomain>();
builder.Services.AddScoped<ITokenDomain, TokenDomain>();
builder.Services.AddScoped<IPlanRepository, PlanRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


var connectionString = builder.Configuration.GetConnectionString("HostlifyConnection");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));//VARIA DEACUERDO A LA VERSION

//Conexion a MySQL
builder.Services.AddDbContext<HostlifyDB>(
        dbContextOptions => dbContextOptions.UseMySql(connectionString, serverVersion));

builder.Services.AddAutoMapper(
    typeof(ModelToResource),
    typeof(ResourceToModel)
);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
});

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

app.UseMiddleware<JwtMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
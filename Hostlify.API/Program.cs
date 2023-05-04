using System.Text.Json.Serialization;
using Hostlify.API.Mapper;
using Hostlify.API.Middleware;
using Hostlify.Domain;
using Hostlify.Infraestructure;
using Hostlify.Infraestructure.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options=>{
    options.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Description = "JWT Authorization header using the Bearer scheme."
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "bearerAuth" }
            },
            Array.Empty<string>()
        }
    });
});

//Dependency injection
builder.Services.AddScoped<IUserDomain, UserDomain>();
builder.Services.AddScoped<IRoomDomain, RoomDomain>();
builder.Services.AddScoped<ITokenDomain, TokenDomain>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IFoodServicesDomain, FoodServicesDomain>();
builder.Services.AddScoped<IFoodServicesRepository, FoodServicesRepository>();
builder.Services.AddScoped<ICleaningServicesDomain, CleaningServicesDomain>();
builder.Services.AddScoped<ICleaningServicesRepository, CleaningServicesRepository>();
builder.Services.AddScoped<IHistoryDomain, HistoryDomain>();
builder.Services.AddScoped<IHistoryRepository,HistoryRepository>();


var connectionString = builder.Configuration.GetConnectionString("HostlifyConnection");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 33));//VARIA DEACUERDO A LA VERSION

//Conexion a MySQL
builder.Services.AddDbContext<HostlifyDB>(
        dbContextOptions => dbContextOptions.UseMySql(connectionString, serverVersion));

builder.Services.AddCors(options => options.AddPolicy("AllowWepApp",
    builder => builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()));

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
    app.UseCors("AllowWepApp");
}

app.UseMiddleware<JwtMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
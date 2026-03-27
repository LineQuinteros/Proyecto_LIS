using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LIS.API.Data;


AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<LISAPIContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("LIS_Render") ?? throw new InvalidOperationException("Connection string 'LISAPIContext' not found.")));

// Add services to the container.


builder.Services.AddControllers();
//Agregados:
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

{
    app.MapOpenApi();
    //Habilitar interfaz swagger
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

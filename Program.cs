using Exames.API.Context;
using Exames.API.Repositories;
using Exames.API.Repositories.Interfaces;
using Exames.API.Services;
using Exames.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        policy =>
        {
            policy
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddScoped<IExameRepository, ExameRepository>();
builder.Services.AddScoped<IExameService, ExameService>();

var mySqlConnection = builder.Configuration.GetConnectionString("MySQL");
builder.Services.AddDbContext<ExameDbContext>(options => options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

builder.Services.AddAutoMapper(_ => { }, AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference();

app.UseCors("AllowLocalhost");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

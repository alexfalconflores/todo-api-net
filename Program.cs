using Microsoft.EntityFrameworkCore;
using TodoAPI.Data;
using TodoAPI.Endpoints;
using TodoAPI.Repositories;
using TodoAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar el DbContext con la cadena de conexion
builder.Services.AddDbContext<TodoAppContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("TodoAppDb"), 
        sqlServerOptions => sqlServerOptions.EnableRetryOnFailure()
    ));

// Registrar los repositorios
builder.Services.AddScoped<ITasksRepository, TasksRepository>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();

// Registrar los servicios
builder.Services.AddScoped<ExcelService>();
builder.Services.AddScoped<CSVService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Registrar los endpoints
app.MapTasksEndpoints();
app.MapUsersEndpoints();

app.Run();

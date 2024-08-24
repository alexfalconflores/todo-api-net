using Microsoft.EntityFrameworkCore;
using TodoAPI.Data;
using TodoAPI.Endpoints;
using TodoAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configurar el DbContext con la cadena de conexion
builder.Services.AddDbContext<TodoAppContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("TodoAppDb"), 
        sqlServerOptions => sqlServerOptions.EnableRetryOnFailure()
    ));
// Registrar los repositorios
builder.Services.AddScoped<ITasksRepository, TasksRepository>();

var app = builder.Build();

// Registrar los endpoints
app.MapTasksEndpoints();

app.MapGet("/", () => "Hello World!");

app.Run();

using TodoAPI.Repositories;
using Task = TodoAPI.Models.Task;

namespace TodoAPI.Endpoints;

public static class TasksEndpoints
{
    public static void MapTasksEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/tasks");
        group.WithTags("Tasks");

        group.MapGet("/", async (ITasksRepository repository) =>
        {
            var tasks = await repository.GetAllTasks();
            return Results.Ok(tasks);
        })
        .WithName("GetAllTasks");

        group.MapGet("/user/{userId:int}", async (int userId, bool? isCompleted, DateTime? dueDate, ITasksRepository repository) =>
        {
            var tasks = await repository.GetTasksByUserId(userId, isCompleted, dueDate);
            return Results.Ok(tasks);
        })
        .WithName("GetTasksByUserId");

        group.MapGet("/{id:int}", async (int id, ITasksRepository repository) =>
        {
            var task = await repository.GetTaskById(id);
            if (task == null) return Results.NotFound();
            return Results.Ok(task);
        })
        .WithName("GetTaskById");

        group.MapPost("/", async (Task task, ITasksRepository repository) =>
        {
            int result = await repository.AddTask(task);
            return Results.Ok(result);
        })
        .WithName("CreateTask");

        group.MapPut("/{id:int}", async (int id, Task task, ITasksRepository repository) =>
        {
            task.TaskId = id;
            int result = await repository.UpdateTask(task);
            return Results.Ok(result);
        })
        .WithName("UpdateTask");

        group.MapDelete("/{id:int}", async (int id, ITasksRepository repository) =>
        {
            int result = await repository.DeleteTask(id);
            return Results.Ok(result);
        })
        .WithName("DeleteTask");
    }
}

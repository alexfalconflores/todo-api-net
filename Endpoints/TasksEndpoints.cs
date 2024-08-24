using TodoAPI.Repositories;

namespace TodoAPI.Endpoints;

public static class TasksEndpoints
{
    public static void MapTasksEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/tasks");
        group.MapGet("/", async (ITasksRepository tasksRepository) =>
        {
            var tasks = await tasksRepository.GetAllTasksAsync();
            return Results.Ok(tasks);
        })
        .WithName("GetAllTasks");
    }
}

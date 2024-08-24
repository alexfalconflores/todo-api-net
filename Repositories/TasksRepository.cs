using TodoAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace TodoAPI.Repositories;

public class TasksRepository(TodoAppContext context): ITasksRepository
{
    public async Task<IEnumerable<Models.Task>> GetAllTasksAsync()
    {
        return await context.Tasks.FromSql($"EXEC sp_GetAllTasks")
            .ToListAsync();
    }
}

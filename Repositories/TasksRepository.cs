using TodoAPI.Data;
using Microsoft.EntityFrameworkCore;
using Task = TodoAPI.Models.Task;

namespace TodoAPI.Repositories;

public class TasksRepository(TodoAppContext context) : ITasksRepository
{
    public async Task<IEnumerable<Task>> GetAllTasks()
    {
        return await context.Tasks.FromSql($"EXEC sp_GetAllTasks").ToListAsync();
    }

    public async Task<IEnumerable<Task>> GetTasksByUserId(int userId, bool? isCompleted, DateTime? dueDate)
    {
        return await context
            .Tasks
            .FromSql($"EXEC sp_GetTasksByUserId @UserId = {userId}, @IsCompleted = {isCompleted ?? (object)DBNull.Value}, @DueDate = {dueDate ?? (object)DBNull.Value}")
            .ToListAsync();
    }

    public async Task<Task> GetTaskById(int id)
    {
        var tasks = await context.Tasks.FromSql($"EXEC sp_GetTaskById @TaskId = {id}").ToListAsync();
        return tasks.FirstOrDefault();
    }


    public async Task<int> AddTask(Task task)
    {
        task.IsCompleted = false;
        int result = await context.Database
            .ExecuteSqlAsync($"EXEC sp_CreateTask @Title = {task.Title}, @Description = {task.Description}, @IsCompleted = {task.IsCompleted}, @DueDate = {task.DueDate}, @UserId = {task.UserId}");
        return result;
    }

    public async Task<int> UpdateTask(Task task)
    {
        int result = await context.Database
            .ExecuteSqlAsync($"EXEC sp_UpdateTask @TaskId = {task.TaskId}, @Title = {task.Title}, @Description = ${task.Description}, @IsCompleted = {task.IsCompleted}, @DueDate = {task.DueDate}");
        return result;
    }

    public async Task<int> DeleteTask(int id)
    {
        int result = await context.Database.ExecuteSqlAsync($"EXEC sp_DeleteTask @TaskId = {id}");
        return result;
    }
}

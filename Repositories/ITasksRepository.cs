using Task = TodoAPI.Models.Task;
namespace TodoAPI.Repositories;

public interface ITasksRepository
{
    Task<IEnumerable<Task>> GetAllTasks();
    Task<IEnumerable<Task>> GetTasksByUserId(int userId, bool? isCompleted, DateTime? dueDate);
    Task<Task> GetTaskById(int id);
    Task<int> AddTask(Task task);
    Task<int> UpdateTask(Task task);
    Task<int> DeleteTask(int id);
}

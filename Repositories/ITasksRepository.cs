namespace TodoAPI.Repositories;

public interface ITasksRepository
{
    Task<IEnumerable<Models.Task>> GetAllTasksAsync();
}

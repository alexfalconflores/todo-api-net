using TodoAPI.Models;

namespace TodoAPI.Repositories;

public interface IUsersRepository
{
    Task<IEnumerable<User>> GetAllUsers();
    Task<User> GetUserById(int id);
    Task<int> AddUser(User user);
    Task<int> UpdateUser(User user);
    Task<int> DeleteUser(int id);
}

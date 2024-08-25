using Microsoft.EntityFrameworkCore;
using TodoAPI.Data;
using TodoAPI.Models;

namespace TodoAPI.Repositories;

public class UsersRepository(TodoAppContext context) : IUsersRepository
{
    public async Task<int> AddUser(User user)
    {
        int result = await context.Database
            .ExecuteSqlAsync($"EXEC sp_CreateUser @Username = {user.UserName}, @Email = {user.Email}");
        return result;
    }

    public async Task<int> DeleteUser(int id)
    {
        int result =  await context.Database
            .ExecuteSqlAsync($"EXEC sp_DeleteUser @UserId = {id}");
        return result;
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await context.Users.FromSql($"EXEC sp_GetAllUsers").ToListAsync();
    }

    public async Task<User> GetUserById(int id)
    {
        var users = await context.Users.FromSql($"EXEC sp_GetUserById @UserId = {id}").ToListAsync();
        return users.FirstOrDefault();
    }

    public async Task<int> UpdateUser(User user)
    {
        int result = await context.Database
            .ExecuteSqlAsync($"EXEC sp_UpdateUser @UserId = {user.UserId}, @Username = {user.UserName}, @Email = {user.Email}");
        return result;
    }
}

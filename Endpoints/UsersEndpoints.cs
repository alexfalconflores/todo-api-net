using Microsoft.EntityFrameworkCore;
using TodoAPI.Data;
using TodoAPI.Repositories;

namespace TodoAPI.Endpoints;

public static class UsersEndpoints
{
    public static void MapUsersEndpoints(this WebApplication app)
    {
        //var repository = new TasksRepository();

        //app.MapGet("/users", async () => await db.Users.ToListAsync());
    }
}

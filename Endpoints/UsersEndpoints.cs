using TodoAPI.Models;
using TodoAPI.Repositories;

namespace TodoAPI.Endpoints;

public static class UsersEndpoints
{
    public static void MapUsersEndpoints(this IEndpointRouteBuilder routes)
    {
        RouteGroupBuilder? group = routes.MapGroup("/api/users");
        group.WithTags("Users");

        group.MapGet("/", async (IUsersRepository usersRepository) =>
        {
            var users = await usersRepository.GetAllUsers();
            return Results.Ok(users);
        })
        .WithName("GetAllUsers");

        group.MapGet("/{id:int}", async (int id, IUsersRepository repository) =>
        {
            var user = await repository.GetUserById(id);
            if (user == null) return Results.NotFound();
            return Results.Ok(user);
        })
        .WithName("GetUserById");

        group.MapPost("/", async (User user, IUsersRepository repository) =>
        {
            int result = await repository.AddUser(user);
            return Results.Ok(result);
        })
        .WithName("CreateUser");

        group.MapPut("/{id:int}", async (int id, User user, IUsersRepository repository) =>
        {
            user.UserId = id;
            int result = await repository.UpdateUser(user);
            return Results.Ok(result);
        })
        .WithName("UpdateUser");

        group.MapDelete("/{id:int}", async (int id, IUsersRepository repository) =>
        {
            int result = await repository.DeleteUser(id);
            return Results.Ok(result);
        })
        .WithName("DeleteUser");
    }
}

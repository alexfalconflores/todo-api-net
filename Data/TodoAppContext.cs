using Microsoft.EntityFrameworkCore;
using TodoAPI.Models;

namespace TodoAPI.Data;

public class TodoAppContext(DbContextOptions<TodoAppContext> options) : DbContext(options)
{
    public DbSet<Models.Task> Tasks { get; set; }
    public DbSet<User> Users { get; set; }
}
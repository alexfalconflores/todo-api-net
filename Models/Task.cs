﻿namespace TodoAPI.Models;

public class Task
{
    public int TaskId { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public bool IsCompleted { get; set; } = false;
    public DateTime? DueDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int UserId { get; set; }
}

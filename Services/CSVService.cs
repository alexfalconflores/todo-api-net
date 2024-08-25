using System.Text;
using Task = TodoAPI.Models.Task;

namespace TodoAPI.Services;

public class CSVService
{
    public async Task<Stream> ExportTasksToCsv(IEnumerable<Task> tasks)
    {
        MemoryStream memoryStream = new();
        using (StreamWriter streamWriter = new(memoryStream, Encoding.UTF8, leaveOpen: true))
        {
            // Escribir encabezados
            await streamWriter.WriteLineAsync("TaskId,Title,Description,IsCompleted,DueDate,CreatedAt,UpdatedAt");
            // Escribir datos
            foreach (Task task in tasks)
            {
                var line = $"{task.TaskId},{task.Title},{task.Description},{task.IsCompleted},{task.DueDate},{task.CreatedAt},{task.UpdatedAt}";
                await streamWriter.WriteLineAsync(line);
            }
        }
        memoryStream.Position = 0;
        return memoryStream;
    }
}

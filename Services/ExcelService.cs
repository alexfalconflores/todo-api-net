using ClosedXML.Excel;
using Task = TodoAPI.Models.Task;

namespace TodoAPI.Services;

public class ExcelService
{
    public Stream ExportTasksToExcel(IEnumerable<Task> tasks)
    {
        MemoryStream memoryStream = new();
        using (var workbook = new XLWorkbook())
        {
            // Agregar encabezados
            var worksheet = workbook.Worksheets.Add("Tasks");
            worksheet.Cell(1, 1).Value = "TaskId";
            worksheet.Cell(1, 2).Value = "Title";
            worksheet.Cell(1, 3).Value = "Description";
            worksheet.Cell(1, 4).Value = "IsCompleted";
            worksheet.Cell(1, 5).Value = "DueDate";
            worksheet.Cell(1, 6).Value = "CreatedAt";
            worksheet.Cell(1, 7).Value = "UpdatedAt";
            //worksheet.Cell(1, 8).Value = "UserId";

            // Agregar datos
            var row = 2;
            foreach (var task in tasks)
            {
                worksheet.Cell(row, 1).Value = task.TaskId;
                worksheet.Cell(row, 2).Value = task.Title;
                worksheet.Cell(row, 3).Value = task.Description;
                worksheet.Cell(row, 4).Value = task.IsCompleted;
                worksheet.Cell(row, 5).Value = task.DueDate;
                worksheet.Cell(row, 6).Value = task.CreatedAt;
                worksheet.Cell(row, 7).Value = task.UpdatedAt;
                //worksheet.Cell(row, 8).Value = task.UserId;
                row++;
            }
            // Guardar el archivo en el MemoryStream
            workbook.SaveAs(memoryStream);
        }
        // Resetear el stream a la posicion inicial
        memoryStream.Position = 0;
        return memoryStream;
    }
}

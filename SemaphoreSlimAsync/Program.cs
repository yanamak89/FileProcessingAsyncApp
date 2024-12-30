using System.Text;

class Program
{
    private static SemaphoreSlim _semaphore = new SemaphoreSlim(1);

     static async Task Main(string[] args)
    {
        string file1Path = args.Length > 0 ? args[0] : "file1.txt";
        string file2Path = args.Length > 1 ? args[1] : "file2.txt";
        string resultFilePath = args.Length > 2 ? args[2] : "result.txt";
        
        // Створюємо приклади файлів
        await File.WriteAllTextAsync(file1Path, "This is the content of file 1.\n");
        await File.WriteAllTextAsync(file2Path, "This is the content of file 2.\n");
        if (File.Exists(resultFilePath)) File.Delete(resultFilePath);

        // Викликаємо асинхронний метод для обробки файлів
        Task task1 = ProcessFileSequentialAsync(file1Path, resultFilePath);
        Task task2 = ProcessFileSequentialAsync(file2Path, resultFilePath);

        await Task.WhenAll(task1, task2); // Очікуємо завершення обох завдань
        
        Console.WriteLine("Data processing completed. Check the result file.");


    }

    private static async Task ProcessFileSequentialAsync(string sourceFilePath, string resultFilePath)
    {
        // Очікуємо доступу
        await _semaphore.WaitAsync();

        try
        {
            string content;

            // Читаємо дані з файлу
            using (var reader = new StreamReader(sourceFilePath))
            {
                content = await reader.ReadToEndAsync();
            }

            await Task.Delay(1000); // Симуляція затримки

            // Записуємо дані у вихідний файл
            using (var writer = new StreamWriter(resultFilePath, append: true, encoding: Encoding.UTF8))
            {
                writer.WriteLine($"[{DateTime.Now}] Data from {sourceFilePath}:\n{content}");
            }
        }
        finally
        {
            _semaphore.Release(); // Звільняємо доступ
        }
    }
}
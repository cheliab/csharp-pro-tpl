// Работа с исключениями

namespace N_012_TPL_Exception;

class Program
{
    /// <summary>
    /// Метод с исключением
    /// </summary>
    private static void MyTask()
    {
        Console.WriteLine("Задача запущена.");

        throw new Exception();
        
        Console.WriteLine("Задача завершена");
    }
    
    public static void Main()
    {
        Console.WriteLine("Основной поток запущен.");

        Task task = new Task(MyTask);

        try
        {
            task.Start();
            
            // Для обработки исключения обязательно вызвать Wait ()
            // task.Wait(); 
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.GetType()}");
            Console.WriteLine($"Message: {ex.Message}");

            if (ex.InnerException != null)
                Console.WriteLine($"Inner Exception: {ex.InnerException}");
        }
        finally
        {
            Console.WriteLine($"Статус задачи: {task.Status}");
        }

        Console.WriteLine("Основной поток завершен.");

        // Delay
        Console.ReadKey();
    }
}
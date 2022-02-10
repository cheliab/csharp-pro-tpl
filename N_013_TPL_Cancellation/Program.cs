using System;
using System.Threading;
using System.Threading.Tasks;

// Прерывание выполнения задачи с использованием токена отмены 

namespace N_013_TPL_Cancellation;

class Program
{
    /// <summary>
    /// Метод с возможностью отмены
    /// </summary>
    /// <param name="arg">Токен отмены</param>
    private static void MyTask(object arg)
    {
        CancellationToken token = (CancellationToken)arg;
        
        // Если задача сразу после старта отменена - кинуть исключение OperationCanceledException.
        token.ThrowIfCancellationRequested();
        
        Console.WriteLine("MyTask запущен.");

        for (int i = 0; i < 80; i++)
        {
            if (token.IsCancellationRequested) // проверка отмены
            {
                Console.WriteLine("\nПолучен запрос на отмену задачи.");
                // token.ThrowIfCancellationRequested(); // кинуть OperationCanceledException
            }
            
            Thread.Sleep(100);
            Console.Write(".");
        }
        
        Console.WriteLine("MyTask завершен.");
    }
    
    public static void Main()
    {
        Console.WriteLine("Основной поток запущен.");

        // Создать источник токенов отмены
        CancellationTokenSource cancellation = new CancellationTokenSource();
        CancellationToken token = cancellation.Token;

        Task task = new Task(MyTask, token);
        task.Start();
        
        Thread.Sleep(2000); // ждем пару сек

        try
        {
            cancellation.Cancel(); // Отмена выполняемой задачи (через 2 сек)
            task.Wait(); // Ждем завершения, чтобы обработать исключение
        }
        catch (AggregateException e)
        {
            if (task.IsCanceled)
                Console.WriteLine("\nЗадача отменена.\n");

            Console.WriteLine($"Inner exception: {e.InnerException.GetType()}");
            Console.WriteLine($"Message:         {e.InnerException.Message}");
            Console.WriteLine($"Статус задачи:   {task.Status}");
        }
    }
}
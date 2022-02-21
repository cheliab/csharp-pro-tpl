namespace N_014_TPL_ContinuationOptions;

class Propgram
{
    private static int MyTask()
    {
        byte result = 255;

        checked // убрать коммент для вызова исключения 
        {
            result += 1;
        }

        return result;
    }
    
    public static void Main()
    {
        Task<int> task = new Task<int>(MyTask);
        Action<Task<int>> continuation;
        
        // срабатывает при убранном "checked"
        continuation = t => Console.WriteLine($"Result: {t.Result}");
        task.ContinueWith(continuation, TaskContinuationOptions.OnlyOnRanToCompletion);

        // срабатывает при наличии "checked"
        continuation = t => Console.WriteLine($"Inner Exception: {t.Exception.InnerException.Message}");
        task.ContinueWith(continuation, TaskContinuationOptions.OnlyOnFaulted);

        task.Start();

        Console.ReadKey();
    }
}
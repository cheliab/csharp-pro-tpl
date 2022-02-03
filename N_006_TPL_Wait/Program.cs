// Пример организации задержки

namespace N_006_TPL_Wait
{
    class Program
    {
        private static void MyTask()
        {
            for (int i = 0; i < 80; i++)
            {
                Thread.Sleep(25);
                Console.Write(".");
            }
        }
        
        public static void Main()
        {
            Task task = new Task(MyTask);
            task.Start();
            
            Thread.Sleep(800);
            
            Console.Write(Environment.NewLine);
            Console.WriteLine($"task.IsCompleted = {task.IsCompleted}");
            
            // Ожидает завершения асинхронной задачи
            
            // Вариант 1:
            task.Wait(); // Первичный поток ждет завершения задачи (аналог Thread.Join())
            
            // Вариант 2:
            // while (!task.IsCompleted) // проверяем в цикле пока не завершится
            //     Thread.Sleep(100);
            
            // Вариант 3:
            // IAsyncResult asyncResult = task as IAsyncResult;
            // ManualResetEvent waitHandle = asyncResult.AsyncWaitHandle as ManualResetEvent;
            // waitHandle.WaitOne();

            Console.Write(Environment.NewLine);
            Console.WriteLine($"task.IsComplete = {task.IsCompleted}");
            
            // Delay
            Console.ReadKey();
        }
    }
}
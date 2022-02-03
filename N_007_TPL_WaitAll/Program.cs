// Ожидание завершения нескольких заданий

// WaitAll - ждать все здания
// WaitAny - ждать какое-то из заданий

namespace N_007_TPL_WaitAll
{
    class Program
    {
        private static void MyTask1()
        {
            Console.WriteLine($"MyTask1: CurrentId {Task.CurrentId} запущен.");
            Thread.Sleep(2000);
            Console.WriteLine($"MyTask2: CurrentId {Task.CurrentId} завершен.");
        }

        private static void MyTask2()
        {
            Console.WriteLine($"MyTask2: CurrentId {Task.CurrentId} запущен.");
            Thread.Sleep(3000);
            Console.WriteLine($"MyTask2: CurrentId {Task.CurrentId} завершен.");
        }
        
        public static void Main()
        {
            Console.WriteLine("Основной поток запущен.");
            
            Task task1 = new Task(MyTask1);
            Task task2 = new Task(MyTask2);
            
            task1.Start();
            task2.Start();
            
            Console.WriteLine($"Id задачи task1 {task1.Id}");
            Console.WriteLine($"Id задачи task2 {task2.Id}");

            // Task.WaitAll(task1, task2);
            Task.WaitAny(task1, task2);
            
            Console.WriteLine("Основной поток завершен.");
            
            Console.ReadKey();
        }
    }
}
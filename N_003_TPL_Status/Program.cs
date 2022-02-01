namespace N_003_TPL_Status 
{
    class Program
    {
        private static void MyTask()
        {
            Thread.Sleep(3000);
        }

        public static void Main()
        {
            Task task = new Task(MyTask);
            Console.WriteLine($"1. {task.Status}"); // Задача еще не запущена
            
            task.Start();
            Console.WriteLine($"2. {task.Status}"); // Задача в процессе запуска.
            
            Thread.Sleep(1000);
            Console.WriteLine($"3. {task.Status}"); // Задача выполняется.
            
            Thread.Sleep(3000);
            Console.WriteLine($"4. {task.Status}"); // Задача завершилась.

            // Delay
            Console.ReadKey();
        }
    }
}
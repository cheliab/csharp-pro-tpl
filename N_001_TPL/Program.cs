// Пример использования задачи - Task

namespace N_001_TPL
{
    class Program
    {
        /// <summary>
        /// Метод выполняемый асинхронно
        /// </summary>
        private static void MyTask()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;

            Console.Write(Environment.NewLine);
            Console.WriteLine($"MyTask: запуск в потоке # {threadId}");

            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(200);
                Console.Write("+ ");
            }
            
            Console.Write(Environment.NewLine);
            Console.WriteLine($"MyTask: завершен в потоке # {threadId}");
        }
        
        public static void Main()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            
            Console.WriteLine($"Main: запущен в потоке {threadId}");

            Action action = new Action(MyTask);

            Task task = new Task(action); // Создание экземпляра задачи
            //task.Start();               // Запуск задачи на выполнение асинхронно 
            
            task.RunSynchronously();      // Запуск задачи на выполнение синхронно

            for (int i = 0; i < 10; i++)
            {
                Console.Write(". ");
                Thread.Sleep(200);
            }

            Console.Write(Environment.NewLine);
            Console.WriteLine($"Main: завершен в потоке {threadId}");

            Console.ReadKey();
        }
    }
}
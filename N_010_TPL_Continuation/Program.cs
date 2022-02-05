// Продолжения - автоматический запуск новой задачи, после завершения первой задачи.
// Создание цепочек вызовов

namespace N_010_TPL_Continuation
{
    class Program
    {
        private static void MyTask()
        {
            for (int count = 0; count < 10; count++)
            {
                Thread.Sleep(200);
                Console.Write("+");
            }
        }

        /// <summary>
        /// Метод исполняемый как продолжение задачи
        /// </summary>
        /// <param name="task">Обязательный аргумент - предыдущая выполняемая задача</param>
        private static void ContinuationTask(Task task)
        {
            for (int count = 0; count < 10; count++)
            {
                Thread.Sleep(200);
                Console.Write("-");
            }
        }
        
        public static void Main()
        {
            Action action = new Action(MyTask);
            Task task = new Task(action);

            Action<Task> continuation = new Action<Task>(ContinuationTask);
            Task taskContinuation = task.ContinueWith(continuation);

            // Выполнение последовательности задач
            task.Start();
            
            Console.ReadKey();
        }

        
        /// <summary>
        /// Короткая версия
        /// </summary>
        private static void ShortVersion()
        {
            var task = new Task(MyTask);
            task.ContinueWith(ContinuationTask);
            
            task.Start();
        }
    }
}
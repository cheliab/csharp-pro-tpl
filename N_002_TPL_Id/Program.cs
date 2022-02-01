// Свойства Id и CurrentId
// Id - Уникальный идентификатор определенного экземпляра
// CurrentId - Уникальный идентификатор выполняющейся задачи

namespace TPL_Id 
{
    class Program
    {
        private static void MyTask()
        {
            Console.WriteLine("MyTask: CurrentId {0} с ManagedThreadId {1} запущен.",
                Task.CurrentId, Thread.CurrentThread.ManagedThreadId);
            
            Thread.Sleep(200);

            Console.WriteLine("MyTask: CurrentId {0} завершен.", Task.CurrentId);
        }

        public static void Main()
        {
            // Проверка является ли метод Main задачей
            Console.WriteLine("Main: Task.CurrentIf = {0}",
                Task.CurrentId == null ? "null" : Task.CurrentId.ToString());

            Task task1 = new Task(MyTask);
            Task task2 = new Task(MyTask);
            
            task1.Start();
            task2.Start();

            Console.WriteLine($"Id задачи task1: {task1.Id}");
            Console.WriteLine($"Id задачи task2: {task2.Id}");

            Console.ReadKey();
        }
    }
}
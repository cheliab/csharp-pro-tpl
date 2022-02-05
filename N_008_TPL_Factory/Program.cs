// Создание экземпляра задачи с использование фабрики задач
// (применение класса TaskFactory для создания и запуска задачи)

namespace N_008_TPL_Factory 
{
    class Program
    {
        private static void MyTask()
        {
            for (int i = 0; i < 80; i++)
            {
                Thread.Sleep(20);
                Console.Write(".");
            }
        }
        
        public void Main()
        {
            // Вариант 1.
            Task task = Task.Factory.StartNew(MyTask);
            // !!! - task.Start(); // При запуске задачи через TaskFactory, вызов метода Start() не требуется. 
            
            // // Вариант 2.
            // TaskFactory factory = new TaskFactory();
            // Task task = factory.StartNew(MyTask);

            // Delay
            Console.ReadKey();
        }
    }
}
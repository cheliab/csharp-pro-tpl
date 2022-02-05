// Использование лямбда-выражения в качестве задачи

using System.Globalization;

namespace N_009_Lambda
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Основной поток запущен.");

            // Использование лябда-оператора для опредения задачи
            Task task = Task.Factory.StartNew(new Action(() =>
                {
                    for (int i = 0; i < 80; i++)
                    {
                        Thread.Sleep(20);
                        Console.Write(".");
                    }
                }));

            // Ждем завершения задачи
            task.Wait();
            
            // Освобождение задачи
            task.Dispose();
            
            Console.WriteLine("Основной поток завершен.");

            // Delay
            Console.ReadKey();
        }
    }
}
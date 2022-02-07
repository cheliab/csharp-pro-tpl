//

namespace N_011_TPL_Return
{
    /// <summary>
    /// Структура для упаковки значений
    /// </summary>
    struct Context
    {
        public int a;
        public int b;
    }
    
    class Program
    {
        /// <summary>
        /// Метод возвращающий результат расчетов
        /// </summary>
        /// <param name="arg">Аргументы</param>
        /// <returns>Сумма</returns>
        private static int Sum(object arg)
        {
            int a = ((Context)arg).a;
            int b = ((Context)arg).b;
            
            Thread.Sleep(2000);

            return a + b;
        }

        public static void Main()
        {
            Console.WriteLine("Основной поток запущен.");

            Context context;
            context.a = 2;
            context.b = 3;

            // вариант - 1
            Task<int> task1 = new Task<int>(Sum, context);
            task1.Start();
            
            // вариант - 2
            TaskFactory<int> factory = new TaskFactory<int>();
            Task<int> task2 = factory.StartNew(Sum, context);
            
            // вариант - 3
            Task<int> task3 = Task<int>.Factory.StartNew(Sum, context);

            // Результаты
            Console.WriteLine($"вариант 1 - Sum = {task1.Result}");
            Console.WriteLine($"вариант 2 - Sum = {task2.Result}");
            Console.WriteLine($"вариант 3 - Sum = {task3.Result}");

            Console.WriteLine("Основной поток завершен.");

            // Delay
            Console.ReadKey();
        }
    }
}
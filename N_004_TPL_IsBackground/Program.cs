// У задачи свойство IsBackground = true
// т.е. задача это фоновый поток
// Поэтому при завершении основного потока (Main),
// завершаются все задачи

namespace N_004_TPL_IsBackground
{
    class Program
    {
        private static void MyTask()
        {
            Thread.CurrentThread.IsBackground = false; // Делаем поток задачи основным (не фоновым)
            
            for (int i = 0; i < 80; i++)
            {
                Thread.Sleep(100);
                Console.Write(".");
            }
        }
        
        public static void Main()
        {
            Task task = new Task(MyTask);
            task.Start();
            
            Thread.Sleep(500);
            
            Console.WriteLine("Main завершен.");

            // Delay
            // Console.ReadKey();
        }
    }
}
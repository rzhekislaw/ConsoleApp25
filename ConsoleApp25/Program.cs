using System.Diagnostics;

namespace ns
{
    class tClass
    {
        private static Semaphore semaphore = new Semaphore(1, 1);

        public static void Main() 
        {
            Console.WriteLine("Semaphore(1, 1);");
            Console.WriteLine("Start time: " + DateTime.Now.ToString());
            for (int i = 1; i <= 10; i++)
            {
                var thread = new Thread(async () => { await ReadAsync(); });
                thread.Start();
            }
        }

        public async static Task ReadAsync()
        {
            semaphore.WaitOne();

            using (var reader = new StreamReader("file.txt"))
            {
                var tmp = reader.ReadToEnd();
                Console.WriteLine(DateTime.Now.ToString());
            }

            semaphore.Release();
        }
    }
}
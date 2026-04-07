using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DemoAsync
{
    public class Program
    {
        //static async Task Main(string[] args)
        //{
        //    //Console.WriteLine("Start!"); // => luong chinh
        //    ////do task 1
        //    ////DoTask(ConsoleColor.Green);
        //    //var task1 = Task.Run(() => { DoTask(ConsoleColor.Green); });
        //    //// do task 2
        //    ////DoTask(ConsoleColor.Red);
        //    //var task2 = Task.Run(() => { DoTask(ConsoleColor.Magenta); });

        //    //var task3 = new Task(() => { DoTask(ConsoleColor.Red); });

        //    //task3.Start();

        //    ////Task.WaitAll(task1,task2,task3); // => đợi tất cả hoàn thành mới chạy tiếp => nghẽn luồng Main
        //    ////Task.WhenAll(task1, task2, task3); // => chạy song song với luồng chính và đợi tất cả hoàn thành
        //    ////await Task.WhenAll(task1, task2, task3); // => đợi xong task mới chạy dòng tiếp theo tuy nhiên không block Main mà chỉ tạm dừng async  Main 
        //    //Console.WriteLine("code tiep theo");
        //    //Console.WriteLine("End!");// => luong chinh
        //    //Console.ReadLine();
        //}

        public static async Task Main(string[] args)
        {
            var watch = new Stopwatch();
            Console.WriteLine("Start!");
            watch.Start();

            var task1 = PourCoffee();
            var task2 = HeatPan();
            var task3 = FryEggs();
            var task4 = FryBacon();
            var task5 = ToastBread();
            var task6 = JamOnBread();
            var task7 = PourJuice();

            await Task.WhenAll();

            Console.WriteLine("Breakfast is ready!");
            watch.Stop();
            Console.WriteLine(watch.Elapsed.TotalMilliseconds.ToString());
            Console.WriteLine("End!");
            Console.ReadLine();
        }


        private static async Task PourCoffee()
        {
            await Task.Delay(1000);
            Console.WriteLine("1. Coffee ready!");
        }

        private static async Task HeatPan()
        {
            await Task.Delay(1000);
            Console.WriteLine("2. Pan ready!");
        }

        // Hàm này là hàm đồng bộ hoàn toàn không thể dùng await
        private static string ReturnString()
        {
            var res = GetData();
            return res;
        }

        // Hàm này là hàm đồng bộ nội bộ có thể sử dụng trong các hàm bất đồng bộ khác với await
        private static Task<string> ReturnStringAsync()
        {
            Task.Delay(1000).Wait();
            var res = GetData();
            return Task.FromResult(res);
        }

        private static string GetData()
        {
            return "Haha";
        }

        private static async Task FryEggs()
        {
            await Task.Delay(1000);
            Console.WriteLine("3. Eggs ready!");
        }

        private static async Task FryBacon()
        {
            await Task.Delay(1000);
            Console.WriteLine("4. Bacon ready!");
        }

        private static async Task ToastBread()
        {
            await Task.Delay(1000);
            Console.WriteLine("5. Bread ready!");
        }

        private static async Task JamOnBread()
        {
            await Task.Delay(1000);
            Console.WriteLine("6. Jam ready!");
        }

        private static async Task PourJuice()
        {
            await Task.Delay(1000);
            Console.WriteLine("7. Juice ready!");
        }

        static void DoTask(ConsoleColor color)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.ForegroundColor = color;
                Console.WriteLine("I = " + i);
                Console.ResetColor();
            }
        }


    }
}

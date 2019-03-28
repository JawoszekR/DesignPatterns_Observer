using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            WetherStation ws = new WetherStation();
            CurrentWether cw = new CurrentWether(ws);
            AverageWether aw = new AverageWether(ws);

            for (int i = 0; i < 100; i++)
            {
                ws.Temperature = random.NextDouble() * 40.0 - 15.0;
                ws.Pressure = random.NextDouble() * 100 + 1000;
                ws.Humidity = random.NextDouble();
                ws.Rain = (random.NextDouble() > 0.5);
                ws.NotifyAllObservers();
                Console.WriteLine("Day " + (i+1));
                Console.WriteLine();
                cw.DisplayWeather();
                aw.DisplayWeather();
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}

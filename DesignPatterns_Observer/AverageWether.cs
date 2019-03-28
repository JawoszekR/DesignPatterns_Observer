using DesignPatterns_Observer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_Observer
{
    class AverageWether : IObserver, IWeather
    {
        public List<double> TemperatureList { get; set; }
        public List<double> PressureList { get; set; }
        public List<double> HumidityList { get; set; }

        private IObservable observable;

        public AverageWether(IObservable observable)
        {
            this.observable = observable;
            observable.AddSubscription(this);

            TemperatureList = new List<double>();
            PressureList = new List<double>();
            HumidityList = new List<double>();
        }

        public void DisplayWeather()
        {
            Console.WriteLine("Average temperature: " + TemperatureList.Average());
            Console.WriteLine("Average pressure: " + PressureList.Average());
            Console.WriteLine("Average humidity: " + HumidityList.Average());
        }

        public void UpdateObserver()
        {
            WetherStationDTO pulledData = observable.GetData();
            TemperatureList.Add(pulledData.Temperature);
            PressureList.Add(pulledData.Pressure);
            HumidityList.Add(pulledData.Humidity);
        }
    }
}

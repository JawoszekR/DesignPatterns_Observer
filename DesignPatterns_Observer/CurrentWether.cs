using DesignPatterns_Observer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_Observer
{
    class CurrentWether : IObserver, IWeather
    {
        public double Temperature { get; set; }
        public double Pressure { get; set; }
        public double Humidity { get; set; }
        public bool Rain { get; set; }

        private IObservable observable;

        public CurrentWether(IObservable observable)
        {
            this.observable = observable;
            observable.AddSubscription(this);
        }

        public void UpdateObserver()
        {
            WetherStationDTO pulledData = observable.GetData();
            Temperature = pulledData.Temperature;
            Pressure = pulledData.Pressure;
            Humidity = pulledData.Humidity;
            Rain = pulledData.Rain;
        }

        public void DisplayWeather()
        {
            Console.WriteLine("Temperature: " + Temperature);
            Console.WriteLine("Pressure: " + Pressure);
            Console.WriteLine("Humidity: " + Humidity);
            Console.WriteLine("Rain: " + Rain);
        }
    }
}

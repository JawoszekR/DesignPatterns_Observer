using DesignPatterns_Observer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_Observer
{
    class WetherStation : IObservable
    {
        public double Temperature { get; set; }
        public double Pressure { get; set; }
        public double Humidity { get; set; }
        public bool Rain { get; set; }
        private List<IObserver> observersList;

        public WetherStation()
        {
            observersList = new List<IObserver>();
        }

        public void AddSubscription(IObserver newSubscribent)
        {
            observersList.Add(newSubscribent);
        }

        public WetherStationDTO GetData()
        {
            var dataToTransfer = new WetherStationDTO()
            {
                Humidity = this.Humidity,
                Rain = this.Rain,
                Temperature = this.Temperature,
                Pressure = this.Pressure
            };
            return dataToTransfer;
        }

        public void RemoveSubscription(IObserver subscribent)
        {
            observersList.Remove(subscribent);
        }

        public void NotifyAllObservers()
        {
            foreach (var observer in observersList)
            {
                observer.UpdateObserver();
            }
        }
    }
}

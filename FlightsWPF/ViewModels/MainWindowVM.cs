using Common.Services;
using Common.Types;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using FlightsWPF.Models;
using System.Linq;

namespace FlightsWPF.ViewModels
{
    public class MainWindowVM : ViewModelBase
    {
        private readonly IAppService _appService;
        public string Title 
        {
            get => GetValue<string>(nameof(Title)); 
            set => SetValue<string>(nameof(Title), value); 
        }

        public ObservableCollection<FlightInfoVM> Flights
        {
            get => GetValue<ObservableCollection<FlightInfoVM>>(nameof(Flights));
            set => SetValue<ObservableCollection<FlightInfoVM>>(nameof(Flights), value);
        }

        public FlightInfoVM First => Flights.First();
        public MainWindowVM(IAppService appService)
        {
            _appService = appService;
            Title = "Owen Test";

            Flights = new ObservableCollection<FlightInfoVM>()
            {
                new FlightInfoVM()
                {
                    DepartureTime = DateTime.Now,
                    FlightNumber = "First flight number",
                    Passengers = new List<Passenger>()
                    {
                        new Passenger("Vasya", "Pupkin", "Vasiliyevich"),
                        new Passenger("Akakii", "Petrov", "Petrovich")
                    }
                },
                new FlightInfoVM()
                {
                    DepartureTime = DateTime.Now,
                    FlightNumber = "Second flight number",
                    Passengers = new List<Passenger>()
                    {
                        new Passenger("Vasya", "Vasiliev", "Vasiliyevich"),
                        new Passenger("Petr", "Petrov", "Petrovich")
                    }
                }
            };
        }
    }
}

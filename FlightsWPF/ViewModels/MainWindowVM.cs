using Common.Services;
using Common.Types;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using FlightsWPF.Models;
using System.Linq;
using FlightsWPF.ViewModels.Base;
using System.Net.Http.Headers;
using Microsoft.Win32;
using FlightsWPF.Helpers.Extensions;
using System.Runtime;
using System.Collections.Specialized;
using System.Windows.Documents;

namespace FlightsWPF.ViewModels
{
    public class MainWindowVM : PropertyChangedBase
    {
        private readonly IFlightsService _flightsService;
        public string Title 
        {
            get => GetValue<string>(nameof(Title)); 
            set => SetValue<string>(nameof(Title), value); 
        }

        public FlightsCollection Flights
        {
            get => GetValue<FlightsCollection>(nameof(Flights));
            set
            {
                SetValue<FlightsCollection>(nameof(Flights), value);
                NotifyPropertyChanged(nameof(FlightsLoaded));
            }
        }

        public FlightInfoVM SelectedFlight
        {
            get => GetValue<FlightInfoVM>(nameof(SelectedFlight));
            set => SetValue<FlightInfoVM>(nameof(SelectedFlight), value);
        }

        public PassengerVM SelectedPassenger
        {
            get => GetValue<PassengerVM>(nameof(SelectedPassenger));
            set => SetValue<PassengerVM>(nameof(SelectedPassenger), value);
        }

        public string LoadedFilePath
        {
            get => GetValue<string>(nameof(LoadedFilePath));
            set => SetValue<string>(nameof(LoadedFilePath), value);
        }

        public bool FlightsLoaded
        {
            get => GetValue<bool>(nameof(FlightsLoaded));
            set => SetValue<bool>(nameof(FlightsLoaded), value);
                
        }

        public Command CommandExit { get; private set; }
        public Command CommandLoadFile { get; private set; }
        public Command CommandSaveFile { get; private set; }
        public Command<PassengerVM> CommandRemovePassenger { get; private set; }
        public Command CommandAddNewPassenger { get; private set; }
        public Command CommandAddFlight { get; private set; }

        public FlightInfoVM First => Flights.First();
        public MainWindowVM(IFlightsService flightsService)
        {
            _flightsService = flightsService;

            CommandExit = new Command(ExitExecute);
            CommandLoadFile = new Command(LoadFileExecute);
            CommandSaveFile = new Command(SaveFileExecute);
            CommandRemovePassenger = new Command<PassengerVM>(RemovePassengerExecute);
            CommandAddNewPassenger = new Command(AddNewPassengerExecute);
            CommandAddFlight = new Command(AddNewFlightExecute);

            Title = "Owen Test";
            Flights = new FlightsCollection();
        }

        private void ExitExecute()
        {
            App.Current.Shutdown();
        }

        private void LoadFileExecute()
        {

            var openFileDialod = new OpenFileDialog();

            if (openFileDialod.ShowDialog().Value)
            {
                Flights = new FlightsCollection();

                var filePath = openFileDialod.FileName;
                var flights = _flightsService.Load(filePath);

                foreach (var flight in flights)
                    Flights.Add(flight.CastToFlightVM());

                LoadedFilePath = filePath;
            }
        }

        private void SaveFileExecute()
        {
            var saveFileDialog = new SaveFileDialog();

            if (saveFileDialog.ShowDialog().Value)
            {
                var filePath = saveFileDialog.FileName;
                var flights = new List<FlightInfo>();

                foreach (var flight in Flights)
                {
                    flights.Add(flight.CastToFlight());
                }
                _flightsService.Save(flights, filePath);
            }
        }

        private void RemovePassengerExecute(PassengerVM passengerVM)
        {
            if (SelectedFlight != null)
                if (SelectedFlight.Passengers.Any(x => x.Id == passengerVM.Id))
                {
                    var flight = Flights.Where(f => f.Id == SelectedFlight.Id).First();
                    var pass = flight.Passengers.Find(p => p.Id == passengerVM.Id);
                    flight.Passengers.Remove(pass);

                    Flights.Refresh();
                }
        }

        private void AddNewPassengerExecute()
        {
            if (SelectedFlight != null)
                SelectedFlight.Passengers.Add(new PassengerVM("FirstName", "LastName", "Patronomyc"));
            Flights.Refresh();
        }

        private void AddNewFlightExecute()
        {
            Flights.Add(new FlightInfoVM()
            {
                FlightNumber = "Flight number",
                DepartureTime = DateTime.Now,
                Passengers = new List<PassengerVM>() 
                {
                    new PassengerVM("FirstName", "LastName", "Patronomyc")
                }
            });
        }
    }
}

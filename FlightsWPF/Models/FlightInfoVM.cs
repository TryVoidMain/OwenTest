using Common.Types;
using System.Collections.Generic;
using System;
using System.Linq;
using FlightsWPF.Helpers.Extensions;
using FlightsWPF.ViewModels;

namespace FlightsWPF.Models
{
    public class FlightInfoVM : PropertyChangedBase
    {
        public Guid Id 
        { 
            get => GetValue<Guid>(nameof(Id)); 
            set => SetValue<Guid>(nameof(Id), value); 
        }
        public DateTime DepartureTime
        {
            get => GetValue<DateTime>(nameof(DepartureTime));
            set => SetValue<DateTime>(nameof(DepartureTime), value);
        }
        public string FlightNumber
        {
            get => GetValue<string>(nameof(FlightNumber));
            set => SetValue<string>(nameof(FlightNumber), value);
        }
        public List<PassengerVM> Passengers
        {
            get => GetValue<List<PassengerVM>>(nameof(Passengers));
            set => SetValue<List<PassengerVM>>(nameof(Passengers), value);
        }
        public FlightInfoVM() { }
        public FlightInfoVM(DateTime departureTime, string flightNumber, List<PassengerVM> passengers)
        {
            Id = Guid.NewGuid();
            DepartureTime = departureTime;
            FlightNumber = flightNumber;
            Passengers = passengers;
        }

        public FlightInfoVM(FlightInfo flight)
        {
            Passengers = new List<PassengerVM>();

            if (flight.Passengers.Any())
            {
                foreach (var pass in flight.Passengers)
                    Passengers.Add(pass.CastToPassengerVM());
            }

            Id = Guid.NewGuid();
            DepartureTime = flight.DepartureTime;
            FlightNumber = flight.FlightNumber;
        }
    }
}

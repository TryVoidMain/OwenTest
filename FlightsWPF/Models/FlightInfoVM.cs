using Common.Types;
using System.Collections.Generic;
using System;

namespace FlightsWPF.Models
{
    public class FlightInfoVM
    {
        public Guid Id { get; set; }
        public DateTime DepartureTime { get; set; }
        public string FlightNumber { get; set; }
        public List<Passenger> Passengers { get; set; }
        public FlightInfoVM() { }
        public FlightInfoVM(DateTime departureTime, string flightNumber, List<Passenger> passengers)
        {
            Id = Guid.NewGuid();
            DepartureTime = departureTime;
            FlightNumber = flightNumber;
            Passengers = passengers;
        }
    }
}

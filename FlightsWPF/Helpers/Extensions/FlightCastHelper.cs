using Common.Types;
using System.Collections.Generic;
using FlightsWPF.Models;
using System.Linq;

namespace FlightsWPF.Helpers.Extensions
{
    public static class FlightCastHelper
    {
        public static FlightInfoVM CastToFlightVM(this FlightInfo flightInfo)
        {
            return new FlightInfoVM(flightInfo);
        }

        public static FlightInfo CastToFlight(this FlightInfoVM flightInfo)
        {
            var passengers = new List<Passenger>();

            foreach (var pass in flightInfo.Passengers)
                passengers.Add(pass.CastToPassenger());

            return new FlightInfo()
            {
                DepartureTime = flightInfo.DepartureTime,
                FlightNumber = flightInfo.FlightNumber,
                Passengers = passengers
            };
        }
    }
}

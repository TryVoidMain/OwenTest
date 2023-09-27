using Common.Types;
using FlightsWPF.Models;

namespace FlightsWPF.Helpers.Extensions
{
    public static class PassengerCastHelper
    {
        public static Passenger CastToPassenger(this PassengerVM passengerVM)
        {
            return new Passenger(
                passengerVM.FirstName,
                passengerVM.LastName,
                passengerVM.Patronomyc);
        }

        public static PassengerVM CastToPassengerVM(this Passenger passenger)
        {
            return new PassengerVM(passenger);
        }
    }
}

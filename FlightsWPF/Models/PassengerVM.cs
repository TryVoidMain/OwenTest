using Common.Types;
using FlightsWPF.ViewModels;
using System;

namespace FlightsWPF.Models
{
    public class PassengerVM : PropertyChangedBase
    {
        public Guid Id
        {
            get => GetValue<Guid>(nameof(Id));
            set => SetValue<Guid>(nameof(Id), value);
        }
        public string FirstName
        {
            get => GetValue<string>(nameof(FirstName));
            set => SetValue<string>(nameof(FirstName), value);
        }
        public string LastName
        {
            get => GetValue<string>(nameof(LastName));
            set => SetValue<string>(nameof(LastName), value);
        }
        public string Patronomyc
        {
            get => GetValue<string>(nameof(Patronomyc));
            set => SetValue<string>(nameof(Patronomyc), value);
        }

        public PassengerVM()
        {
            Id = Guid.NewGuid();
        }

        public PassengerVM(string firstName, string lastName, string patronomyc) : this()
        {
            FirstName = firstName;
            LastName = lastName;
            Patronomyc = patronomyc;
        }
        public PassengerVM(Passenger passenger) : this()
        {
            FirstName = passenger.FirstName;
            LastName = passenger.LastName;
            Patronomyc = passenger.Patronomyc;
        }
    }
}

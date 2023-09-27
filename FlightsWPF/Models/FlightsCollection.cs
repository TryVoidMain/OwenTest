using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using Common.Types;

namespace FlightsWPF.Models
{
    public class FlightsCollection : ObservableCollection<FlightInfoVM>
    {
        public void AddRange(IEnumerable<FlightInfoVM> flightsInfoVM)
        {
            foreach (var flightInfoVM in flightsInfoVM)
            {
                flightInfoVM.PropertyChanged += FlightInfoVM_PropertyChanged;
                base.Add(flightInfoVM);
            }
        }

        public new void Add(FlightInfoVM flightInfoVM)
        {
            flightInfoVM.PropertyChanged += FlightInfoVM_PropertyChanged;

            base.Add(flightInfoVM);
        }

        public new void Remove(FlightInfoVM flightInfoVM)
        {
            flightInfoVM.PropertyChanged -= FlightInfoVM_PropertyChanged;
            base.Remove(flightInfoVM);
        }

        public new void Clear()
        {
            foreach (var flightInfoVM in this)
            {
                flightInfoVM.PropertyChanged -= FlightInfoVM_PropertyChanged;
            }
            base.Clear();
        }

        public void Refresh()
        {
            // Workaround to force manual collection refreshing (to update styles for example)
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        private void FlightInfoVM_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            FlightInfoVMChanged?.Invoke((FlightInfoVM)sender, e);
        }

        public event Action<FlightInfoVM, PropertyChangedEventArgs> FlightInfoVMChanged;
    }
}

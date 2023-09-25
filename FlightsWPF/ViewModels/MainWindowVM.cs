using Common.Services;

namespace FlightsWPF.ViewModels
{
    public class MainWindowVM : ViewModelBase
    {
        public string Title 
        {
            get => GetValue<string>(nameof(Title)); 
            set => SetValue<string>(nameof(Title), value); 
        }
        public MainWindowVM()
        {
            Title = "Owen Test";
        }
    }
}

using Common.Services;

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
        public MainWindowVM(IAppService appService)
        {
            _appService = appService;
            Title = "Owen Test";
        }
    }
}

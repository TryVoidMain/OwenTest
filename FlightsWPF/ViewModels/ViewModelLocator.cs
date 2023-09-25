using Microsoft.Extensions.DependencyInjection;

namespace FlightsWPF.ViewModels
{
    public class ViewModelLocator
    {
        public MainWindowVM MainWindowViewModel => App.Services.GetRequiredService<MainWindowVM>();
    }
}

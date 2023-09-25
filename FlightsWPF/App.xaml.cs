using Common.Infrastructure;
using Common.Services;
using Common.Types;
using FlightsWPF.ViewModels;
using FlightsWPF.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Collections.Generic;
using System.Windows;

namespace FlightsWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost? Hosting { get; private set; }
        public static IServiceProvider Services => Hosting?.Services;
        public App()
        {
            Hosting = Host.CreateDefaultBuilder()
                        .ConfigureServices(ConfigureServices)
                        .Build();

            var logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(string.Join("/", Environment.CurrentDirectory, "log.txt"))
                .CreateLogger();

            Logger.Init(logger);
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await Hosting!.StopAsync();

            var mainWindow = Services.GetRequiredService<MainWindow>();
            mainWindow!.DataContext = Services.GetRequiredService<MainWindowVM>();
            mainWindow!.Show();

            base.OnStartup(e);

            Logger.Debug("Application builded");

            Dispatcher.UnhandledException += (o, ea) =>
            {
                var message = $"{ea.Exception.Message}";
                Logger.Fatal(ea.Exception.ToString());
                MessageBox.Show("Error", message, MessageBoxButton.OK);
                ea.Handled = true;
            };
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await Hosting!.StopAsync();
            base.OnExit(e);
        }

        private static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.AddSingleton<MainWindow>();
            services.AddSingleton<IAppService, AppService>();
            services.AddSingleton<MainWindowVM>();
        }
    }
}

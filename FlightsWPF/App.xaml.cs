﻿using Common.Infrastructure;
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
        public App()
        {
            var logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(string.Join("/", Environment.CurrentDirectory, "log.txt"))
                .CreateLogger();

            Logger.Init(logger);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
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
    }
}
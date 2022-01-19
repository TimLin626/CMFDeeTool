using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace CMF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// <summary>
    /// App.xaml 的互動邏輯
    /// </summary>
    public partial class App : Application
    {
        readonly string assemblyName;
        readonly Mutex mutex;
        readonly bool isCreateNew;
        public App()
        {
            assemblyName = Assembly.GetEntryAssembly().GetName().Name;
            mutex = new Mutex(true, $"Global\\{assemblyName}", out isCreateNew);

            if (!isCreateNew)
            {
                MessageBox.Show($"{assemblyName} 正在執行中", "重複開啟", MessageBoxButton.OK, MessageBoxImage.Warning);
                Current.Shutdown();
            }

            DispatcherUnhandledException += App_DispatcherUnhandledException;
        }

        protected override void OnExit(ExitEventArgs e)
        {
            if (isCreateNew) mutex.ReleaseMutex();
            mutex.Dispose();
            base.OnExit(e);
        }

        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            string error1 = $"{e.Exception.Message}\n{e.Exception.StackTrace}";
            string error2 = e.Exception.InnerException?.StackTrace;

            MessageBox.Show(
                $"{error1}{Environment.NewLine}{error2}",
                "»Ý³B²zªº¿ù»~",
                MessageBoxButton.OK,
                MessageBoxImage.Error);

            e.Handled = true;
        }
    }
}

using Prism.Mvvm;
using System;
using System.Globalization;
using System.Reflection;
using System.Windows;

namespace Tvn.Cosine.Wpf.Demo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //This change to use viewmodels with the views in same namespace
            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver((viewType) =>
            {
                var viewName = viewType.FullName;
                var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
                var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}ViewModel, {1}", viewName, viewAssemblyName);
                return Type.GetType(viewModelName);
            });

            var bootstrapper = new Bootstrapper();
            bootstrapper.Run();
        }
    }
}

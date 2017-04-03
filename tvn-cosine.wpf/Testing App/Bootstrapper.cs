using Prism.Unity;
using Microsoft.Practices.Unity;
using System.Windows;
using Testing_App.Views.Windows;
using Tvn.Cosine.Data;
using Tvn.Cosine.Wpf.Views.UserControls;

namespace Testing_App
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureContainer()
        {
            Container.RegisterType(typeof(IZone), typeof(Zone));
            base.ConfigureContainer();
        }
    }
}

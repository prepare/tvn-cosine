using Prism.Unity;
using Microsoft.Practices.Unity;
using System.Windows;
using Tvn.Cosine.Wpf.Demo.Views.Windows;
using Tvn.Cosine.Data;

namespace Tvn.Cosine.Wpf.Demo
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
            Container.RegisterType(typeof(IZone), typeof(Wpf.Views.UserControls.Zone));
            base.ConfigureContainer(); 
        }
    }
}

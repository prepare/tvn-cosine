using Prism.Unity;
using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tvn.Cosine.Wpf.Views.Windows;

namespace Tvn.Cosine.Wpf
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
            base.ConfigureContainer();
        }
    }
}

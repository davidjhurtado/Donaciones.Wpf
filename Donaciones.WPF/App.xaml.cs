using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using Autofac;
using System.Windows;

namespace Donaciones.WPF {
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App :Application {
        private void Application_Startup(object sender,StartupEventArgs e) {
            Startup startup = new Startup();
            var container = startup.Bootstrap();
            ProductosView window = container.Resolve<ProductosView>();
            window.Show();
        }
    }
}

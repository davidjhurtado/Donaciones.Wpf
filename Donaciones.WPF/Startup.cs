using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donaciones.WPF {
    public class Startup {
        public IContainer Bootstrap() {
            ContainerBuilder containerbuilder = new ContainerBuilder();
            containerbuilder.RegisterType<DonacionesDBEntities>().AsSelf();
            containerbuilder.RegisterType<BeneficiariosRepository>().As<IBeneficiariosRepository>();
            containerbuilder.RegisterType<ProductosRepository>().As<IProductosRepository>();
            containerbuilder.RegisterType<BeneficiariosViewModel>().AsSelf();
            containerbuilder.RegisterType<ProductosViewModel>().AsSelf();
            containerbuilder.RegisterType<ProductosView>().AsSelf();
            containerbuilder.RegisterType<MainWindow>().AsSelf();
            return containerbuilder.Build();
        }
    }
}

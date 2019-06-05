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
            containerbuilder.RegisterType<OrdenesRepository>().As<IOrdenesRepository>();
            containerbuilder.RegisterType<BeneficiariosRepository>().As<IBeneficiariosRepository>();
            containerbuilder.RegisterType<ProductosRepository>().As<IProductosRepository>();
            containerbuilder.RegisterType<OrdenesViewModel>().As<IOrdenesViewModel>();
            containerbuilder.RegisterType<BeneficiariosViewModel>().As<IBeneficiariosViewModel>();
            containerbuilder.RegisterType<ProductosViewModel>().As<IProductosViewModel>();
            containerbuilder.RegisterType<ListProductosViewModel>().As<IListProductosViewModel>();
            containerbuilder.RegisterType<MainWindow>().AsSelf();
            return containerbuilder.Build();
        }
    }
}

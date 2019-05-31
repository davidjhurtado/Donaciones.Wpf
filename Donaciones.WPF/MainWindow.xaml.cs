using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;

namespace Donaciones.WPF {
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow :Window {
        DonacionesDBEntities context = new DonacionesDBEntities ();
        CollectionViewSource benViewSource;
        CollectionViewSource ordViewSource;
        private readonly IProductosViewModel pvm;

        public MainWindow(IProductosViewModel pvm) {
            InitializeComponent();
            benViewSource = ((CollectionViewSource)(FindResource("beneficiariosViewSource")));
            ordViewSource = ((CollectionViewSource)(FindResource("beneficiariosOrdenesViewSource")));
            DataContext = this;
            this.pvm = pvm;
        }

        private void Window_Loaded(object sender,RoutedEventArgs e) {

            // Load is an extension method on IQueryable,    
            // defined in the System.Data.Entity namespace.   
            // This method enumerates the results of the query,    
            // similar to ToList but without creating a list.   
            // When used with Linq to Entities, this method    
            // creates entity objects and adds them to the context.   
            context.Beneficiarios.Load();
            context.Productos.Load();

        // After the data is loaded, call the DbSet<T>.Local property    
        // to use the DbSet<T> as a binding source.   
        benViewSource.Source = context.Beneficiarios.Local;
        }

        private void Open_Click(object sender,RoutedEventArgs e) {
            ProductosView productosView = new ProductosView(pvm);
            productosView.Show();
        }
    }
}

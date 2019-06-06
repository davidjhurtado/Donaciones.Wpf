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
using System.Windows.Shapes;

namespace Donaciones.WPF {
    /// <summary>
    /// Lógica de interacción para ProductosView.xaml
    /// </summary>
    public partial class ProductosView :Window {
        private readonly IProductosViewModel productosViewModel;

        public ProductosView(IProductosViewModel productosViewModel) {
            InitializeComponent();
            this.productosViewModel = productosViewModel;
            DataContext = this.productosViewModel;
        }

        private void Window_Loaded(object sender,RoutedEventArgs e) {            
//            System.Windows.Data.CollectionViewSource productosViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("productosViewSource")));
            // Cargar datos estableciendo la propiedad CollectionViewSource.Source:
            // productosViewSource.Source = [origen de datos genérico]
        }
    }
}

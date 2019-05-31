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
    /// Lógica de interacción para BeneficiariosVew.xaml
    /// </summary>
    public partial class BeneficiariosView :Window {
        private readonly IBeneficiariosViewModel beneficiariosViewModel;

        public BeneficiariosView(IBeneficiariosViewModel beneficiariosViewModel) {
            InitializeComponent();
            this.beneficiariosViewModel = beneficiariosViewModel;
            DataContext = this.beneficiariosViewModel;
        }

        private void Window_Loaded(object sender,RoutedEventArgs e) {

            
            // Cargar datos estableciendo la propiedad CollectionViewSource.Source:
            // beneficiariosViewSource.Source = [origen de datos genérico]
        }
    }
}

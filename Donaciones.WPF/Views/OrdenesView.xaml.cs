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
    /// Lógica de interacción para OrdenesView.xaml
    /// </summary>
    public partial class OrdenesView :Window {
        private readonly IOrdenesViewModel ordenesViewModel;

        public OrdenesView(IOrdenesViewModel ordenesViewModel) {
            InitializeComponent();
            this.ordenesViewModel = ordenesViewModel;
            DataContext = this.ordenesViewModel;
        }
    }
}

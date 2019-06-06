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
        private readonly IListProductosViewModel listProductosViewModel;

        public OrdenesView(IOrdenesViewModel ordenesViewModel, IListProductosViewModel listProductosViewModel) {
            InitializeComponent();
            this.ordenesViewModel = ordenesViewModel;
            this.listProductosViewModel = listProductosViewModel;
            DataContext = this.ordenesViewModel;
        }

        private void BtnLista_Click(object sender,RoutedEventArgs e) {
            ListProductosView listProductosView = new ListProductosView(listProductosViewModel);
            listProductosView.Show();
        }
    }
}

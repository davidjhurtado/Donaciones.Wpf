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

namespace Donaciones.WPF{
    /// <summary>
    /// Lógica de interacción para ListProductosView.xaml
    /// </summary>
    public partial class ListProductosView :Window {
        private IListProductosViewModel listProductosViewModel;

        public ListProductosView() {
            InitializeComponent();
        }

        internal void InitializeDataContext(IListProductosViewModel listProductosViewModel) {
            this.listProductosViewModel = listProductosViewModel;
            DataContext = listProductosViewModel;
            this.listProductosViewModel.CloseAction += CloseWindow;
        }
        private void CloseWindow() {
            this.Close();
        }
    }
}

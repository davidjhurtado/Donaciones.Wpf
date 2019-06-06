using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Donaciones.WPF {
    public interface IListProductosViewModel { }
    public class ListProductosViewModel :BaseViewModelComputed,IListProductosViewModel {
        private readonly IProductosRepository productosRepository;
        public ObservableCollection<Productos> lstProductos { get; set; }
        public ICommand SeleccionarElementoCommand { get; set; }
        public ListProductosViewModel( IProductosRepository productosRepository) {
            this.productosRepository = productosRepository;
            lstProductos = new ObservableCollection<Productos>();
            LoadProductos();
            RaisePropertyChanged(nameof(lstProductos));
            this.SeleccionarElementoCommand = new RelayCommand<Productos>(SeleccionarElementoCommand_Executed,SeleccionarElementoCommand_CanExecute);
        }

        private void LoadProductos() {
            lstProductos.Clear();
            IEnumerable<Productos> productos = productosRepository.GetProductos();
            foreach (var producto in productos) {
                lstProductos.Add(producto);
            }
        }

        private bool SeleccionarElementoCommand_CanExecute() {
            return true;
        }

        private void SeleccionarElementoCommand_Executed(Productos producto) {
            System.Windows.MessageBox.Show("DoubleClick " + producto.NombreProducto);
        }

        



        
    }
}

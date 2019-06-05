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
        public IEnumerable<Productos> lstProductos { get; set; }
        public ICommand SeleccionarElementoCommand;
        public ListProductosViewModel( IProductosRepository productosRepository) {
            this.productosRepository = productosRepository;
            lstProductos = this.productosRepository.GetProductos();
            RaisePropertyChanged(nameof(lstProductos));
        }

    }
}

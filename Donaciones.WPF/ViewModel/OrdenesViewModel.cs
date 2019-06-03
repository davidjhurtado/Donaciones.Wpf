using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donaciones.WPF {
    public interface IOrdenesViewModel { }
    public class OrdenesViewModel :BaseViewModelComputed, IOrdenesViewModel {

        private readonly IOrdenesRepository ordenesRepository;
        private ObservableCollection<OrdenesDetalle> obcOrdenesDetalle;

        public OrdenesViewModel(IOrdenesRepository ordenesRepository) {
            this.ordenesRepository = ordenesRepository;
        }
    }
}

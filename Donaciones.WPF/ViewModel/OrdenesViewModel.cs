using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Donaciones.WPF {
    public interface IOrdenesViewModel {
        Action ShowList { get; set; }
    }
    public class OrdenesViewModel :BaseViewModelComputed, IOrdenesViewModel {

        #region Variables
        private readonly IOrdenesRepository ordenesRepository;
        private readonly IBeneficiariosRepository beneficiariosRepository;
        private readonly IListProductosViewModel listProductosViewModel;
        private ObservableCollection<OrdenesDetalle> obcOrdenesDetalle;
        private OrdenesDetalle ordenesDetalle;
        private Ordenes Model;
        private int ActualOrderID;
        private bool CanCancel;

        public ICommand FirstCommand { get; set; }
        public ICommand MoveNextCommand { get; set; }
        public ICommand MovePreviousCommand { get; set; }
        public ICommand LastCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand AddDetailCommand { get; set; }
        public ICommand AddRowProductoCommand { get; set; }
        public ICommand CancelAddRowProductoCommand { get; set; }

        public Action ShowList { get; set; }
        #endregion

        #region Constructor
        public OrdenesViewModel(IOrdenesRepository ordenesRepository,IBeneficiariosRepository beneficiariosRepository, IListProductosViewModel listProductosViewModel) {
            this.ordenesRepository = ordenesRepository;
            this.beneficiariosRepository = beneficiariosRepository;
            this.listProductosViewModel = listProductosViewModel;
            InicializeModelWhenNull(ordenesRepository.GetFirstOrden());
            VerGrid = true;
            VerDetail = false;
            //listProductosViewModel.ListResult += ObtenerProductos;
            InizializedCommands();
        }

        private void ObtenerProductos(Productos productoseleccionado) {
            ProductoID = productoseleccionado.ProductoID;
            NombreProducto = productoseleccionado.NombreProducto;
        }

        private void InizializedCommands() {
            FirstCommand = new RelayCommand(FirstCommand_Executed,FirstCommand_CanExecute);
            MoveNextCommand = new RelayCommand(MoveNextCommand_Executed,MoveNextCommand_CanExecute);
            MovePreviousCommand = new RelayCommand(MovePreviousCommand_Executed,MovePreviousCommand_CanExecute);
            LastCommand = new RelayCommand(LastCommand_Executed,LastCommand_CanExecute);
            AddCommand = new RelayCommand(AddCommand_Executed,AddCommand_CanExecute);
            UpdateCommand = new RelayCommand(UpdateCommand_Executed,UpdateCommand_CanExecute);
            DeleteCommand = new RelayCommand(DeleteCommand_Executed,DeleteCommand_CanExecute);
            CancelCommand = new RelayCommand(CancelCommand_Executed,CancelCommand_CanExecute);
            AddDetailCommand = new RelayCommand(AddDetailCommand_Executed,AddDetailCommand_CanExecute);
            AddRowProductoCommand = new RelayCommand(AddRowProductoCommand_Executed,AddRowProductoCommand_CanExecute);
            CancelAddRowProductoCommand = new RelayCommand(AddRowProductoCommand_Executed,AddRowProductoCommand_CanExecute);
        }
        #endregion

        #region Propiedades
        public int OrdenID {
            get {
                return Model.OrdenID;
            }
            set {
                Model.OrdenID = value;
                RaisePropertyChanged();
            }
        }

        public string BeneficiarioID {
            get {
                return Model.BeneficiarioID;
            }
            set {
                Model.BeneficiarioID = value;
                RaisePropertyChanged();
            }
        }

        public DateTime? FechaEntregada {
            get {
                return Model.FechaEntregada;
            }

            set {
                Model.FechaEntregada = value;
                RaisePropertyChanged();
            }
        }

        public DateTime? FechaIngresada {
            get {
                return Model.FechaIngresada;
            }

            set {
                Model.FechaIngresada = value;
                RaisePropertyChanged();
            }
        }

        public DateTime? OrdenDate {
            get {
                return Model.OrdenDate;
            }

            set {
                Model.OrdenDate = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<OrdenesDetalle> OrdenesDetalles {
            get {
                return Model.OrdenesDetalle;
            }

            set {
                Model.OrdenesDetalle = value;
                RaisePropertyChanged();
            }
        }

        public string Contacto {
            get { return Model == null ? string.Empty : Model.Beneficiarios.Contacto; }
            set { Model.Beneficiarios.Contacto = value;
                RaisePropertyChanged();
            }
        }
        private bool visibilygrid = true;
        public bool VisibilyGrid {
            get { return visibilygrid; }
            set {
                visibilygrid = value;
                RaisePropertyChanged();
            }
        }

        
        public int ProductoID {
            get {
                return ordenesDetalle.ProductoID;
            }
            set {
                ordenesDetalle.ProductoID = value;
                RaisePropertyChanged();
            }
        }
        public decimal PrecioUnitario {
            get {
                return ordenesDetalle.PrecioUnitario;
            }
            set {
                ordenesDetalle.PrecioUnitario = value;
                RaisePropertyChanged();
            }
        }
        public short Cantidad {
            get {
                return ordenesDetalle.Cantidad;
            }
            set {
                ordenesDetalle.Cantidad = value;
                RaisePropertyChanged();
            }
        }
        private string  nombreproducto = string.Empty;
        public string NombreProducto {
            get {
                return nombreproducto;
            }
            set {
                nombreproducto = value;
                RaisePropertyChanged();
            }
        }
        private bool vergrid;

        public bool VerGrid {
            get { return vergrid; }
            set { vergrid = value; }
        }

        private bool verdetail;

        public bool VerDetail {
            get { return verdetail; }
            set { verdetail = value; }
        }

        #endregion

        #region Comandos
        private bool FirstCommand_CanExecute() {
            return true;
        }
        private void FirstCommand_Executed() {
            InicializeModelWhenNull(ordenesRepository.GetFirstOrden());
            RisePropertyChangedAll();
        }

        private bool MoveNextCommand_CanExecute() {
            return true;
        }
        private void MoveNextCommand_Executed() {
            InicializeModelWhenNull(ordenesRepository.GetNextOrden(Model.OrdenID));
            RisePropertyChangedAll();
        }

        private bool MovePreviousCommand_CanExecute() {
            return true;
        }
        private void MovePreviousCommand_Executed() {
            InicializeModelWhenNull(ordenesRepository.GetPreviousOrden(Model.OrdenID));
            RisePropertyChangedAll();
        }


        private bool LastCommand_CanExecute() {
            return true;
        }
        private void LastCommand_Executed() {
            InicializeModelWhenNull(ordenesRepository.GetLastOrden());
            RisePropertyChangedAll();
        }

        private bool AddCommand_CanExecute() {
            return true;
        }
        private void AddCommand_Executed() {
            CanCancel = true;
            ActualOrderID = Model.OrdenID;
            InicializeModelWhenNull(null);
            RisePropertyChangedAll();
            ((RelayCommand)CancelCommand).Refresh();
        }

        private bool UpdateCommand_CanExecute() {
            return true;
        }
        private void UpdateCommand_Executed() {
            ordenesRepository.UpdateOrdenes(Model);
            InicializeModelWhenNull(ordenesRepository.GetFirstOrden());
            RisePropertyChangedAll();
        }

        private bool DeleteCommand_CanExecute() {
            return true;
        }
        private void DeleteCommand_Executed() {
            ordenesRepository.DeleteOrden(Model.OrdenID);
            InicializeModelWhenNull(ordenesRepository.GetFirstOrden());
            RisePropertyChangedAll();
        }

        private bool CancelCommand_CanExecute() {
            return CanCancel;
        }
        private void CancelCommand_Executed() {
            CanCancel = false;
            InicializeModelWhenNull(ordenesRepository.GetOrden(ActualOrderID));
            RisePropertyChangedAll();
        }

        private bool AddDetailCommand_CanExecute() {
            return true;
        }
        private void AddDetailCommand_Executed() {
            VerGrid = false;
            VerDetail = true;
            InicializeDetailModel();
            RisePropertyChangedAll();
        }

        private bool AddRowProductoCommand_CanExecute() {
            return true;
        }
        private void AddRowProductoCommand_Executed() {
            ShowList.Invoke();
            ordenesDetalle.Productos = listProductosViewModel.ProductoSeleccionado;
            ProductoID = ordenesDetalle.Productos.ProductoID;
            PrecioUnitario = ordenesDetalle.Productos.PrecioUnitario == null ? 0: (decimal)ordenesDetalle.Productos.PrecioUnitario;
            NombreProducto = ordenesDetalle.Productos.NombreProducto;
            RaisePropertyChanged(nameof(ordenesDetalle));
        }

        private void InicializeDetailModel() {
            ordenesDetalle = new OrdenesDetalle() {
                OrdenID = OrdenID
                , Cantidad = 1
                , PrecioUnitario = 1
                , ProductoID = 0
            };
        }
        #endregion

        #region Metodos Propios
        private void InicializeModelWhenNull(Ordenes orden) {
            if (orden == null) {
                Model = new Ordenes() {
                    OrdenID = 1
                    ,BeneficiarioID = beneficiariosRepository.GetFirstBeneficiario().BeneficiarioID
                    ,Beneficiarios = new Beneficiarios() { Contacto = "" }
                    ,FechaEntregada = DateTime.Today
                    ,FechaIngresada = DateTime.Today
                    ,OrdenDate = DateTime.Today
                    ,OrdenesDetalle = new ObservableCollection<OrdenesDetalle>()
                };
            } else {
                Model = orden;
            }
            InicializeDetailModel();
        }
        private void RisePropertyChangedAll() {
            RaisePropertyChanged(nameof(OrdenID));
            RaisePropertyChanged(nameof(BeneficiarioID));
            RaisePropertyChanged(nameof(FechaEntregada));
            RaisePropertyChanged(nameof(FechaIngresada));
            RaisePropertyChanged(nameof(OrdenDate));
            RaisePropertyChanged(nameof(OrdenesDetalles));
            RaisePropertyChanged(nameof(VerGrid));
            RaisePropertyChanged(nameof(VerDetail));
        }
        #endregion
    }
}

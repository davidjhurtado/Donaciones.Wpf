using System;
using System.Windows.Input;

namespace Donaciones.WPF {
    public class ProductosViewModel :BaseViewModelComputed {

        #region Variables
        private Productos Model;

        public IProductosRepository ProductosRepository { get; }
        public ICommand FirstCommand { get; set; }
        public ICommand MoveNextCommand { get; set; }
        public ICommand MovePreviousCommand { get; set; }
        public ICommand LastCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        private int ActualProductID;
        private bool CanCancel;
        #endregion

        #region Constructor
        public ProductosViewModel(IProductosRepository productosRepository) {
            ProductosRepository = productosRepository;
            LoadFirstProduct();
            InizializedCommands();
        } 
        

        private void InizializedCommands() {
            FirstCommand = new RelayCommand(FirstCommand_Executed,FirstCommand_CanExecute);
            MoveNextCommand = new RelayCommand(MoveNextCommand_Executed, MoveNextCommand_CanExecute);
            MovePreviousCommand = new RelayCommand(MovePreviousCommand_Executed, MovePreviousCommand_CanExecute);
            LastCommand = new RelayCommand(LastCommand_Executed, LastCommand_CanExecute);
            AddCommand = new RelayCommand(AddCommand_Executed, AddCommand_CanExecute);
            UpdateCommand = new RelayCommand(UpdateCommand_Executed, UpdateCommand_CanExecute);
            DeleteCommand = new RelayCommand(DeleteCommand_Executed, DeleteCommand_CanExecute);
            CancelCommand = new RelayCommand(CancelCommand_Executed, CancelCommand_CanExecute);
        }

        public void LoadFirstProduct() {
            Model = ProductosRepository.GetFirstProducto();
            if (Model == null) {
                Model = new Productos() {
                    ProductoID = 0
                    ,NombreProducto = ""
                    ,CantidadPorUnidad = 0
                    ,Descontinuado = false
                    ,PrecioUnitario = 0
                    ,OrdenesDetalle = null
                };
            }
        }
        #endregion

        #region Propiedades
        public int ProductoID {
            get {
                return Model.ProductoID;
            }
            set {
                Model.ProductoID = value;
                RaisePropertyChanged();
            }
        }


        public string NombreProducto {
            get {
                return Model.NombreProducto;
            }
            set {
                Model.NombreProducto = value;
                RaisePropertyChanged();
            }
        }
        public Nullable<decimal> CantidadPorUnidad {
            get {
                return Model.CantidadPorUnidad;
            }
            set {
                Model.CantidadPorUnidad = value;
                RaisePropertyChanged();
            }
        }
        public Nullable<decimal> PrecioUnitario {
            get {
                return Model.PrecioUnitario;
            }
            set {
                Model.PrecioUnitario = value;
                RaisePropertyChanged();
            }
        }
        public bool Descontinuado {
            get {
                return Model.Descontinuado;
            }
            set {
                Model.Descontinuado = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Comandos
        private bool FirstCommand_CanExecute() {
            return true;
        }
        private void FirstCommand_Executed() {
            Model = ProductosRepository.GetFirstProducto();
            InicializeModelWhenNull(Model);
            RisePropertyChangedAll();
        }

        private bool MoveNextCommand_CanExecute() {
            return true;
        }
        private void MoveNextCommand_Executed() {
            Productos ProductosNext = ProductosRepository.GetNextProducto(Model.ProductoID);
            if (ProductosNext != null) {
                Model = ProductosNext;
            }
            InicializeModelWhenNull(Model);
            RisePropertyChangedAll();
        }

        private bool MovePreviousCommand_CanExecute() {
            return true;
        }
        private void MovePreviousCommand_Executed() {
            Productos ProductosPrevious = ProductosRepository.GetPreviousProducto(Model.ProductoID);
            if (ProductosPrevious != null) {
                Model = ProductosPrevious;
            }
            InicializeModelWhenNull(Model);
            RisePropertyChangedAll();
        }


        private bool LastCommand_CanExecute() {
            return true;
        }
        private void LastCommand_Executed() {
            Model = ProductosRepository.GetLastProducto();
            InicializeModelWhenNull(Model);
            RisePropertyChangedAll();
        }

        private bool AddCommand_CanExecute() {
            return true;
        }
        private void AddCommand_Executed() {
            CanCancel = true;
            ActualProductID = Model.ProductoID;
            InicializeModelWhenNull(null);
            Model.ProductoID = ProductosRepository.NextProductoConsecutivo();
            RisePropertyChangedAll();
            ((RelayCommand)CancelCommand).Refresh();
        }

        private bool UpdateCommand_CanExecute() {
            return true;
        }
        private void UpdateCommand_Executed() {
            ProductosRepository.UpdateProducto(Model);
            Model = ProductosRepository.GetFirstProducto();
            InicializeModelWhenNull(Model);
            RisePropertyChangedAll();
        }

        private bool DeleteCommand_CanExecute() {
            return true;
        }
        private void DeleteCommand_Executed() {
            ProductosRepository.DeleteProducto(Model.ProductoID);
            Model = ProductosRepository.GetFirstProducto();
            InicializeModelWhenNull(Model);
            RisePropertyChangedAll();
        }

        private bool CancelCommand_CanExecute() {
            return CanCancel;
        }
        private void CancelCommand_Executed() {
            Model = ProductosRepository.GetProducto(ActualProductID);
            CanCancel = false;
            InicializeModelWhenNull(Model);
            RisePropertyChangedAll();
        }
        #endregion

        #region Metodos Propios
        private void InicializeModelWhenNull(Productos producto) {
            if (producto == null) {
                Model = new Productos() {
                    ProductoID = 0
                   ,NombreProducto = ""
                   ,CantidadPorUnidad = 0
                   ,Descontinuado = false
                   ,PrecioUnitario = 0
                   ,OrdenesDetalle = null
                };
            }
        }
        private void RisePropertyChangedAll() {
            RaisePropertyChanged(nameof(ProductoID));
            RaisePropertyChanged(nameof(NombreProducto));
            RaisePropertyChanged(nameof(CantidadPorUnidad));
            RaisePropertyChanged(nameof(Descontinuado));
            RaisePropertyChanged(nameof(PrecioUnitario));
        } 
        #endregion
    }
}

using System.Windows.Input;

namespace Donaciones.WPF {
    public class BeneficiariosViewModel :BaseViewModelComputed {
        #region Variables
        private readonly IBeneficiariosRepository beneficiariosRepository;
        private Beneficiarios Model;
        private string ActualBeneficiarioID;
        private bool CanCancel;
        #endregion

        #region Constructor
        public BeneficiariosViewModel(IBeneficiariosRepository beneficiariosRepository) {
            this.beneficiariosRepository = beneficiariosRepository;
        }
        #endregion

        #region Propiedades
        #region Propiedades de Comandos
        public ICommand FirstCommand { get; set; }
        public ICommand MoveNextCommand { get; set; }
        public ICommand MovePreviousCommand { get; set; }
        public ICommand LastCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        #endregion
        public string BeneficiarioID {
            get {
                return Model.BeneficiarioID;
            }
            set {
                Model.BeneficiarioID = value;
                RaisePropertyChanged();
            }
        }
        public string Iglesia {
            get {
                return Model.Iglesia;
            }
            set {
                Model.Iglesia = value;
                RaisePropertyChanged();
            }
        }
        public string Contacto {
            get {
                return Model.Contacto;
            }
            set {
                Model.Contacto = value;
                RaisePropertyChanged();
            }
        }
        public string Direccion {
            get {
                return Model.Direccion;
            }
            set {
                Model.Direccion = value;
                RaisePropertyChanged();
            }
        }
        public string City {
            get {
                return Model.City;
            }
            set {
                Model.City = value;
                RaisePropertyChanged();
            }
        }
        public string Region {
            get {
                return Model.Region;
            }
            set {
                Model.Region = value;
                RaisePropertyChanged();
            }
        }
        public string CodigoPostal {
            get {
                return Model.CodigoPostal;
            }
            set {
                Model.CodigoPostal = value;
                RaisePropertyChanged();
            }
        }
        public string Pais {
            get {
                return Model.Pais;
            }
            set {
                Model.Pais = value;
                RaisePropertyChanged();
            }
        }
        public string Telefono {
            get {
                return Model.Telefono;
            }
            set {
                Model.Telefono = value;
                RaisePropertyChanged();
            }
        }
        public string Fax {
            get {
                return Model.Fax;
            }
            set {
                Model.Fax = value;
                RaisePropertyChanged();
            }
        }
        #endregion
    }
}
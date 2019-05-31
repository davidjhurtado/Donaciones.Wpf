using System.Windows.Input;

namespace Donaciones.WPF {
    public interface IBeneficiariosViewModel {
    }

    public class BeneficiariosViewModel :BaseViewModelComputed, IBeneficiariosViewModel {
        #region Variables
        private readonly IBeneficiariosRepository beneficiariosRepository;
        private Beneficiarios Model;
        private string ActualBeneficiarioID;
        private bool CanCancel;
        #endregion

        #region Constructor
        public BeneficiariosViewModel(IBeneficiariosRepository beneficiariosRepository) {
            this.beneficiariosRepository = beneficiariosRepository;
            LoadFirstBeneficiario();
            InizializedCommands();
        }
        public void LoadFirstBeneficiario() {
            Model = beneficiariosRepository.GetFirstBeneficiario();
            InicializeModelWhenNull(Model);
            RisePropertyChangedAll();
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

        #region Comandos
        private bool FirstCommand_CanExecute() {
            return true;
        }
        private void FirstCommand_Executed() {
            Model = beneficiariosRepository.GetFirstBeneficiario();
            InicializeModelWhenNull(Model);
            RisePropertyChangedAll();
        }

        private bool MoveNextCommand_CanExecute() {
            return true;
        }
        private void MoveNextCommand_Executed() {
            Beneficiarios BeneficiariosNext = beneficiariosRepository.GetNextBeneficiario(Model.BeneficiarioID);
            if (BeneficiariosNext != null) {
                Model = BeneficiariosNext;
            }
            InicializeModelWhenNull(Model);
            RisePropertyChangedAll();
        }

        private bool MovePreviousCommand_CanExecute() {
            return true;
        }
        private void MovePreviousCommand_Executed() {
            Beneficiarios BeneficiariosPrevious = beneficiariosRepository.GetPreviousBeneficiario(Model.BeneficiarioID);
            if (BeneficiariosPrevious != null) {
                Model = BeneficiariosPrevious;
            }
            InicializeModelWhenNull(Model);
            RisePropertyChangedAll();
        }


        private bool LastCommand_CanExecute() {
            return true;
        }
        private void LastCommand_Executed() {
            Model = beneficiariosRepository.GetLastBeneficiario();
            InicializeModelWhenNull(Model);
            RisePropertyChangedAll();
        }

        private bool AddCommand_CanExecute() {
            return true;
        }
        private void AddCommand_Executed() {
            CanCancel = true;
            ActualBeneficiarioID = Model.BeneficiarioID;
            InicializeModelWhenNull(null);
            //Model.BeneficiarioID = beneficiariosRepository.NextBeneficiarioConsecutivo();
            RisePropertyChangedAll();
            ((RelayCommand)CancelCommand).Refresh();
        }

        private bool UpdateCommand_CanExecute() {
            return true;
        }
        private void UpdateCommand_Executed() {
            beneficiariosRepository.UpdateBeneficiario(Model);
            Model = beneficiariosRepository.GetFirstBeneficiario();
            InicializeModelWhenNull(Model);
            RisePropertyChangedAll();
        }

        private bool DeleteCommand_CanExecute() {
            return true;
        }
        private void DeleteCommand_Executed() {
            beneficiariosRepository.DeleteBeneficiario(Model.BeneficiarioID);
            Model = beneficiariosRepository.GetFirstBeneficiario();
            InicializeModelWhenNull(Model);
            RisePropertyChangedAll();
        }

        private bool CancelCommand_CanExecute() {
            return CanCancel;
        }
        private void CancelCommand_Executed() {
            Model = beneficiariosRepository.GetBeneficiario(ActualBeneficiarioID);
            CanCancel = false;
            InicializeModelWhenNull(Model);
            RisePropertyChangedAll();
        }
        #endregion
        #region Metodos Propios
        private void InicializeModelWhenNull(Beneficiarios beneficiarios) {
            if (beneficiarios == null) {
                Model = new Beneficiarios() {
                     BeneficiarioID = string.Empty
                   , Contacto = string.Empty
                   , City = string.Empty
                   , CodigoPostal = string.Empty
                   , Direccion = string.Empty
                   , Fax = string.Empty
                   , Iglesia = string.Empty
                   , Ordenes = null
                   , Pais = string.Empty
                   , Region = string.Empty
                   , Telefono = string.Empty
                };
            }
        }
        private void RisePropertyChangedAll() {
            RaisePropertyChanged(nameof(BeneficiarioID));
            RaisePropertyChanged(nameof(Contacto));
            RaisePropertyChanged(nameof(City));
            RaisePropertyChanged(nameof(CodigoPostal));
            RaisePropertyChanged(nameof(Direccion));
            RaisePropertyChanged(nameof(Fax));
            RaisePropertyChanged(nameof(Iglesia));
            RaisePropertyChanged(nameof(Pais));
            RaisePropertyChanged(nameof(Region));
            RaisePropertyChanged(nameof(Telefono));
        }
        #endregion
    }
}
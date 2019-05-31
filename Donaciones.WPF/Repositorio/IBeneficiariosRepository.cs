using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donaciones.WPF {
    public interface IBeneficiariosRepository {
        Beneficiarios GetBeneficiario(string beneficiarioID);
        Beneficiarios GetFirstBeneficiario();
        Beneficiarios GetNextBeneficiario(string beneficiarioID);
        Beneficiarios GetPreviousBeneficiario(string beneficiarioID);
        IEnumerable<Beneficiarios> GetBeneficiarios();
        Beneficiarios GetLastBeneficiario();
        void UpdateBeneficiario(Beneficiarios beneficiario);
        bool DeleteBeneficiario(string beneficiarioID);
    }
}

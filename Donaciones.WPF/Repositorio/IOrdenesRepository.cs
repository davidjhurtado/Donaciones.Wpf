using System.Collections.Generic;

namespace Donaciones.WPF {
    public interface IOrdenesRepository {
        Ordenes GetOrden(int ordenID);
        Ordenes GetFirstOrden();
        Ordenes GetNextOrden(int ordenID);
        Ordenes GetPreviousOrden(int ordenID);
        IEnumerable<Ordenes> GetOrdenes();
        Ordenes GetLastOrden();
        void UpdateOrdenes(Ordenes ordenes);
        bool DeleteBeneficiario(int ordenID);
    }
}

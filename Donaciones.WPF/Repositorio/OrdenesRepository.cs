using System.Collections.Generic;
using System.Linq;

namespace Donaciones.WPF {
    public class OrdenesRepository :IOrdenesRepository {
        private readonly DonacionesDBEntities context;

        public OrdenesRepository(DonacionesDBEntities context) {
            this.context = context;
        }

        public bool DeleteBeneficiario(int ordenID) {
            Ordenes vOrden = context.Ordenes.Find(ordenID);
            context.Ordenes.Remove(vOrden);
            return context.SaveChanges() > 0;
        }

        public IEnumerable<Ordenes> GetOrdenes() {
            return context.Ordenes.ToList();
        }

        public Ordenes GetFirstOrden() {
            return context.Ordenes.First();
        }

        public Ordenes GetLastOrden() {
            var vListadeOrdenes = from orden in context.Ordenes.ToList()
                                      orderby orden.OrdenID descending
                                      select new { orden.OrdenID };
            return !vListadeOrdenes.Any() ? null : context.Ordenes.Find((int)vListadeOrdenes.FirstOrDefault().OrdenID);
        }

        public Ordenes GetNextOrden(int ordenID) {
            List<Ordenes> vOrdenes = GetOrdenes().ToList();
            bool existeorden = false;
            int nextOrdenID = 0;
            foreach (Ordenes vOrden in vOrdenes) {
                if (!existeorden) {
                    if (vOrden.OrdenID == ordenID) {
                        existeorden = true;
                    }
                } else {
                    nextOrdenID = vOrden.OrdenID;
                    break;
                }
            }
            return context.Ordenes.Find(nextOrdenID);
        }

        public Ordenes GetOrden(int ordenID) {
            return  context.Ordenes.Find(ordenID);
        }

        public Ordenes GetPreviousOrden(int ordenID) {
            List<Ordenes> vOrdenes = GetOrdenes().ToList();
            int previousOrdenID = 0;
            foreach (Ordenes vOrden in vOrdenes) {
                if (vOrden.OrdenID == ordenID) {
                    break;
                } else {
                    previousOrdenID = vOrden.OrdenID;
                }
            }
            return context.Ordenes.Find(previousOrdenID);
        }

        public void UpdateOrdenes(Ordenes ordenes) {
            Ordenes vOrdenes = context.Ordenes.Find(ordenes.OrdenID);
            if (vOrdenes == null) {
                context.Ordenes.Add(ordenes);
            } else {
                context.Entry(ordenes).State = System.Data.Entity.EntityState.Modified;
            }
            context.SaveChanges();
        }
    }
}

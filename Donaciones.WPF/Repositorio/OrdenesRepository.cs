using System.Collections.Generic;
using System.Linq;

namespace Donaciones.WPF {
    public class OrdenesRepository :IOrdenesRepository {
        private readonly DonacionesDBEntities context;

        public OrdenesRepository(DonacionesDBEntities context) {
            this.context = context;
        }

        public bool DeleteOrden(int ordenID) {
            Ordenes vOrden = context.Ordenes.Find(ordenID);
            context.Ordenes.Remove(vOrden);
            return context.SaveChanges() > 0;
        }

        public IEnumerable<Ordenes> GetOrdenes() {
            return context.Ordenes.Include(nameof(Beneficiarios)).ToList();
        }

        public Ordenes GetFirstOrden() {
            return GetOrden();
        }

        public Ordenes GetLastOrden() {
            var vListadeOrdenes = from orden in context.Ordenes.ToList()
                                      orderby orden.OrdenID descending
                                      select new { orden.OrdenID };
            return !vListadeOrdenes.Any() ? null : GetOrden((int)vListadeOrdenes.FirstOrDefault().OrdenID);
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
            return GetOrden(nextOrdenID);
        }

        public Ordenes GetOrden(int ordenID=0) {
            Ordenes vResult;
            if (ordenID == 0) {
                vResult = context.Ordenes.Include("Beneficiarios").FirstOrDefault();
            } else {
                vResult = context.Ordenes.Include(nameof(Beneficiarios)).FirstOrDefault(t => t.OrdenID == ordenID);
            }
            return  vResult;
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
            return GetOrden(previousOrdenID);
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

        public int GetNextOrderID() {
            int vOrdenes = context.Ordenes.Max(t => t.OrdenID);
            return vOrdenes++;
        }

    }
}

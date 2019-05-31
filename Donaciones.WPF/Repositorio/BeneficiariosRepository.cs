using System.Collections.Generic;
using System.Linq;

namespace Donaciones.WPF {
    public class BeneficiariosRepository :IBeneficiariosRepository {
        private readonly DonacionesDBEntities context;

        public BeneficiariosRepository(DonacionesDBEntities context) {
            this.context = context;
        }
               
        public bool DeleteBeneficiario(string beneficiarioID) {
            Beneficiarios benficiariobuscado = context.Beneficiarios.Find(beneficiarioID);
            context.Beneficiarios.Remove(benficiariobuscado);
            return context.SaveChanges() > 0;
        }

        public Beneficiarios GetBeneficiario(string beneficiarioID) {
            return context.Beneficiarios.Find(beneficiarioID);
        }

        public IEnumerable<Beneficiarios> GetBeneficiarios() {
            return context.Beneficiarios.ToList();
        }

        public Beneficiarios GetFirstBeneficiario() {
            return context.Beneficiarios.First();
        }

        public Beneficiarios GetLastBeneficiario() {
            var listadebenficiarios = from benficiario in context.Beneficiarios.ToList()
                                      orderby benficiario.BeneficiarioID descending
                                      select new { benficiario.BeneficiarioID};
            return !listadebenficiarios.Any() ? null : context.Beneficiarios.Find((string)listadebenficiarios.FirstOrDefault().BeneficiarioID);
        }

        public Beneficiarios GetNextBeneficiario(string beneficiarioID) {
            List<Beneficiarios> beneficiarios = GetBeneficiarios().ToList();
            bool existebeneficiario = false;
            string nextBeneficiarioID = string.Empty;
            foreach (Beneficiarios beneficia in beneficiarios) {
                if (!existebeneficiario) {
                    if (beneficia.BeneficiarioID == beneficiarioID) {
                        existebeneficiario = true;
                    }
                } else {
                    nextBeneficiarioID = beneficia.BeneficiarioID;
                    break;
                }
            }
            return context.Beneficiarios.Find(nextBeneficiarioID);
        }

        public Beneficiarios GetPreviousBeneficiario(string beneficiarioID) {
            List<Beneficiarios> beneficiarios = GetBeneficiarios().ToList();
            string previousBeneficiarioID = string.Empty;
            foreach (Beneficiarios beneficia in beneficiarios) {
                if (beneficia.BeneficiarioID == beneficiarioID) {
                    break;
                } else {
                    previousBeneficiarioID = beneficia.BeneficiarioID;
                }
            }
            return context.Beneficiarios.Find(previousBeneficiarioID);
        }

        public void UpdateBeneficiario(Beneficiarios Beneficiario) {
            Beneficiarios beneficiarios = context.Beneficiarios.Find(Beneficiario.BeneficiarioID);
            if (beneficiarios == null) {
                context.Beneficiarios.Add(Beneficiario);
            } else {
                context.Entry(Beneficiario).State = System.Data.Entity.EntityState.Modified;
            }
            context.SaveChanges();
        }
    }
}

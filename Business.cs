// Business.cs
using DataLayer;
using DataLayer.Model;
namespace BusinessLayer
{
    public class Business : IBusiness
    {
        private readonly IProizvodRepository repo;
        public Business(IProizvodRepository repo)
        {
            this.repo = repo;
        }

        public List<Proizvod> GetAllProizvodi()
        {
            return repo.GetAllProizvodi();
        }

        // Validacija + insert
        public string InsertProizvod(Proizvod p)
        {
            if (string.IsNullOrEmpty(p.Naziv)) return "Naziv je obavezan!";
            if (string.IsNullOrEmpty(p.Tip))   return "Tip je obavezan!";
            if (p.CenaRSD <= 0)                return "Cena mora biti > 0!";

            return repo.InsertProizvod(p) ? "Uspesno dodato!" : "Greska!";
        }

        // Azurira sve Hleb proizvode — povecava cenu za 10%
        public bool UpdateHlebCena()
        {
            var svi = repo.GetAllProizvodi();
            var hlebovi = svi.FindAll(p => p.Tip == "Hleb");
            foreach (var h in hlebovi)
            {
                h.CenaRSD = h.CenaRSD * 1.10m;
                repo.UpdateProizvod(h);
            }
            return true;
        }

        // Cena > 200 ILI tezina > 300
        public List<Proizvod> GetSkupiIliTeski()
        {
            return repo.GetAllProizvodi()
                .FindAll(p => p.CenaRSD > 200 || p.TezinaGrama > 300);
        }
    }
}

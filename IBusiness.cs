// IBusiness.cs
using DataLayer.Model;
namespace BusinessLayer
{
    public interface IBusiness
    {
        List<Proizvod> GetAllProizvodi();
        string InsertProizvod(Proizvod p);
        bool UpdateHlebCena(); // povecava hleb za 10%
        List<Proizvod> GetSkupiIliTeski(); // cena>200 ili tezina>300
    }
}

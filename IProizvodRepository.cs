// IProizvodRepository.cs
using DataLayer.Model;
namespace DataLayer
{
    public interface IProizvodRepository
    {
        List<Proizvod> GetAllProizvodi();
        bool InsertProizvod(Proizvod p);
        bool UpdateProizvod(Proizvod p);
    }
}

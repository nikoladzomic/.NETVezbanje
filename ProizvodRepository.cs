// ProizvodRepository.cs
using DataLayer.Model;
using System.Data.SqlClient;
namespace DataLayer
{
    public class ProizvodRepository : IProizvodRepository
    {
        private const string ConnectionString = 
            "Data Source=(localdb)\\ProjectModels;Initial Catalog=PekaraDB;";

        public List<Proizvod> GetAllProizvodi()
        {
            List<Proizvod> list = new List<Proizvod>();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Proizvodi";
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Proizvod p = new Proizvod();
                    p.Id = reader.GetInt32(0);
                    p.Naziv = reader.GetString(1);
                    p.Tip = reader.GetString(2);
                    p.CenaRSD = reader.GetDecimal(3);
                    p.TezinaGrama = reader.IsDBNull(4) ? null : reader.GetDecimal(4);
                    list.Add(p);
                }
            }
            return list;
        }

        public bool InsertProizvod(Proizvod p)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Proizvodi(Naziv, Tip, CenaRSD, TezinaGrama) VALUES(@Naziv, @Tip, @CenaRSD, @TezinaGrama)";
                cmd.Parameters.AddWithValue("@Naziv", p.Naziv);
                cmd.Parameters.AddWithValue("@Tip", p.Tip);
                cmd.Parameters.AddWithValue("@CenaRSD", p.CenaRSD);
                cmd.Parameters.AddWithValue("@TezinaGrama", (object?)p.TezinaGrama ?? DBNull.Value);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateProizvod(Proizvod p)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Proizvodi SET Naziv=@Naziv, Tip=@Tip, CenaRSD=@CenaRSD, TezinaGrama=@TezinaGrama WHERE Id=@Id";
                cmd.Parameters.AddWithValue("@Naziv", p.Naziv);
                cmd.Parameters.AddWithValue("@Tip", p.Tip);
                cmd.Parameters.AddWithValue("@CenaRSD", p.CenaRSD);
                cmd.Parameters.AddWithValue("@TezinaGrama", (object?)p.TezinaGrama ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Id", p.Id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}

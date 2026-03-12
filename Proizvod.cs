// Model/Proizvod.cs
namespace DataLayer.Model
builder.Services.AddScoped<IProizvodRepository, ProizvodRepository>();
builder.Services.AddScoped<IBusiness, Business>();
{
    public class Proizvod
    {
        public int Id { get; set; }
        public string? Naziv { get; set; }
        public string? Tip { get; set; }
        public decimal CenaRSD { get; set; }
        public decimal? TezinaGrama { get; set; }
    }
}


using BibliotekaKlasModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BibliotekaKlasDAL
{
    public class WebshopContext : DbContext
    {        
        public DbSet<User>  User { get; set; }
        public DbSet<BasketPostion> BasketPostion { get; set; }

        public DbSet<Product> Produkty { get; set; }
        public DbSet<Order> Zamowienia { get; set; }
        public DbSet<OrderPosition> PozycjeZamowieni { get; set; }  
        //Connection String
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Sklep;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
                .EnableSensitiveDataLogging() // To pozwala na logowanie danych
                .LogTo(Console.WriteLine, LogLevel.Information); // To pozwala na logowanie zapytań SQL
                                                             //  optionsBuilder.UseSqlServer("Server=localhost; Database=SklepInternetowyKK; TrustServerCertificate=True;");

        }
  

    }
}
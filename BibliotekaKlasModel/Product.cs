using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BibliotekaKlasModel
{
    public class Product : IEntityTypeConfiguration<Product>
    {
        public Product(string name, decimal price, string image, bool active)
        {
            Name = name;
            Price = price;
            Image = image;
        }

        public Product()
        {

        }
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        [MaxLength(50)]
        public string  Image { get; set; }
        public bool IsActive { get; set; }
        public ICollection<BasketPostion> Pozycje { get; set; }
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
            .HasMany(x => x.Pozycje)
            .WithOne(x => x.Product)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
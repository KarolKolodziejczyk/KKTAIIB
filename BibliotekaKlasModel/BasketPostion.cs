using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaKlasModel
{
    public class BasketPostion : IEntityTypeConfiguration<BasketPostion>
    {

        [Key]
        public int Id { get; set; }
        public int ProductID { get; set; }
        [ForeignKey(nameof(ProductID))]
        public Product Product { get; set; }
        public int UserID { get; set; }
        [ForeignKey(nameof(UserID))]
        public User User { get; set; }
        public int Amount { get; set; }
        public void Configure(EntityTypeBuilder<BasketPostion> builder)
        {
            builder
           .HasOne(x => x.Product)
           .WithMany(x => x.Pozycje)
           .OnDelete(DeleteBehavior.Restrict);
            builder
           .HasOne(x => x.User)
           .WithMany(x => x.Pozycje)
           .OnDelete(DeleteBehavior.Restrict);

        }
    }
}

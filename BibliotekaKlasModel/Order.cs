using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaKlasModel
{
    public class Order : IEntityTypeConfiguration<Order>
    {
        [Key]
        public int Id { get; set; }
       
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public DateTime DateTime { get; set; }

        [Required]
        public IEnumerable<OrderPosition> Pozycje { get; set; }

        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
            .HasMany(x => x.Pozycje)
            .WithOne(x => x.Order)
            .OnDelete(DeleteBehavior.Cascade);
            
            builder
           .HasOne(x => x.User)
           .WithMany(x => x.Zamowienia)
           .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

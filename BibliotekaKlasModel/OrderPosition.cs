using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaKlasModel
{
    public class OrderPosition : IEntityTypeConfiguration<OrderPosition>
    {
        public int Id { get; set; }
        public int OrderID { get; set; }
        [ForeignKey(nameof(OrderID))]
        public Order Order { get; set; }
        public int Amout { get; set; }
        public decimal Price { get; set; }

        public void Configure(EntityTypeBuilder<OrderPosition> builder)
        {
            builder
            .HasOne(x => x.Order)
            .WithMany(x => x.Pozycje)
            .OnDelete(DeleteBehavior.Restrict);

        }
    }
}


﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BibliotekaKlasModel
{
    public class Product : IEntityTypeConfiguration<Product>
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        [MaxLength(50)]
        public string  Image { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<BasketPostion> Pozycje { get; set; }
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
            .HasMany(x => x.Pozycje)
            .WithOne(x => x.Product)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
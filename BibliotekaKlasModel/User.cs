using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaKlasModel
{
    public class User : IEntityTypeConfiguration<User>
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Login { get; set; }
        [MaxLength(50)]
        public string Password { get; set; }
        public Type Type { get; set; }  
        public bool IsActive { get; set; }

        public IEnumerable<Order> Zamowienia { get; set; }
        public IEnumerable<BasketPostion> Pozycje { get; set; }

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
            .HasMany(x => x.Zamowienia)
            .WithOne(x => x.User)
            .OnDelete(DeleteBehavior.Cascade);
            
            builder
           .HasMany(x => x.Pozycje)
           .WithOne(x => x.User)
           .OnDelete(DeleteBehavior.Cascade);
        }
    }
    public enum Type { Admin, Casual }

}
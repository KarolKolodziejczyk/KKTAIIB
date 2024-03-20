using BibliotekaKlasModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class OrderResponseDTO
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public UserBLL User { get; set; }
        public DateTime DateTime { get; set; }

        [Required]
        public IEnumerable<OrderPositionBLL> Pozycje { get; set; }

    }
}

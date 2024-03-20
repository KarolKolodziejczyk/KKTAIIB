using BibliotekaKlasModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BasketPositionResponseDTO
    {
        public int Id { get; set; }
        public int ProductID { get; set; }
        [ForeignKey(nameof(ProductID))]
        public ProductBLL Product { get; set; }
        public int UserID { get; set; }
        [ForeignKey(nameof(UserID))]
        public UserBLL User { get; set; }
        public int Amount { get; set; }
    }
}

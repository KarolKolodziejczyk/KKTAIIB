using BibliotekaKlasModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    internal class BasketPositionRequestDTO
    {
        public int ProductID { get; set; }
        public ProductBLL Product { get; set; }
        public int UserID { get; set; }
        public UserBLL User { get; set; }
        public int Amount { get; set; }
    }
}

using BibliotekaKlasModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    internal class OrderPositionRequestDTO
    {
        public int OrderID { get; set; }
        public OrderBLL Order { get; set; }

        public int ProductID { get; set; }
        public ProductBLL Product { get; set; }

        public int Amout { get; set; }
        public decimal Price { get; set; }

    }
}

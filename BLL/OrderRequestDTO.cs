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
    public class OrderRequestDTO
    {

        public int UserId { get; set; }
        public UserBLL User { get; set; }
        public DateTime DateTime { get; set; }
        public IEnumerable<OrderPositionBLL> Pozycje { get; set; }

    }
}

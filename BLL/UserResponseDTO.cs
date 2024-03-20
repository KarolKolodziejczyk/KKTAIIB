using BibliotekaKlasModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserRequestDTO
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public BibliotekaKlasModel.Type Type { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<OrderBLL> Zamowienia { get; set; }
        public IEnumerable<BasketPostionBLL> Pozycje { get; set; }

    }
}

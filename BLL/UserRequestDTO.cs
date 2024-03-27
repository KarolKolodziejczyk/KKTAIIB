using BibliotekaKlasModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserResponseDTO
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public BibliotekaKlasModel.Type Type { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<OrderResponseDTO> Zamowienia { get; set; }
        public IEnumerable<BasketPositionResponseDTO> Pozycje { get; set; }
    }
}

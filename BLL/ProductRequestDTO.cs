using BibliotekaKlasModel;

namespace BLL
{
    public class ProductRequestDTO
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<BasketPostionBLL> Pozycje { get; set; }


    }
}
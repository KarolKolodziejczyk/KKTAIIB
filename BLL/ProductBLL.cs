using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BLL
{
    public interface ProductBLL 
    {
        public IEnumerable<ProductResponseDTO> GetProducts();
        public IEnumerable<ProductResponseDTO> GetProductsPaged(int size, int count);
        public IEnumerable<ProductResponseDTO> GetProductsByName(string name);
        public IEnumerable<ProductResponseDTO> GetProductsByActive(bool IsActive);
        public IEnumerable<ProductResponseDTO> GetProductsSort( string nazwaKolumny, bool Ascending =true);
        public void AddProduct(string Name, decimal Price, string Image, bool Active = false);
        public void AddProduct(ProductRequestDTO a);

        public void UpdateProduct(int id, string Name, decimal Price, string Image, bool Active = false);
        public void UpdateProduct(ProductRequestDTO a);
        public void ActivateProduct(int id);
        public void DeleteProduct(int id);
        

    }
}
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BLL
{
    public interface ProductBLL 
    {
        public ICollection<ProductResponseDTO> GetProducts();
        public ICollection<ProductResponseDTO> GetProductsPaged(int size, int count);
        public ICollection<ProductResponseDTO> GetProductsByName(string name);
        public ICollection<ProductResponseDTO> GetProductsByActive(bool IsActive);
        public ICollection<ProductResponseDTO> GetProductsSort( string nazwaKolumny, bool Ascending =true);
        public void AddProduct(string Name, decimal Price, string Image, bool Active = false);
        public void AddProduct(ProductRequestDTO a);

        public void UpdateProduct(int id, string Name, decimal Price, string Image, bool Active = false);
        public void UpdateProduct(ProductRequestDTO a);
        public void ActivateProduct(int id);
        public void DeleteProduct(int id);
        

    }
}
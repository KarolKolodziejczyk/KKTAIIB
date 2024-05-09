using BibliotekaKlasDAL;
using BibliotekaKlasModel;
using BLL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotekaKlasModel;
using System.Linq.Expressions;
namespace BLL_EF
{
    internal class Product : ProductBLL
    {

        private readonly WebshopContext _dbContext;
        public Product(WebshopContext context)
        {
            _dbContext = context;
        }
        public void ActivateProduct(int id)
        {
            var prod = _dbContext.Produkty.FirstOrDefault(x => x.Id == id);
            prod.IsActive = true; 

        }

        public void AddProduct(string Name, decimal Price, string Image, bool Active = false)
        {
            _dbContext.Produkty.Add(new BibliotekaKlasModel.Product(Name, Price, Image, Active));
        }

        public void AddProduct(ProductRequestDTO a)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductResponseDTO> GetProducts()
        {
            IEnumerable<BibliotekaKlasModel.Product> lista = _dbContext.Produkty.ToList();
            List<ProductResponseDTO> lista2 = new List<ProductResponseDTO>();
            foreach (var element in lista)
            {
                ProductResponseDTO a = new ProductResponseDTO();
                a.Price = element.Price;
                //a.Pozycje = element.Pozycje;
                a.Image = element.Image;
                a.Name = element.Name;
                a.IsActive = element.IsActive;
                lista2.Add(a);
            }
            return lista2;
        }

        public IEnumerable<ProductResponseDTO> GetProductsByActive(bool IsActive)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductResponseDTO> GetProductsByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductResponseDTO> GetProductsPaged(int size, int count)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductResponseDTO> GetProductsSort(string nazwaKolumny, bool Ascending = true)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(int id, string Name, decimal Price, string Image, bool Active = false)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(ProductRequestDTO a)
        {
            throw new NotImplementedException();
        }
    }
}

using BibliotekaKlasDAL;
using BibliotekaKlasModel;
using BLL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL_EF
{
    public class ProductService : ProductBLL
    {
        private readonly WebshopContext _dbContext;

        public ProductService(WebshopContext context)
        {
            _dbContext = context;
        }

        public void ActivateProduct(int id)
        {
            var product = _dbContext.Produkty.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                product.IsActive = true;
                _dbContext.SaveChanges();
            }
        }

        public void AddProduct(string Name, decimal Price, string Image, bool Active = false)
        {
            var product = new BibliotekaKlasModel.Product
            {
                Name = Name,
                Price = Price,
                Image = Image,
                IsActive = Active
            };
            _dbContext.Produkty.Add(product);
            _dbContext.SaveChanges();
        }

        public void AddProduct(ProductRequestDTO a)
        {
            var product = new BibliotekaKlasModel.Product
            {
                Name = a.Name,
                Price = a.Price,
                Image = a.Image,
                IsActive = a.IsActive
            };
            _dbContext.Produkty.Add(product);
            _dbContext.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var product = _dbContext.Produkty.Find(id);
            if (product != null)
            {
                _dbContext.Produkty.Remove(product);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<ProductResponseDTO> GetProducts()
        {
            return _dbContext.Produkty.Select(product => new ProductResponseDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Image = product.Image,
                IsActive = product.IsActive
            }).ToList();
        }

        public IEnumerable<ProductResponseDTO> GetProductsByActive(bool isActive)
        {
            return _dbContext.Produkty
                .Where(p => p.IsActive == isActive)
                .Select(product => new ProductResponseDTO
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Image = product.Image,
                    IsActive = product.IsActive
                }).ToList();
        }

        public IEnumerable<ProductResponseDTO> GetProductsByName(string name)
        {
            return _dbContext.Produkty
                .Where(p => p.Name.Contains(name))
                .Select(product => new ProductResponseDTO
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Image = product.Image,
                    IsActive = product.IsActive
                }).ToList();
        }

        public IEnumerable<ProductResponseDTO> GetProductsPaged(int size, int count)
        {
            return _dbContext.Produkty
                .Skip((count - 1) * size)
                .Take(size)
                .Select(product => new ProductResponseDTO
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Image = product.Image,
                    IsActive = product.IsActive
                }).ToList();
        }

        public IEnumerable<ProductResponseDTO> GetProductsSort(string columnName, bool ascending = true)
        {
            IQueryable<BibliotekaKlasModel.Product> products = _dbContext.Produkty;

            switch (columnName)
            {
                case nameof(BibliotekaKlasModel.Product.Name):
                    products = ascending ? products.OrderBy(p => p.Name) : products.OrderByDescending(p => p.Name);
                    break;
                case nameof(BibliotekaKlasModel.Product.Price):
                    products = ascending ? products.OrderBy(p => p.Price) : products.OrderByDescending(p => p.Price);
                    break;
                default:
                    // Domyślne sortowanie
                    products = products.OrderBy(p => p.Id);
                    break;
            }

            return products.Select(product => new ProductResponseDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Image = product.Image,
                IsActive = product.IsActive
            }).ToList();
        }

        public void UpdateProduct(int id, string name, decimal price, string image, bool active = false)
        {
            var product = _dbContext.Produkty.Find(id);
            if (product != null)
            {
                product.Name = name;
                product.Price = price;
                product.Image = image;
                product.IsActive = active;
                _dbContext.SaveChanges();
            }
        }

        public void UpdateProduct(ProductRequestDTO a)
        {
            var product = _dbContext.Produkty.Find(a);
            if (product != null)
            {
                product.Name = a.Name;
                product.Price = a.Price;
                product.Image = a.Image;
                product.IsActive = a.IsActive;
                _dbContext.SaveChanges();
            }
        }
    }
}

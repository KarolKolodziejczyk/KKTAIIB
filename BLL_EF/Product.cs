using BibliotekaKlasDAL;
using BibliotekaKlasModel;
using BLL;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using BibliotekaKlasModel;
using Microsoft.AspNetCore.Mvc;

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

        public void AddProduct(string name, decimal price, string image, bool active = false)
        {
            var product = new Product
            {
                Name = name,
                Price = price,
                Image = image,
                IsActive = active
            };
            _dbContext.Produkty.Add(product);
            _dbContext.SaveChanges();
        }

        public void AddProduct(ProductRequestDTO productRequest)
        {
            var product = new Product
            {
                Name = productRequest.Name,
                Price = productRequest.Price,
                Image = productRequest.Image,
                IsActive = productRequest.IsActive
            };

            if (productRequest.Pozycje != null && productRequest.Pozycje.Any())
            {
                // Jeśli istnieją pozycje, przypisz je do produktu
                foreach (var pozycja in productRequest.Pozycje)
                {
                    product.Pozycje.Add(new BasketPostion
                    {
                        // Przypisz właściwości z DTO do pozycji koszyka
                        ProductID = pozycja.ProductID,
                        UserID = pozycja.UserID,
                        Amount = pozycja.Amount
                    });
                }
            }

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

        public ICollection<ProductResponseDTO> GetProducts()
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

        public ICollection<ProductResponseDTO> GetProductsByActive(bool isActive)
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

        public ICollection<ProductResponseDTO> GetProductsByName(string name)
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
        [HttpGet("paged")]
        public ICollection<ProductResponseDTO> GetProductsPaged(int size, int page)
        {
            return _dbContext.Produkty
                .Skip((page - 1) * size)
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

        public ICollection<ProductResponseDTO> GetProductsSort(string columnName, bool ascending = true)
        {
            IQueryable<Product> products = _dbContext.Produkty;

            switch (columnName)
            {
                case nameof(Product.Name):
                    products = ascending ? products.OrderBy(p => p.Name) : products.OrderByDescending(p => p.Name);
                    break;
                case nameof(Product.Price):
                    products = ascending ? products.OrderBy(p => p.Price) : products.OrderByDescending(p => p.Price);
                    break;
                default:
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

        public void UpdateProduct(ProductRequestDTO productRequest)
        {
            var product = _dbContext.Produkty.Find(productRequest);
            if (product != null)
            {
                product.Name = productRequest.Name;
                product.Price = productRequest.Price;
                product.Image = productRequest.Image;
                product.IsActive = productRequest.IsActive;
                _dbContext.SaveChanges();
            }
        }
    }
}

using BibliotekaKlasDAL;
using BibliotekaKlasModel;
using BLL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL_EF
{
    public class Basket : BasketPostionBLL
    {
        private readonly WebshopContext _dbContext;

        public Basket(WebshopContext context)
        {
            _dbContext = context;
        }

        public void AddToBasket(ProductResponseDTO product)
        {
            var basketPosition = new BasketPostion
            {
                ProductID = product.Id,
                // Ustaw inne właściwości BasketPosition
            };

            _dbContext.BasketPostion.Add(basketPosition);
            _dbContext.SaveChanges();
        }

        public void ChangeAmount(ProductResponseDTO product, int amount)
        {
            var basketPosition = _dbContext.BasketPostion.FirstOrDefault(bp => bp.ProductID == product.Id);
            if (basketPosition != null)
            {
                basketPosition.Amount = amount;
                _dbContext.SaveChanges();
            }
        }

        public void ChangeAmount(int id, int amount)
        {
            var basketPosition = _dbContext.BasketPostion.FirstOrDefault(bp => bp.ProductID == id);
            if (basketPosition != null)
            {
                basketPosition.Amount = amount;
                _dbContext.SaveChanges();
            }
        }

        public void DeleteFromBasket(ProductResponseDTO product)
        {
            var basketPosition = _dbContext.BasketPostion.FirstOrDefault(bp => bp.ProductID == product.Id);
            if (basketPosition != null)
            {
                _dbContext.BasketPostion.Remove(basketPosition);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteFromBasket(int id)
        {
            var basketPosition = _dbContext.BasketPostion.FirstOrDefault(bp => bp.ProductID == id);
            if (basketPosition != null)
            {
                _dbContext.BasketPostion.Remove(basketPosition);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<BasketPositionResponseDTO> GetBasket(UserResponseDTO user)
        {
            if (user.Pozycje == null)
            {
                return Enumerable.Empty<BasketPositionResponseDTO>();
            }

            return user.Pozycje.Select(p => new BasketPositionResponseDTO
            {
                // mapowanie właściwości z pozycji koszyka do BasketPositionResponseDTO
            }).ToList();
        }

        public OrderRequestDTO Order(UserResponseDTO user)
        {
            throw new NotImplementedException();
        }
    }
}

using BibliotekaKlasDAL;
using BibliotekaKlasModel;
using BLL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace BLL_EF
{
    public class Basket : BasketPostionBLL
    {

        private readonly WebshopContext _dbContext;
        public Basket(WebshopContext context)
        {
            _dbContext = context;
        }

        public void AddToBasket(ProductResponseDTO a)
        {

            //var a = new BasketPosition()
            //_dbContext.BasketPostion
            throw new NotImplementedException();

        }

        public void ChangeAmount(ProductResponseDTO a, int amount)
        {
            //var a = _dbContext.
            throw new NotImplementedException();
        }

        public void ChangeAmount(int id, int amount)
        {
            throw new NotImplementedException();
        }

        public void DeleteFromBasket(ProductResponseDTO a)
        {
            var u = _dbContext.BasketPostion.FirstOrDefault(x => x.ProductID == a.Id);
            _dbContext.BasketPostion.Remove(u);
        }

        public void DeleteFromBasket(int id)
        {
            var u = _dbContext.BasketPostion.FirstOrDefault(x => x.ProductID == id);
            _dbContext.BasketPostion.Remove(u);
        }

        public IEnumerable<BasketPositionResponseDTO> GetBasket(UserResponseDTO user)
        {
            if (user.Pozycje == null)
            {
                return Enumerable.Empty<BasketPositionResponseDTO>();
            }

            var u = user.Pozycje.ToList();
            return u.Select(p => new BasketPositionResponseDTO
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

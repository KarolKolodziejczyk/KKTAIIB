using BibliotekaKlasDAL;
using BibliotekaKlasModel;
using BLL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_EF
{
    internal class Order : OrderBLL
    {

        private readonly WebshopContext _dbContext;
        public Order(WebshopContext context)
        {
            _dbContext = context;
        }

        private List<OrderResponseDTO> Orders = new List<OrderResponseDTO>(); 
        public IEnumerable<OrderResponseDTO> GetAllOrders()
        {
              var allUsers = _dbContext.User.Include(u => u.Zamowienia)
                 .ThenInclude(o => o.Pozycje).ToList();
              List<BibliotekaKlasModel.Order> allOrders = allUsers.SelectMany(u => u.Zamowienia).ToList();


              return (IEnumerable < OrderResponseDTO > )allOrders;

        }

        public IEnumerable<OrderResponseDTO> GetOrderByUser(UserResponseDTO user)
        {

            var us = _dbContext.User.FirstOrDefault(x => x.Id == user.Id);
            List<BibliotekaKlasModel.Order> allOrders = us.Zamowienia.ToList();
            
            return (IEnumerable<OrderResponseDTO>)allOrders;
        }

        public IEnumerable<OrderPositionResponseDTO> GetPositions(int id)
        {
            var order = _dbContext.Zamowienia.FirstOrDefault(x => x.Id == id);
            List<BibliotekaKlasModel.OrderPosition> pozycje = order.Pozycje.ToList();

            return (IEnumerable<OrderPositionResponseDTO>)pozycje;

        }
    }
}

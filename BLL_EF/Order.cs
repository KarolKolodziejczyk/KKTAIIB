using BibliotekaKlasDAL;
using BibliotekaKlasModel;
using BLL;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BLL_EF
{
    public class OrderService : OrderBLL
    {
        private readonly WebshopContext _dbContext;

        public OrderService(WebshopContext context)
        {
            _dbContext = context;
        }

        public IEnumerable<OrderResponseDTO> GetAllOrders()
        {
            var allOrders = _dbContext.Zamowienia
                                       .Include(o => o.Pozycje)
                                       .ToList();

            var orderResponseDTOs = allOrders.Select(order => new OrderResponseDTO
            {
                Id = order.Id,
                UserId = order.UserId,
                // Map other properties here
            }).ToList();

            return orderResponseDTOs;
        }

        public IEnumerable<OrderResponseDTO> GetOrderByUser(UserResponseDTO user)
        {
            var userOrders = _dbContext.Zamowienia
                                       .Include(o => o.Pozycje)
                                       .Where(x => x.UserId == user.Id)
                                       .ToList();

            var orderResponseDTOs = userOrders.Select(order => new OrderResponseDTO
            {
                Id = order.Id,
                UserId = order.UserId,
                // Map other properties here
            }).ToList();

            return orderResponseDTOs;
        }

        public IEnumerable<OrderPositionResponseDTO> GetPositions(int id)
        {
            var order = _dbContext.Zamowienia
                                  .Include(o => o.Pozycje)
                                  .FirstOrDefault(x => x.Id == id);

            if (order == null)
            {
                return Enumerable.Empty<OrderPositionResponseDTO>();
            }

            var orderPositionResponseDTOs = order.Pozycje.Select(pozycja => new OrderPositionResponseDTO
            {
                Id = pozycja.Id,
                // Map other properties here
            }).ToList();

            return orderPositionResponseDTOs;
        }

        OrderResponseDTO OrderBLL.GetOrderById(int id)
        {
            var order = _dbContext.Zamowienia
                              .Include(o => o.Pozycje)
                              .FirstOrDefault(x => x.Id == id);

            if (order == null)
            {
                return null;
            }

            var orderResponseDTO = new OrderResponseDTO
            {
                Id = order.Id,
                UserId = order.UserId,
                // Map other properties here
            };

            return orderResponseDTO;
        }



        // Implement other methods from OrderBLL interface
        // AddProductToOrder, RemoveProductFromOrder, CalculateOrderTotal, etc.
    }
}

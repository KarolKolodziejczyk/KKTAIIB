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
                DateTime = order.DateTime,

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
                Id = order.Id,

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
            };

            return orderResponseDTO;
        }


        public void AddProductToOrder(int orderId, ProductResponseDTO product)
        {
            var order = _dbContext.Zamowienia
                                  .Include(o => o.Pozycje)
                                  .FirstOrDefault(x => x.Id == orderId);

            if (order == null)
            {
                return; 
            }

            var newOrderPosition = new OrderPosition
            {
                OrderID = order.Id,
            };

            order.Pozycje.Add(newOrderPosition);

            _dbContext.SaveChanges();
        }


        public void RemoveProductFromOrder(int orderId, int orderPositionId)
        {
            var order = _dbContext.Zamowienia
                                  .Include(o => o.Pozycje)
                                  .FirstOrDefault(x => x.Id == orderId);

            if (order == null)
            {
                return;
            }

            var orderPositionToRemove = order.Pozycje.FirstOrDefault(p => p.Id == orderPositionId);

            if (orderPositionToRemove == null)
            {
                return;
            }

            order.Pozycje.Remove(orderPositionToRemove);
            _dbContext.SaveChanges();
        }
        public decimal CalculateOrderTotal(int orderId)
        {
            var order = _dbContext.Zamowienia
                                  .Include(o => o.Pozycje)
                                  .FirstOrDefault(x => x.Id == orderId);

            if (order == null)
            {
                return (decimal)0.0;
            }

            decimal total = order.Pozycje.Sum(p => p.Price * p.Amout);

            return total;
        }
    }
}

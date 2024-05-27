using BibliotekaKlasDAL;
using BibliotekaKlasModel;
using BLL;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BLL_EF
{
    public class OrderS : OrderBLL
    {
        private readonly WebshopContext _dbContext;

        public OrderS(WebshopContext context)
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

        public OrderResponseDTO GetOrderById(int id)
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
                DateTime = order.DateTime,
                // Map other properties here
            };

            return orderResponseDTO;
        }

        public void AddOrder(OrderRequestDTO orderRequestDTO)
        {
            var order = new Order
            {
                UserId = orderRequestDTO.UserId,
                DateTime = orderRequestDTO.DateTime,
                // Map other properties here
            };

            if (orderRequestDTO.Pozycje != null && orderRequestDTO.Pozycje.Any())
            {
                foreach (var pozycja in orderRequestDTO.Pozycje)
                {
                    order.Pozycje.Add(new OrderPosition
                    {
                      
                        // Map other properties here
                    });
                }
            }

            _dbContext.Zamowienia.Add(order);
            _dbContext.SaveChanges();
        }

        public void UpdateOrder(int id, OrderRequestDTO orderRequestDTO)
        {
            var order = _dbContext.Zamowienia.Find(id);
            if (order != null)
            {
                order.UserId = orderRequestDTO.UserId;
                order.DateTime = orderRequestDTO.DateTime;
                // Update other properties here

                _dbContext.SaveChanges();
            }
        }

        public void DeleteOrder(int id)
        {
            var order = _dbContext.Zamowienia.Find(id);
            if (order != null)
            {
                _dbContext.Zamowienia.Remove(order);
                _dbContext.SaveChanges();
            }
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
                ProductID = product.Id,
                Amout = 1 // Adjust quantity as needed
                // Map other properties here
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
                return 0.0m;
            }

            decimal total = order.Pozycje.Sum(p => p.Price * p.Amout);
            return total;
        }
    }
}

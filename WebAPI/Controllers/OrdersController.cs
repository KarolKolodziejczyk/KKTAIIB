using BibliotekaKlasModel;
using BLL;
using BLL_EF;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderS _service;

        public OrdersController(OrderS service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        /// <summary>
        /// Pobiera wszystkie zamówienia.
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<OrderResponseDTO>> GetAllOrders()
        {
            var orders = _service.GetAllOrders();
            return Ok(orders);
        }

        /// <summary>
        /// Pobiera zamówienia dla określonego użytkownika.
        /// </summary>
        [HttpGet("user/{userId}")]
        public ActionResult<IEnumerable<OrderResponseDTO>> GetByUserId(int userId)
        {
            var user = new UserResponseDTO { Id = userId };
            var orders = _service.GetOrderByUser(user);
            if (orders == null || !orders.Any())
            {
                return NotFound();
            }
            return Ok(orders);
        }

        /// <summary>
        /// Pobiera pozycje zamówienia o określonym identyfikatorze zamówienia.
        /// </summary>
        [HttpGet("{id}/positions")]
        public ActionResult<IEnumerable<OrderPositionResponseDTO>> GetPositions(int id)
        {
            var positions = _service.GetPositions(id);
            if (positions == null || !positions.Any())
            {
                return NotFound();
            }
            return Ok(positions);
        }

        /// <summary>
        /// Pobiera zamówienie o określonym identyfikatorze.
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<OrderResponseDTO> GetOrderById(int id)
        {
            var order = _service.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        /// <summary>
        /// Dodaje nowe zamówienie.
        /// </summary>
        [HttpPost]
        public IActionResult PostOrder([FromBody] OrderRequestDTO orderRequestDTO)
        {
            _service.AddOrder(orderRequestDTO);
            return Ok();
        }

        /// <summary>
        /// Aktualizuje zamówienie.
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult PutOrder(int id, [FromBody] OrderRequestDTO orderRequestDTO)
        {
            _service.UpdateOrder(id, orderRequestDTO);
            return Ok();
        }

        /// <summary>
        /// Usuwa zamówienie o określonym identyfikatorze.
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            _service.DeleteOrder(id);
            return Ok();
        }

        /// <summary>
        /// Dodaje produkt do zamówienia.
        /// </summary>
        [HttpPost("{orderId}/product")]
        public IActionResult AddProductToOrder(int orderId, [FromBody] ProductResponseDTO product)
        {
            _service.AddProductToOrder(orderId, product);
            return Ok();
        }

        /// <summary>
        /// Usuwa produkt z zamówienia.
        /// </summary>
        [HttpDelete("{orderId}/product/{productId}")]
        public IActionResult RemoveProductFromOrder(int orderId, int productId)
        {
            _service.RemoveProductFromOrder(orderId, productId);
            return Ok();
        }

        /// <summary>
        /// Oblicza całkowity koszt zamówienia.
        /// </summary>
        [HttpGet("{orderId}/total")]
        public ActionResult<decimal> CalculateOrderTotal(int orderId)
        {
            var total = _service.CalculateOrderTotal(orderId);
            return Ok(total);
        }
    }
}

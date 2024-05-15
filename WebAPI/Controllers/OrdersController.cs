using BibliotekaKlasModel;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderBLL _service;

        public OrdersController(OrderBLL service)
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
        [HttpGet("{userId}")]
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
    }
}

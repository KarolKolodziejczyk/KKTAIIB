using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly BasketPostionBLL _service;

        public BasketController(BasketPostionBLL service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult AddToBasket([FromBody] ProductResponseDTO product)
        {
            _service.AddToBasket(product);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult ChangeAmount(int id, int amount)
        {
            _service.ChangeAmount(id, amount);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFromBasket(int id)
        {
            _service.DeleteFromBasket(id);
            return Ok();
        }

        [HttpGet("{userId}")]
        public IActionResult GetBasket(int userId)
        {
            var user = new UserResponseDTO { Id = userId };
            var basket = _service.GetBasket(user);
            return Ok(basket);
        }

        [HttpPost("{userId}/order")]
        public IActionResult Order(int userId)
        {
            var user = new UserResponseDTO { Id = userId };
            var order = _service.Order(user);
            return Ok(order);
        }
    }
}

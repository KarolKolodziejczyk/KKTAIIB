using BLL;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BibliotekaKlasModel;
using BLL_EF;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly Basket _service;

        public BasketController(Basket service)
        {
            _service = service;
        }

        /// <summary>
        /// Dodaje produkt do koszyka.
        /// </summary>
        [HttpPost]
        public IActionResult AddToBasket([FromBody] ProductResponseDTO product)
        {
            _service.AddToBasket(product);
            return Ok();
        }

        /// <summary>
        /// Zmienia ilość produktu w koszyku.
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult ChangeAmount(int id, [FromBody] int amount)
        {
            _service.ChangeAmount(id, amount);
            return Ok();
        }

        /// <summary>
        /// Usuwa produkt z koszyka.
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult DeleteFromBasket(int id)
        {
            _service.DeleteFromBasket(id);
            return Ok();
        }

        /// <summary>
        /// Pobiera koszyk dla określonego użytkownika.
        /// </summary>
        [HttpGet("{userId}")]
        public IActionResult GetBasket(int userId)
        {
            var user = new UserResponseDTO { Id = userId };
            var basket = _service.GetBasket(user);
            return Ok(basket);
        }

        /// <summary>
        /// Tworzy zamówienie na podstawie koszyka użytkownika.
        /// </summary>
        [HttpPost("{userId}/order")]
        public IActionResult Order(int userId)
        {
            var user = new UserResponseDTO { Id = userId };
            var order = _service.Order(user);
            return Ok(order);
        }
    }
}

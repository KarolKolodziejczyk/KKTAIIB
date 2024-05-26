using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAPI;
using BLL;
using BLL_EF;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IEnumerable<ProductResponseDTO> Get()
        {
            return _productService.GetProducts();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productService.DeleteProduct(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProductRequestDTO productRequestDTO)
        {
            _productService.UpdateProduct(id, productRequestDTO.Name, productRequestDTO.Price, productRequestDTO.Image, false);
            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProductRequestDTO productRequestDTO)
        {
            _productService.AddProduct(productRequestDTO);
            return Ok();
        }
    }
}

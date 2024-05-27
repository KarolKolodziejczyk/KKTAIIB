using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BLL_EF;
using BLL;

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
        public ActionResult<IEnumerable<ProductResponseDTO>> Get()
        {
            var products = _productService.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<ProductResponseDTO> Get(int id)
        {
            var product = _productService.GetProducts().FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet("paged")]
        public ActionResult<IEnumerable<ProductResponseDTO>> GetProductsPaged([FromQuery] int size, [FromQuery] int page)
        {
            var products = _productService.GetProductsPaged(size, page);
            return Ok(products);
        }

        [HttpGet("search")]
        public ActionResult<IEnumerable<ProductResponseDTO>> GetProductsByName([FromQuery] string name)
        {
            var products = _productService.GetProductsByName(name);
            return Ok(products);
        }

        [HttpGet("active")]
        public ActionResult<IEnumerable<ProductResponseDTO>> GetProductsByActive([FromQuery] bool isActive)
        {
            var products = _productService.GetProductsByActive(isActive);
            return Ok(products);
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
            _productService.UpdateProduct(id, productRequestDTO.Name, productRequestDTO.Price, productRequestDTO.Image, productRequestDTO.IsActive);
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

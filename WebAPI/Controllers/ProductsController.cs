using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductBLL _service;

        public ProductsController(ProductBLL service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<ProductResponseDTO> Get()
        {
            return _service.GetProducts();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.DeleteProduct(id);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProductRequestDTO productRequestDTO)
        {
            _service.UpdateProduct(productRequestDTO);
        }

        [HttpPost]
        public void Post([FromBody] ProductRequestDTO productRequestDTO)
        {
            _service.AddProduct(productRequestDTO);
        }
    }
}

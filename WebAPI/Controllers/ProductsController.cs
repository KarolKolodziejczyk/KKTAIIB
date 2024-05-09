using Microsoft.AspNetCore.Mvc;
using BLL_EF;
using BLL;
using BibliotekaKlasModel;
namespace Products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly ProductBLL _service;
        public ProductsController(ProductBLL service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<ProductResponseDTO> Get()
        {
            return this._service.GetProducts();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this._service.DeleteProduct(id);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProductRequestDTO studentRequestDTO)
        {
            //this._service.UpdateProduct(id, studentRequestDTO);
        }

        [HttpPost]
        public void Post([FromBody] ProductRequestDTO studentRequestDTO)
        {
            //this._service.PostStudent(studentRequestDTO);
        }
    }
}
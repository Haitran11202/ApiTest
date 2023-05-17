using Microsoft.AspNetCore.Mvc;
using TranHoangHai1517265.Dtos.ProductDto;
using TranHoangHai1517265.Services.Interfaces;

namespace TranHoangHai1517265.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _services;
        public ProductController (IProductServices services)
        {
            _services = services;
        }

        [HttpGet("{id}")]
        public IActionResult GetSanPhamById(int id)
        {
            var result = _services.GetProductById(id);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetFullSanPham()
        {
            var result = _services.GetAllProducts();
            return Ok(result);
        }

        [HttpGet("Get-new-product")]
        public IActionResult GetNewProduct ()
        {
            var result = _services.GetNewProduct();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddProduct(AddProductDto input)
        {
            var resutl = _services.AddProduct(input);
            return Ok(resutl);  
        }
      
    }
}

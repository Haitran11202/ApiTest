
using Microsoft.EntityFrameworkCore;
using TranHoangHai1517265.DbContexts;
using TranHoangHai1517265.Dtos.ProductDto;
using TranHoangHai1517265.Entities;
using TranHoangHai1517265.Services.Interfaces;

namespace TranHoangHai1517265.Services.Implements
{
    
    public class ProductServices : IProductServices
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductServices(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        public GetProductDto GetProductById (int id)
        {
            var product = _dbContext.GetProductById(id);
            var productDto = new GetProductDto
            {
                Id = product.Id,
                TenSP = product.TenSP,
                MoTa = product.MoTa,
                Gia = product.Gia,
                
            };
            return productDto;
        }
        public GetProductDto GetNewProduct()
        {
            var result = _dbContext.GetNewProduct();
            return result;
        }
        public List<GetProductDto> GetAllProducts()
        {
            var result = _dbContext.GetAllProducts().OrderByDescending(p => p.Gia).ThenByDescending(p => p.Id).ToList();
            var listProduct = new List<GetProductDto>();
            foreach (var item in result)
            {
                var getProduct = new GetProductDto
                {
                    Id = item.Id,
                    TenSP = item.TenSP,
                    MoTa = item.MoTa,
                    Gia = item.Gia,
                };
                listProduct.Add(getProduct);
            }
            return listProduct;
        }
        public AddProductDto AddProduct(AddProductDto input)
        {
            var result = _dbContext.AddProduct(input);
            return result;
        }
        public GetProductDto EditProductById (int id, AddProductDto updateProduct)
        {
            var result = _dbContext.UpdateProduct(id, updateProduct);
            return result;
        }
       
    }
}

using TranHoangHai1517265.Dtos.ProductDto;

namespace TranHoangHai1517265.Services.Interfaces
{
    public interface IProductServices
    {
        AddProductDto AddProduct(AddProductDto input);
        GetProductDto EditProductById(int id, AddProductDto updateProduct);
        List<GetProductDto> GetAllProducts();
        GetProductDto GetNewProduct();
        GetProductDto GetProductById(int id);
        
    }
}

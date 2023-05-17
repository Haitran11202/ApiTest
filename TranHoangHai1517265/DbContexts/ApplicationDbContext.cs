using System.Collections.Generic;
using TranHoangHai1517265.Entities;
using Microsoft.EntityFrameworkCore;
using TranHoangHai1517265.Dtos.ProductDto;
using TranHoangHai1517265.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace TranHoangHai1517265.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        private static readonly List<Product> products = new List<Product>
        {
            new Product { Id = 1, TenSP = "Pin sạc dự phòng", MoTa = "5000 mah", Gia = 150000},
            new Product { Id = 2, TenSP = "Pin sạc dự phòng A", MoTa = "5000 mah", Gia = 140000},

        };

        public List<Product> GetAllProducts()
        {
            return products.ToList();
        }
        public GetProductDto GetNewProduct()
        {
            var result = products.Last();
            var getProduct = new GetProductDto
            {
                Id = result.Id,
                TenSP = result.TenSP,
                MoTa = result.MoTa,
                Gia = result.Gia,
            };
            return getProduct;
        }
        public AddProductDto AddProduct (AddProductDto product)
        {
            var productAdd = new Product
            {
                Id = products.Count + 1,
                TenSP = product.TenSP,
                MoTa = product.MoTa,
                Gia = product.Gia,
            };
            products.Add(productAdd);
            return product;
        }
        public Product GetProductById(int id)
        {
            return products.FirstOrDefault(p => p.Id == id);
        }

        
        public void DeleteProduct(int id)
        {
            var existingProduct = GetProductById(id);
            if (existingProduct != null)
            {
                products.Remove(existingProduct);
            }
        }

        public GetProductDto UpdateProduct(int id, AddProductDto updatedProduct)
        {
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product != null)
            {
                if (products.Any(p => p.TenSP == updatedProduct.TenSP && p.Id != id))
                {
                    throw new UserFriendlyException("Product name must be unique.");
                }

                product.TenSP = updatedProduct.TenSP;
                product.MoTa = updatedProduct.MoTa;
                product.Gia = updatedProduct.Gia;

                var result = new GetProductDto
                {
                    Id = product.Id,
                    TenSP = updatedProduct.TenSP,
                    MoTa = updatedProduct.MoTa,
                    Gia = updatedProduct.Gia,
                };
                return result;
            }
            throw new UserFriendlyException("Không tồn tại sản phẩm.");


        }

    }
}

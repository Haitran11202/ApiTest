using System.ComponentModel.DataAnnotations;
using TranHoangHai1517265.Entities;

namespace TranHoangHai1517265.Dtos.ProductDto
{
    public class GetProductDto
    {
        public int Id { get; set; }

        public string TenSP { get; set; }

        public string MoTa { get; set; }
        public decimal Gia { get; set; }
    }
}

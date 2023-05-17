using System.ComponentModel.DataAnnotations;
using TranHoangHai1517265.Entities;

namespace TranHoangHai1517265.Dtos.ProductDto
{
    public class AddProductDto
    {
        public string TenSP
        {
            get => _tenSP;
            set => _tenSP = value?.Trim();
        }
        public string _tenSP;
        public string MoTa { get; set; }

        public decimal Gia { get; set; }
    }
}

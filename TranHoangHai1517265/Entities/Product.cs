using System.ComponentModel.DataAnnotations;

namespace TranHoangHai1517265.Entities
{
    public class Product
    {
        
        public int Id { get; set; }

        public string TenSP { get; set; }

        public string MoTa { get; set; }
        public decimal Gia { get; set; }
        
       
    }
}

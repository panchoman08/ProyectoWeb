using System.ComponentModel.DataAnnotations;

namespace ProyectoWeb.Models.buy_detail
{
    public class BuyDetailModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public int Units { get; set; }
        public decimal Discount { get; set; }
        public decimal Subtotal { get; set; }
    }

    public class BuyDetailCreateModel
    {
        [Required(ErrorMessage = "{0} must not be empty")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} must not be empty")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "{0} must not be empty")]
        public int Units { get; set; }
        public decimal Discount { get; set; }
        [Required(ErrorMessage = "{0} must not be empty")]
        public decimal Subtotal { get; set; }
    }
}

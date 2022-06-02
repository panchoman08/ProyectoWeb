using System.ComponentModel.DataAnnotations;

namespace ProyectoWeb.Models.buy
{
    public class BuyModel
    {
        public int Id { get; set; }
        public string NoDoc { get; set; }
        public string Serie { get; set; }
        public int SupplierId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
    }

    public class BuyCreateModel
    {
        [Required(ErrorMessage = "{0} must not be empty.")]
        public string NoDoc { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public string Serie { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public int SupplierId { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public decimal Total { get; set; }
    }
}

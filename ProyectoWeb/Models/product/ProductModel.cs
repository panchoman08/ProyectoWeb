using ProyectoWeb.Models.ErrorModel;
using System.ComponentModel.DataAnnotations;

namespace ProyectoWeb.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string? Sku { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double BuyPrice { get; set; }
        public int CategoryId { get; set; }
        public int StatusId { get; set; }
        public int MeasureId { get; set; }
        public string[]? ErrorMessage { get; set; }

    }

    public class ProductCreate
    {
        [Required(ErrorMessage = "{0} must not be empty")]
        public string? Sku { get; set; }
        [Required(ErrorMessage = "{0} must not be empty")]
        public string? Name { get; set; }
        public string? Description { get; set; }

        public double BuyPrice { get; set; }

        [Required(ErrorMessage = "{0} must not be empty")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "{0} must not be empty")]
        public int StatusId { get; set; }
        [Required(ErrorMessage = "{0} must not be empty")]
        public int MeasureId { get; set; }
     
    }

    public class ProductListModel
    {
        List<ProductModel>? Products { get; set; }
        ErrorResponse[]? ErrorMessage { get; set; }
    }
}

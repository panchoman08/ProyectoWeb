using System.ComponentModel.DataAnnotations;

namespace ProyectoWeb.Models.product_measure
{
    public class ProductMeasureModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ProductMeasureCreateModel
    {
        [Required(ErrorMessage = "{0} must not be empty.")]
        public string Name { get; set; }
    }
}

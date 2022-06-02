using System.ComponentModel.DataAnnotations;

namespace ProyectoWeb.Models
{
    public class ProductCatModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ProductCatCreateModel
    {
        [Required(ErrorMessage = "{0} must not be empty.")]
        public string Name { get; set; }
    }
}

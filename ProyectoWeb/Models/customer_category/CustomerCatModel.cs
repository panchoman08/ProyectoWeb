using System.ComponentModel.DataAnnotations;

namespace ProyectoWeb.Models.customer_category
{
    public class CustomerCatModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class CustomerCatCreateModel
    {
        [Required(ErrorMessage = "{0} must not be empty.")]
        public string Name { get; set; }
    }

}

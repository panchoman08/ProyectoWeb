using System.ComponentModel.DataAnnotations;

namespace ProyectoWeb.Models.customer
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string Nit { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }
        public string Phone { get; set; }
        public int CategoryId { get; set; }
    }

    public class CustomerCreateModel
    {
        [Required(ErrorMessage = "{0} must not be empty.")]
        public string Nit { get; set; }
        [Required(ErrorMessage = "{0} must not be empty.")]
        public string Name { get; set; }

        public string Address { get; set; }
        public string Phone { get; set; }
        [Required(ErrorMessage = "{0} must not be empty.")]
        public int CategoryId { get; set; }
    }
}

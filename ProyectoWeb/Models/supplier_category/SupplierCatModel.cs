using System.ComponentModel.DataAnnotations;

namespace ProyectoWeb.Models.supplier_category
{
    public class SupplierCatModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class SupplierCatCreateModel
    {
        [Required(ErrorMessage = "{0} must not be empty.")]
        public string Name { get; set; }
    }
}

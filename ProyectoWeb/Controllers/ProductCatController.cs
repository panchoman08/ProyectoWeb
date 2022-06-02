using Microsoft.AspNetCore.Mvc;
using ProyectoWeb.Models;
using ProyectoWeb.Repository.ProductCatRepositories;

namespace ProyectoWeb.Controllers
{
    public class ProductCatController : Controller
    {
        private readonly IProductCatRepository _productCatRepository;

        public ProductCatController(IProductCatRepository productCatRepository)
        {
            this._productCatRepository = productCatRepository;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _productCatRepository.GetAllAsync();

            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCatCreateModel category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var create = await _productCatRepository.CreateAsync(category);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            //dynamic model = new ExpandoObject();
            var categories = await _productCatRepository.GetByIdAsync(id);
            
            return View(categories.productCat);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, ProductCatCreateModel category)
        {
            var update = await _productCatRepository.UpdateAsync(category, id);

            if (!update.success)
            {
                return View();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var delete = await _productCatRepository.DeleteAsync(id);

            if (delete.success)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

    }
}

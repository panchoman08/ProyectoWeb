using Microsoft.AspNetCore.Mvc;
using ProyectoWeb.Models.supplier_category;
using ProyectoWeb.Repository.SupplierCatRepositories;

namespace ProyectoWeb.Controllers
{
    public class SupplierCatController : Controller
    {
        private readonly ISupplierCatRepository _supplierCatRepository;

        public SupplierCatController(ISupplierCatRepository supplierCatRepository)
        {
            this._supplierCatRepository = supplierCatRepository;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _supplierCatRepository.GetAllAsync();

            return View(categories);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SupplierCatCreateModel supplierCatCreate)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var create = await _supplierCatRepository.CreateAsync(supplierCatCreate);

            if (!create.success)
            {
                return View();
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var category = await _supplierCatRepository.GetByIdAsync(id);

            if (!category.success)
            {
                return RedirectToAction("Index");
            }


            return View(category.supplierCat);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, SupplierCatCreateModel supplierCatCreate)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var update = await _supplierCatRepository.UpdateAsync(supplierCatCreate, id);

            if (!update.success)
            {
                return View();
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var delete = await _supplierCatRepository.DeleteAsync(id);

            if (!delete.success)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

    }
}

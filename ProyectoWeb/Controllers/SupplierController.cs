using Microsoft.AspNetCore.Mvc;
using ProyectoWeb.Models.supplier;
using ProyectoWeb.Repository.SupplierCatRepositories;
using ProyectoWeb.Repository.SupplierRepositories;
using System.Dynamic;

namespace ProyectoWeb.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly ISupplierCatRepository _supplierCatRepository;

        public SupplierController(ISupplierRepository supplierRepository, ISupplierCatRepository supplierCatRepository)
        {
            this._supplierRepository = supplierRepository;
            this._supplierCatRepository = supplierCatRepository;
        }

        public async Task<IActionResult> Index()
        {
            var suppliers = await _supplierRepository.GetAllAsync();

            return View(suppliers);
        }

        public async Task<IActionResult> Create()
        {
            var categories = await _supplierCatRepository.GetAllAsync();
            ViewBag.Categories = categories;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SupplierCreateModel supplier)
        {
            var create = await _supplierRepository.CreateAsync(supplier);

            if (!create.success)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            dynamic model = new ExpandoObject();
            var supplier = await _supplierRepository.GetByIdAsync(id);
            var categories = await _supplierCatRepository.GetAllAsync();
            model.Categories = categories;
            model.Supplier = supplier.supplier;


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, SupplierCreateModel supplier)
        {
            var update = await _supplierRepository.UpdateAsync(supplier, id);

            if (!update.success)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var delete = await _supplierRepository.DeleteAsync(id);

            if (!delete.success)
            {
                return View();
            }

            return RedirectToAction("Index");
        }


    }
}

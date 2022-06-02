using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoWeb.Models.product_measure;
using ProyectoWeb.Repository.ProductMeasureRepository;

namespace ProyectoWeb.Controllers
{
    public class ProductMeasureController : Controller
    {
        private readonly IProductMeasureRepository _measureRepository;

        public ProductMeasureController(IProductMeasureRepository measureRepository)
        {
            this._measureRepository = measureRepository;
        }

        // GET: ProductMeasureController
        public async Task<ActionResult> Index()
        {
            var measures = await _measureRepository.GetAllAsync();
            return View(measures);
        }

        // GET: ProductMeasureController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductMeasureController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductMeasureController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductMeasureCreateModel productMeasure)
        {
            var create = await _measureRepository.CreateAsync(productMeasure);

            if (!create.success)
            {
                return View();
            }

            return RedirectToAction("Index");
        }

        // GET: ProductMeasureController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var measure = await _measureRepository.GetByIdAsync(id);

            if (!measure.success)
            {
                return RedirectToAction("Index");
            }

            return View(measure.measure);
        }

        // POST: ProductMeasureController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ProductMeasureCreateModel productMeasure)
        {
            var update = await _measureRepository.UpdateAsync(productMeasure, id);

            if (!update.success)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        // GET: ProductMeasureController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var delete = await _measureRepository.DeleteAsync(id);

            if (!delete.success)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        // POST: ProductMeasureController/Delete/5
        
    }
}

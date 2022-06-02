using Microsoft.AspNetCore.Mvc;
using ProyectoWeb.Models;
using ProyectoWeb.Providers.APiFerreteria.product;
using ProyectoWeb.Providers.APiFerreteria.product_state;
using ProyectoWeb.Repository.ProductCatRepositories;
using ProyectoWeb.Repository.ProductMeasureRepository;
using ProyectoWeb.Repository.ProductRepository;
using System.Dynamic;

namespace ProyectoWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductMeasureRepository _measureRepository;
        private readonly IProductCatRepository _categoryRepository;

        public ProductController(IProductRepository productRepository, IProductMeasureRepository measureRepository, IProductCatRepository catRepository)
        {
            this._productRepository = productRepository;
            this._measureRepository = measureRepository;
            this._categoryRepository = catRepository;
        }

        public async Task<IActionResult> Index()
        {

            var products = await _productRepository.GetAllAsync();
            
            return View(products);
        }

        public async Task<IActionResult> Create()
        {
            var categories = await _categoryRepository.GetAllAsync(); 
            var measures = await _measureRepository.GetAllAsync();
            ViewBag.Categories = categories;
            ViewBag.Measures = measures;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreate product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            
            var create = await _productRepository.CreateAsync(product);

            if (create.success)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Update(int id)
        {
            dynamic model = new ExpandoObject();
            var product = await _productRepository.GetByIdAsync(id);
            var categories = await _categoryRepository.GetAllAsync();
            var measures = await _measureRepository.GetAllAsync();
            model.Categories = categories;
            model.Measures = measures;
            model.Product = product.product;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, ProductCreate product)
        {
            var update = await _productRepository.UpdateAsync(product, id);

            if (!update.success)
            {
                return View();
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var delete = await _productRepository.DeleteAsync(id);

            if (delete.success)
            {
                return Redirect("Index");
            }

            return RedirectToAction("Index");
        }

    }
}

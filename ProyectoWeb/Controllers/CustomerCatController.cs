using Microsoft.AspNetCore.Mvc;
using ProyectoWeb.Models.customer_category;
using ProyectoWeb.Repository.CustomerCatRepositories;

namespace ProyectoWeb.Controllers
{
    public class CustomerCatController : Controller
    {
        private readonly ICustomerCatRepository _customerCatRepository;

        public CustomerCatController(ICustomerCatRepository customerCatRepository)
        {
            this._customerCatRepository = customerCatRepository;
        }


        public async Task<IActionResult> Index()
        {
            var categories = await _customerCatRepository.GetAllAsync();


            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(CustomerCatCreateModel category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var create = await _customerCatRepository.CreateAsync(category);

            if (!create.success)
            {
                return View();
            }

            return RedirectToAction("Index");
            
        }

        public async Task<IActionResult> Edit(int id)
        {
            var category = await _customerCatRepository.GetByIdAsync(id);

            return View(category.category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CustomerCatCreateModel customerCatCreate)
        {
            var update = await _customerCatRepository.UpdateAsync(id, customerCatCreate);

            if (!update.success)
            {
                return View();
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var delete = await _customerCatRepository.DeleteAsync(id);

            if (!delete.success)
            {
                return View();
            }

            return RedirectToAction("Index");
        }
        
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoWeb.Models.customer;
using ProyectoWeb.Repository.CustomerCatRepositories;
using ProyectoWeb.Repository.CustomerRepositories;
using System.Dynamic;

namespace ProyectoWeb.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerCatRepository _customerCatRepository;

        public CustomerController(ICustomerRepository customerRepository, ICustomerCatRepository customerCatRepository)
        {
            this._customerRepository = customerRepository;
            this._customerCatRepository = customerCatRepository;

        }
        // GET: Customer
        public async Task<ActionResult> Index()
        {
            var customers = await _customerRepository.GetAllAsync();

            return View(customers);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer/Create
        public async Task<ActionResult> Create()
        {
            var categories = await _customerCatRepository.GetAllAsync();
            ViewBag.Categories = categories;

            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public async Task<IActionResult> Create(CustomerCreateModel customer)
        {
            var create = await _customerRepository.CreateAsync(customer);

            if (!create.success)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

       
        public async Task<IActionResult> Edit(int id)
        {
            dynamic model = new ExpandoObject();
            var customer = await _customerRepository.GetByIdAsync(id);
            var categories = await _customerCatRepository.GetAllAsync();

            model.Customer = customer.customer;
            model.Categories = categories;

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CustomerCreateModel customer)
        {
            var update = await _customerRepository.UpdateAsync(id, customer);

            if (!update.success)
            {
                return View();
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var delete = await _customerRepository.DeleteAsync(id);

            if (!delete.success)
            {
                return View();
            }

            return RedirectToAction("Index");
        }
    }
}

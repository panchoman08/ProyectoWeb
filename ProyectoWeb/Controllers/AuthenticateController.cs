using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoWeb.Controllers
{
    public class AuthenticateController : Controller
    {
        // GET: AuthenticateController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AuthenticateController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AuthenticateController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuthenticateController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthenticateController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AuthenticateController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthenticateController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AuthenticateController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PCGerenteFacturacion.Models;

namespace PCGerenteFacturacion.Controllers
{
    public class TestController : Controller
    {
        // GET: TestController1
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FormTest(PersonModel person)
        {
            int id = person.Personid;
            //string name = person.Name;
            //int age = person.Age;

            return View();
        }

        public string FormSave(PersonModel person)
        {
            int personid = person.Personid;
            string name = person.Name;
            int age = person.Age;

            //save values in DB

            return "OK";
        }

        // GET: TestController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TestController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestController1/Create
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

        // GET: TestController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TestController1/Edit/5
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

        // GET: TestController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TestController1/Delete/5
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

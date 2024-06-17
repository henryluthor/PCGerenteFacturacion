using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PCGerenteFacturacion.DBModels;
using PCGerenteFacturacion.Models;

namespace PCGerenteFacturacion.Controllers
{
    public class InvoiceController : Controller
    {
        private PcgerentetestContext _context;

        public InvoiceController(PcgerentetestContext context)
        {
            _context = context;
        }

        // GET: InvoiceController
        public ActionResult Index()
        {
            return View();
        }

        public IActionResult InvoiceForm()
        {
            return View("InvoiceHead");
        }


        public GenericResponse<float> SaveInvoice(InvoiceHeadModel invoiceHead)
        {
            var messageToReturn = invoiceHead.TaxTwelve;
            return new GenericResponse<float>
            {
                StatusCode = 200,
                Message = "Factura generada exitosamente",
                Data = messageToReturn
            };
        }

        // GET: InvoiceController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InvoiceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InvoiceController/Create
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

        // GET: InvoiceController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InvoiceController/Edit/5
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

        // GET: InvoiceController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InvoiceController/Delete/5
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

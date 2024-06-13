using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PCGerenteFacturacion.DBModels;

namespace PCGerenteFacturacion.Controllers
{
    public class InvoiceHeadsController : Controller
    {
        private readonly PcgerentetestContext _context;

        public InvoiceHeadsController(PcgerentetestContext context)
        {
            _context = context;
        }

        // GET: InvoiceHeads
        public async Task<IActionResult> Index()
        {
            return View(await _context.InvoiceHeads.ToListAsync());
        }

        // GET: InvoiceHeads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceHead = await _context.InvoiceHeads
                .FirstOrDefaultAsync(m => m.IdInvoiceHead == id);
            if (invoiceHead == null)
            {
                return NotFound();
            }

            return View(invoiceHead);
        }

        // GET: InvoiceHeads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InvoiceHeads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdInvoiceHead,TaxZero,TaxTwelve,Total,DateTime")] InvoiceHead invoiceHead)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invoiceHead);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(invoiceHead);
        }

        // GET: InvoiceHeads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceHead = await _context.InvoiceHeads.FindAsync(id);
            if (invoiceHead == null)
            {
                return NotFound();
            }
            return View(invoiceHead);
        }

        // POST: InvoiceHeads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdInvoiceHead,TaxZero,TaxTwelve,Total,DateTime")] InvoiceHead invoiceHead)
        {
            if (id != invoiceHead.IdInvoiceHead)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invoiceHead);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoiceHeadExists(invoiceHead.IdInvoiceHead))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(invoiceHead);
        }

        // GET: InvoiceHeads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceHead = await _context.InvoiceHeads
                .FirstOrDefaultAsync(m => m.IdInvoiceHead == id);
            if (invoiceHead == null)
            {
                return NotFound();
            }

            return View(invoiceHead);
        }

        // POST: InvoiceHeads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoiceHead = await _context.InvoiceHeads.FindAsync(id);
            if (invoiceHead != null)
            {
                _context.InvoiceHeads.Remove(invoiceHead);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceHeadExists(int id)
        {
            return _context.InvoiceHeads.Any(e => e.IdInvoiceHead == id);
        }
    }
}

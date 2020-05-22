using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuiPay.Data;
using QuiPay.DbModels;

namespace QuiPay.Controllers
{
    public class ExchangeRatesController : Controller
    {
        private readonly QuiPayContext _context;

        public ExchangeRatesController(QuiPayContext context)
        {
            _context = context;
        }

        // GET: ExchangeRates
        public async Task<IActionResult> Index()
        {
            return View(await _context.ExchangeRate.ToListAsync());
        }

        // GET: ExchangeRates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exchangeRate = await _context.ExchangeRate
                .FirstOrDefaultAsync(m => m.ID == id);
            if (exchangeRate == null)
            {
                return NotFound();
            }

            return View(exchangeRate);
        }

        // GET: ExchangeRates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExchangeRates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID")] ExchangeRate exchangeRate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exchangeRate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exchangeRate);
        }

        // GET: ExchangeRates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exchangeRate = await _context.ExchangeRate.FindAsync(id);
            if (exchangeRate == null)
            {
                return NotFound();
            }
            return View(exchangeRate);
        }

        // POST: ExchangeRates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID")] ExchangeRate exchangeRate)
        {
            if (id != exchangeRate.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exchangeRate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExchangeRateExists(exchangeRate.ID))
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
            return View(exchangeRate);
        }

        // GET: ExchangeRates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exchangeRate = await _context.ExchangeRate
                .FirstOrDefaultAsync(m => m.ID == id);
            if (exchangeRate == null)
            {
                return NotFound();
            }

            return View(exchangeRate);
        }

        // POST: ExchangeRates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exchangeRate = await _context.ExchangeRate.FindAsync(id);
            _context.ExchangeRate.Remove(exchangeRate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExchangeRateExists(int id)
        {
            return _context.ExchangeRate.Any(e => e.ID == id);
        }
    }
}

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
    public class VoucherAccountLutsController : Controller
    {
        private readonly QuiPayContext _context;

        public VoucherAccountLutsController(QuiPayContext context)
        {
            _context = context;
        }

        // GET: VoucherAccountLuts
        public async Task<IActionResult> Index()
        {
            var quiPayContext = _context.VoucherAccountLut.Include(v => v.Account).Include(v => v.BankNote);
            return View(await quiPayContext.ToListAsync());
        }

        // GET: VoucherAccountLuts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voucherAccountLut = await _context.VoucherAccountLut
                .Include(v => v.Account)
                .Include(v => v.BankNote)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (voucherAccountLut == null)
            {
                return NotFound();
            }

            return View(voucherAccountLut);
        }

        // GET: VoucherAccountLuts/Create
        public IActionResult Create()
        {
            ViewData["AccountID"] = new SelectList(_context.Account, "ID", "ID");
            ViewData["BankNoteID"] = new SelectList(_context.Voucher, "ID", "ID");
            return View();
        }

        // POST: VoucherAccountLuts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,BankNoteAccountLutState,BankNoteID,AccountID")] VoucherAccountLut voucherAccountLut)
        {
            if (ModelState.IsValid)
            {
                _context.Add(voucherAccountLut);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountID"] = new SelectList(_context.Account, "ID", "ID", voucherAccountLut.AccountID);
            ViewData["BankNoteID"] = new SelectList(_context.Voucher, "ID", "ID", voucherAccountLut.BankNoteID);
            return View(voucherAccountLut);
        }

        // GET: VoucherAccountLuts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voucherAccountLut = await _context.VoucherAccountLut.FindAsync(id);
            if (voucherAccountLut == null)
            {
                return NotFound();
            }
            ViewData["AccountID"] = new SelectList(_context.Account, "ID", "ID", voucherAccountLut.AccountID);
            ViewData["BankNoteID"] = new SelectList(_context.Voucher, "ID", "ID", voucherAccountLut.BankNoteID);
            return View(voucherAccountLut);
        }

        // POST: VoucherAccountLuts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,BankNoteAccountLutState,BankNoteID,AccountID")] VoucherAccountLut voucherAccountLut)
        {
            if (id != voucherAccountLut.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(voucherAccountLut);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VoucherAccountLutExists(voucherAccountLut.ID))
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
            ViewData["AccountID"] = new SelectList(_context.Account, "ID", "ID", voucherAccountLut.AccountID);
            ViewData["BankNoteID"] = new SelectList(_context.Voucher, "ID", "ID", voucherAccountLut.BankNoteID);
            return View(voucherAccountLut);
        }

        // GET: VoucherAccountLuts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voucherAccountLut = await _context.VoucherAccountLut
                .Include(v => v.Account)
                .Include(v => v.BankNote)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (voucherAccountLut == null)
            {
                return NotFound();
            }

            return View(voucherAccountLut);
        }

        // POST: VoucherAccountLuts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var voucherAccountLut = await _context.VoucherAccountLut.FindAsync(id);
            _context.VoucherAccountLut.Remove(voucherAccountLut);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VoucherAccountLutExists(int id)
        {
            return _context.VoucherAccountLut.Any(e => e.ID == id);
        }
    }
}

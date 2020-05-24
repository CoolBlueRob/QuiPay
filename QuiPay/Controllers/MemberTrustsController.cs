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
    public class MemberTrustsController : Controller
    {
        private readonly QuiPayContext _context;

        public MemberTrustsController(QuiPayContext context)
        {
            _context = context;
        }

        // GET: MemberTrusts
        public async Task<IActionResult> Index()
        {
            return View(await _context.MemberTrust.ToListAsync());
        }

        // GET: MemberTrusts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memberTrust = await _context.MemberTrust
                .FirstOrDefaultAsync(m => m.ID == id);
            if (memberTrust == null)
            {
                return NotFound();
            }

            return View(memberTrust);
        }

        // GET: MemberTrusts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MemberTrusts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID")] MemberTrust memberTrust)
        {
            if (ModelState.IsValid)
            {
                _context.Add(memberTrust);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(memberTrust);
        }

        // GET: MemberTrusts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memberTrust = await _context.MemberTrust.FindAsync(id);
            if (memberTrust == null)
            {
                return NotFound();
            }
            return View(memberTrust);
        }

        // POST: MemberTrusts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID")] MemberTrust memberTrust)
        {
            if (id != memberTrust.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(memberTrust);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberTrustExists(memberTrust.ID))
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
            return View(memberTrust);
        }

        // GET: MemberTrusts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memberTrust = await _context.MemberTrust
                .FirstOrDefaultAsync(m => m.ID == id);
            if (memberTrust == null)
            {
                return NotFound();
            }

            return View(memberTrust);
        }

        // POST: MemberTrusts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var memberTrust = await _context.MemberTrust.FindAsync(id);
            _context.MemberTrust.Remove(memberTrust);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemberTrustExists(int id)
        {
            return _context.MemberTrust.Any(e => e.ID == id);
        }
    }
}

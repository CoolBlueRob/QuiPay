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
    public class MemberDetailsController : Controller
    {
        private readonly QuiPayContext _context;

        public MemberDetailsController(QuiPayContext context)
        {
            _context = context;
        }

        // GET: MemberDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.MemberDetails.ToListAsync());
        }

        // GET: MemberDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memberDetails = await _context.MemberDetails
                .FirstOrDefaultAsync(m => m.ID == id);
            if (memberDetails == null)
            {
                return NotFound();
            }

            return View(memberDetails);
        }

        // GET: MemberDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MemberDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID")] MemberDetails memberDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(memberDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(memberDetails);
        }

        // GET: MemberDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memberDetails = await _context.MemberDetails.FindAsync(id);
            if (memberDetails == null)
            {
                return NotFound();
            }
            return View(memberDetails);
        }

        // POST: MemberDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID")] MemberDetails memberDetails)
        {
            if (id != memberDetails.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(memberDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberDetailsExists(memberDetails.ID))
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
            return View(memberDetails);
        }

        // GET: MemberDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memberDetails = await _context.MemberDetails
                .FirstOrDefaultAsync(m => m.ID == id);
            if (memberDetails == null)
            {
                return NotFound();
            }

            return View(memberDetails);
        }

        // POST: MemberDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var memberDetails = await _context.MemberDetails.FindAsync(id);
            _context.MemberDetails.Remove(memberDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemberDetailsExists(int id)
        {
            return _context.MemberDetails.Any(e => e.ID == id);
        }
    }
}

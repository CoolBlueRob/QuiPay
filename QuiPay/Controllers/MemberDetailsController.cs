﻿using System;
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
            var quiPayContext = _context.MemberDetail.Include(m => m.Member);
            return View(await quiPayContext.ToListAsync());
        }

        // GET: MemberDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memberDetails = await _context.MemberDetail
                .Include(m => m.Member)
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
            ViewData["MemberID"] = new SelectList(_context.Member, "ID", "ID");
            return View();
        }

        // POST: MemberDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,MemberDetailsState,FirstName,LastName,Address1,Address2,City,State,CountryCode,ZipCode,WhenCreated,MemberID")] MemberDetail memberDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(memberDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MemberID"] = new SelectList(_context.Member, "ID", "ID", memberDetails.MemberID);
            return View(memberDetails);
        }

        // GET: MemberDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memberDetails = await _context.MemberDetail.FindAsync(id);
            if (memberDetails == null)
            {
                return NotFound();
            }
            ViewData["MemberID"] = new SelectList(_context.Member, "ID", "ID", memberDetails.MemberID);
            return View(memberDetails);
        }

        // POST: MemberDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,MemberDetailsState,FirstName,LastName,Address1,Address2,City,State,CountryCode,ZipCode,WhenCreated,MemberID")] MemberDetail memberDetails)
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
            ViewData["MemberID"] = new SelectList(_context.Member, "ID", "ID", memberDetails.MemberID);
            return View(memberDetails);
        }

        // GET: MemberDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memberDetails = await _context.MemberDetail
                .Include(m => m.Member)
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
            var memberDetails = await _context.MemberDetail.FindAsync(id);
            _context.MemberDetail.Remove(memberDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemberDetailsExists(int id)
        {
            return _context.MemberDetail.Any(e => e.ID == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyWallet.Data;
using MyWallet.Models;

namespace MyWallet.Controllers
{
    public class CostsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CostsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Costs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Costs.ToListAsync());
        }

        // GET: Costs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cost = await _context.Costs
                .FirstOrDefaultAsync(m => m.CostNum == id);
            if (cost == null)
            {
                return NotFound();
            }

            return View(cost);
        }

        // GET: Costs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Costs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CostNum,Costs")] Cost cost)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cost);
        }

        // GET: Costs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cost = await _context.Costs.FindAsync(id);
            if (cost == null)
            {
                return NotFound();
            }
            return View(cost);
        }

        // POST: Costs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CostNum,Costs")] Cost cost)
        {
            if (id != cost.CostNum)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CostExists(cost.CostNum))
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
            return View(cost);
        }

        // GET: Costs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cost = await _context.Costs
                .FirstOrDefaultAsync(m => m.CostNum == id);
            if (cost == null)
            {
                return NotFound();
            }

            return View(cost);
        }

        // POST: Costs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cost = await _context.Costs.FindAsync(id);
            _context.Costs.Remove(cost);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CostExists(int id)
        {
            return _context.Costs.Any(e => e.CostNum == id);
        }
    }
}

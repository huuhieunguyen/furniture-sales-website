using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Funiture_Project.Models;

namespace Funiture_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminCategoriesController : Controller
    {
        private readonly FurnitureContext _context;

        public AdminCategoriesController(FurnitureContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.DanhMucSp.ToListAsync());
        }

        // GET: Admin/AdminCategories/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danhMucSp = await _context.DanhMucSp
                .FirstOrDefaultAsync(m => m.MaDm == id);
            if (danhMucSp == null)
            {
                return NotFound();
            }

            return View(danhMucSp);
        }

        // GET: Admin/AdminCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaDm,TenDm")] DanhMucSp danhMucSp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(danhMucSp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(danhMucSp);
        }

        // GET: Admin/AdminCategories/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danhMucSp = await _context.DanhMucSp.FindAsync(id);
            if (danhMucSp == null)
            {
                return NotFound();
            }
            return View(danhMucSp);
        }

        // POST: Admin/AdminCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaDm,TenDm")] DanhMucSp danhMucSp)
        {
            if (id != danhMucSp.MaDm)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(danhMucSp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DanhMucSpExists(danhMucSp.MaDm))
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
            return View(danhMucSp);
        }

        // GET: Admin/AdminCategories/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danhMucSp = await _context.DanhMucSp
                .FirstOrDefaultAsync(m => m.MaDm == id);
            if (danhMucSp == null)
            {
                return NotFound();
            }

            return View(danhMucSp);
        }

        // POST: Admin/AdminCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var danhMucSp = await _context.DanhMucSp.FindAsync(id);
            _context.DanhMucSp.Remove(danhMucSp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DanhMucSpExists(string id)
        {
            return _context.DanhMucSp.Any(e => e.MaDm == id);
        }
    }
}

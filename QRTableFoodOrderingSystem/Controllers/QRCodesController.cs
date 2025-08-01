using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QRTableFoodOrderingSystem.Data;
using QRTableFoodOrderingSystem.Models;

namespace QRTableFoodOrderingSystem.Controllers
{
    public class QRCodesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QRCodesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: QRCodes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.QRCode.Include(q => q.Table);
            return View(await applicationDbContext.ToListAsync());
        }
       

        // GET: QRCodes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qRCode = await _context.QRCode
                .Include(q => q.Table)
                .FirstOrDefaultAsync(m => m.QRId == id);
            if (qRCode == null)
            {
                return NotFound();
            }

            return View(qRCode);
        }

        // GET: QRCodes/Create
        public IActionResult Create()
        {
            ViewBag.TableList = _context.Table.Where(t => t.IsAvaliable).Select(t => new SelectListItem{
                Value = t.TableNumber.ToString(), Text = $"Table {t.TableNumber}"}).ToList();
            return View();
            
        }
       
            // POST: QRCodes/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to.
            // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QRId,TableNumber,Code,QRGenerateDate")] QRCode qRCode)
        {
            if (ModelState.IsValid)
            {
                qRCode.QRGenerateDate = DateTime.Now;
                qRCode.Code= $"https://localhost:7122/{qRCode.TableNumber}";
                _context.Add(qRCode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TableNumber"] = new SelectList(_context.Set<Table>(), "TableNumber", "TableNumber", qRCode.TableNumber);
            return View(qRCode);
        }

        // GET: QRCodes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qRCode = await _context.QRCode.FindAsync(id);
            if (qRCode == null)
            {
                return NotFound();
            }
            ViewData["TableNumber"] = new SelectList(_context.Set<Table>(), "TableNumber", "TableNumber", qRCode.TableNumber);
            return View(qRCode);
        }

        // POST: QRCodes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("QRId,TableNumber,Code,QRGenerateDate")] QRCode qRCode)
        {
            if (id != qRCode.QRId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(qRCode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QRCodeExists(qRCode.QRId))
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
            ViewData["TableNumber"] = new SelectList(_context.Set<Table>(), "TableNumber", "TableNumber", qRCode.TableNumber);
            return View(qRCode);
        }

        // GET: QRCodes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qRCode = await _context.QRCode
                .Include(q => q.Table)
                .FirstOrDefaultAsync(m => m.QRId == id);
            if (qRCode == null)
            {
                return NotFound();
            }

            return View(qRCode);
        }

        // POST: QRCodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var qRCode = await _context.QRCode.FindAsync(id);
            if (qRCode != null)
            {
                _context.QRCode.Remove(qRCode);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QRCodeExists(int id)
        {
            return _context.QRCode.Any(e => e.QRId == id);
        }
    }
}

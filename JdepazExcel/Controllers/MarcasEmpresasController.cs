using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JdepazExcel.Models;

namespace JdepazExcel.Controllers
{
    public class MarcasEmpresasController : Controller
    {
        private readonly Autos_ExcelContext _context;

        public MarcasEmpresasController(Autos_ExcelContext context)
        {
            _context = context;
        }

       // [HttpPost]
        public async Task<IActionResult> Index()
        {
                var autos_ExcelContext = _context.MarcasEmpresa.Include(m => m.CodigoEmpresaNavigation).Include(m => m.CodigoMarcaNavigation).Include(m => m.CodigoSucursalNavigation);
                return View(await autos_ExcelContext.ToListAsync());
        }

        // GET: MarcasEmpresas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marcasEmpresa = await _context.MarcasEmpresa
                .Include(m => m.CodigoEmpresaNavigation)
                .Include(m => m.CodigoMarcaNavigation)
                .Include(m => m.CodigoSucursalNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (marcasEmpresa == null)
            {
                return NotFound();
            }

            return View(marcasEmpresa);
        }

        // GET: MarcasEmpresas/Create
        public IActionResult Create()
        {
            ViewData["CodigoEmpresa"] = new SelectList(_context.Empresas, "CodigoEmpresa", "CodigoEmpresa");
            ViewData["CodigoMarca"] = new SelectList(_context.Marcas, "CodigoMarca", "CodigoMarca");
            ViewData["CodigoSucursal"] = new SelectList(_context.Sucursales, "CodigoSucursal", "CodigoSucursal");
            return View();
        }

        // POST: MarcasEmpresas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CodigoMarca,CodigoEmpresa,CodigoSucursal,Detalles")] MarcasEmpresa marcasEmpresa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(marcasEmpresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodigoEmpresa"] = new SelectList(_context.Empresas, "CodigoEmpresa", "CodigoEmpresa", marcasEmpresa.CodigoEmpresa);
            ViewData["CodigoMarca"] = new SelectList(_context.Marcas, "CodigoMarca", "CodigoMarca", marcasEmpresa.CodigoMarca);
            ViewData["CodigoSucursal"] = new SelectList(_context.Sucursales, "CodigoSucursal", "CodigoSucursal", marcasEmpresa.CodigoSucursal);
            return View(marcasEmpresa);
        }

        // GET: MarcasEmpresas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marcasEmpresa = await _context.MarcasEmpresa.FindAsync(id);
            if (marcasEmpresa == null)
            {
                return NotFound();
            }
            ViewData["CodigoEmpresa"] = new SelectList(_context.Empresas, "CodigoEmpresa", "CodigoEmpresa", marcasEmpresa.CodigoEmpresa);
            ViewData["CodigoMarca"] = new SelectList(_context.Marcas, "CodigoMarca", "CodigoMarca", marcasEmpresa.CodigoMarca);
            ViewData["CodigoSucursal"] = new SelectList(_context.Sucursales, "CodigoSucursal", "CodigoSucursal", marcasEmpresa.CodigoSucursal);
            return View(marcasEmpresa);
        }

        // POST: MarcasEmpresas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CodigoMarca,CodigoEmpresa,CodigoSucursal,Detalles")] MarcasEmpresa marcasEmpresa)
        {
            if (id != marcasEmpresa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(marcasEmpresa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarcasEmpresaExists(marcasEmpresa.Id))
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
            ViewData["CodigoEmpresa"] = new SelectList(_context.Empresas, "CodigoEmpresa", "CodigoEmpresa", marcasEmpresa.CodigoEmpresa);
            ViewData["CodigoMarca"] = new SelectList(_context.Marcas, "CodigoMarca", "CodigoMarca", marcasEmpresa.CodigoMarca);
            ViewData["CodigoSucursal"] = new SelectList(_context.Sucursales, "CodigoSucursal", "CodigoSucursal", marcasEmpresa.CodigoSucursal);
            return View(marcasEmpresa);
        }

        // GET: MarcasEmpresas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marcasEmpresa = await _context.MarcasEmpresa
                .Include(m => m.CodigoEmpresaNavigation)
                .Include(m => m.CodigoMarcaNavigation)
                .Include(m => m.CodigoSucursalNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (marcasEmpresa == null)
            {
                return NotFound();
            }

            return View(marcasEmpresa);
        }

        // POST: MarcasEmpresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var marcasEmpresa = await _context.MarcasEmpresa.FindAsync(id);
            _context.MarcasEmpresa.Remove(marcasEmpresa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarcasEmpresaExists(int id)
        {
            return _context.MarcasEmpresa.Any(e => e.Id == id);
        }
    }
}

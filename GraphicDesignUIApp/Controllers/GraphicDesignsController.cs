using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GraphDesignApp;
using Microsoft.AspNetCore.Authorization;

namespace GraphicDesignUIApp.Controllers
{
    [Authorize]
    public class GraphicDesignsController : Controller
    {
        private readonly GraphicDesignContext _context;

        public GraphicDesignsController(GraphicDesignContext context)
        {
            _context = context;
        }

        // GET: GraphicDesigns
        public async Task<IActionResult> Index()
        {
            var graphicDesignContexts = ShoppingCart.GetGraphicDesignsByUser(HttpContext.User.Identity.Name);
            return View(graphicDesignContexts);
        }

        // GET: GraphicDesigns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var graphicDesign = await _context.GraphicDesigns
                .Include(g => g.User)
                .FirstOrDefaultAsync(m => m.GraphicDesignId == id);
            if (graphicDesign == null)
            {
                return NotFound();
            }

            return View(graphicDesign);
        }

        // GET: GraphicDesigns/Create
        public IActionResult Create()
        {
            ViewData["EmailAddress"] = new SelectList(_context.UserAccounts, "EmailAddress", "EmailAddress");
            return View();
        }

        // POST: GraphicDesigns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GraphicDesignId,DesignType,Color,Size,PaperQuality,ShippingType,UnitPrice,EmailAddress")] GraphicDesign graphicDesign)
        {
            if (ModelState.IsValid)
            {
                _context.Add(graphicDesign);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmailAddress"] = new SelectList(_context.UserAccounts, "EmailAddress", "EmailAddress", graphicDesign.EmailAddress);
            return View(graphicDesign);
        }

        // GET: GraphicDesigns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var graphicDesign = await _context.GraphicDesigns.FindAsync(id);
            if (graphicDesign == null)
            {
                return NotFound();
            }
            ViewData["EmailAddress"] = new SelectList(_context.UserAccounts, "EmailAddress", "EmailAddress", graphicDesign.EmailAddress);
            return View(graphicDesign);
        }

        // POST: GraphicDesigns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GraphicDesignId,DesignType,Color,Size,PaperQuality,ShippingType,UnitPrice,EmailAddress")] GraphicDesign graphicDesign)
        {
            if (id != graphicDesign.GraphicDesignId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(graphicDesign);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GraphicDesignExists(graphicDesign.GraphicDesignId))
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
            ViewData["EmailAddress"] = new SelectList(_context.UserAccounts, "EmailAddress", "EmailAddress", graphicDesign.EmailAddress);
            return View(graphicDesign);
        }

        // GET: GraphicDesigns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var graphicDesign = await _context.GraphicDesigns
                .Include(g => g.User)
                .FirstOrDefaultAsync(m => m.GraphicDesignId == id);
            if (graphicDesign == null)
            {
                return NotFound();
            }

            return View(graphicDesign);
        }

        // POST: GraphicDesigns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var graphicDesign = await _context.GraphicDesigns.FindAsync(id);
            _context.GraphicDesigns.Remove(graphicDesign);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GraphicDesignExists(int id)
        {
            return _context.GraphicDesigns.Any(e => e.GraphicDesignId == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ECommercePlateform.Data;
using ECommercePlateform.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace ECommercePlateform.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Products.Include(p => p.Category);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Orders)
                .FirstOrDefaultAsync(m => m.ProductId == id);
                
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,Name,Price,Color,Quantity,Pictures,Description,CategoryId")] Product product)
        {

            if (Request.Form.Files.Count > 0)
            {
                IFormFile file = Request.Form.Files.FirstOrDefault();
                using (var dataStream = new MemoryStream())
                {
                    await file.CopyToAsync(dataStream);
                    product.Pictures = dataStream.ToArray();
                    await _context.SaveChangesAsync();
                }
            }

            //if (ModelState.IsValid)
            //{
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            //ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", product.CategoryId);
            //return View(product);
        }

        [BindProperty]
        public ProductModel Input { get; set; }

        public class ProductModel
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public string Color { get; set; }
            public int Quantity { get; set; }
            public byte[]? Pictures { get; set; }
            public string Description { get; set; }
            public int? CategoryId { get; set; }
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            Input = new ProductModel
            {
                Name = product.Name,
                Price = product.Price,
                Color = product.Color,
                Quantity = product.Quantity,
                Description = product.Description,
                Pictures = product.Pictures,
                CategoryId = product.CategoryId,
            };

            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", product.CategoryId);
            return View(Input) ;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductModel product)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                Product? oldProduct = await _context.Products.FindAsync(id);
                if (oldProduct == null)
                {
                    return NotFound();
                }
                oldProduct.Name = product.Name;
                oldProduct.Price = product.Price;
                oldProduct.Color = product.Color;
                oldProduct.Quantity = product.Quantity;

                if (Request.Form.Files.Count > 0)
                {
                    IFormFile file = Request.Form.Files.FirstOrDefault();
                    using (var dataStream = new MemoryStream())
                    {
                        await file.CopyToAsync(dataStream);
                        oldProduct.Pictures = dataStream.ToArray();
                        await _context.SaveChangesAsync();
                    }
                }
                oldProduct.Description = product.Description;
                oldProduct.CategoryId = product.CategoryId;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                return View(product);
            }
            //ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", product.CategoryId);
            //return View(product);
        } 

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Products'  is null.");
            }
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ProductsOfCategory(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }
            
            var productByCategory = _context.Products.Include(p => p.Category).Where(p => p.CategoryId == id);
            if (productByCategory == null)
            {
                return NotFound();
            }

            //await applicationDbContext.ToListAsync().
            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            //ViewData["CategoryName"] = product.Category.CategoryName;
            return View(productByCategory);
        }

        public async Task<IActionResult> Filter(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var productByCategory = _context.Products.Include(p => p.Category).Where(p => p.CategoryId == id);
            if (productByCategory == null)
            {
                return NotFound();
            }

            //await applicationDbContext.ToListAsync().


            return View(productByCategory);
        }

        private bool ProductExists(int id)
        {
          return (_context.Products?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }
    }
}

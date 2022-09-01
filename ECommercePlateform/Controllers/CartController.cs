using ECommercePlateform.Data;
using ECommercePlateform.Infrastructure;
using ECommercePlateform.Models;
using ECommercePlateform.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommercePlateform.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<CartProduct> cartList =
                HttpContext.Session.GetJson<List<CartProduct>>("CartList") ?? new List<CartProduct>();

            FullCartViewModel fullCartView = new FullCartViewModel();
            fullCartView.CartProducts = cartList;
            fullCartView.TotalPrice = cartList.Sum(p => p.Quantity * p.Price);

            return View(fullCartView);
        }

        public async Task<IActionResult> AddOne(int id)
        {
            Product product = await _context.Products.FindAsync(id);
            List<CartProduct> cartList = HttpContext.Session.GetJson<List<CartProduct>>("CartList") ?? new List<CartProduct>();
            CartProduct cartProduct = cartList.Where(p => p.ProductId == id).FirstOrDefault();

            if (product.Quantity > 0)
            {
                if (cartProduct == null)
                {
                    cartList.Add(new CartProduct(product));
                }
                else
                {
                    cartProduct.Quantity++;
                }
                --product.Quantity;
                await _context.SaveChangesAsync();
            }
            else
            {
                ViewData["Qty"] = 1;
            }

            HttpContext.Session.SetJson("CartList", cartList);
            return Redirect(Request.Headers["Referer"].ToString());
        }
        public async Task<IActionResult> RemoveOne(int id)
        {
            Product product = await _context.Products.FindAsync(id);
            List<CartProduct> cartList = HttpContext.Session.GetJson<List<CartProduct>>("CartList");
            CartProduct cartProduct = cartList.Where(p => p.ProductId == id).FirstOrDefault();

            if (cartProduct.Quantity > 1)
            {
                --cartProduct.Quantity;
            }
            else
            {
                cartList.RemoveAll(p => p.ProductId == id);
            }
            product.Quantity++;
            await _context.SaveChangesAsync();

            if (cartList.Count == 0)
            {
                HttpContext.Session.Remove("CartList");
            }
            else
            {
                HttpContext.Session.SetJson("CartList", cartList);
            }
            return Redirect(Request.Headers["Referer"].ToString());
        }
        public async Task<IActionResult> RemoveProduct(int id)
        {
            Product product = await _context.Products.FindAsync(id);
            List<CartProduct> cartList = HttpContext.Session.GetJson<List<CartProduct>>("CartList");
            var count = cartList.FindAll(p => p.ProductId == id).Count();
            cartList.RemoveAll(p => p.ProductId == id);

            if (cartList.Count == 0)
            {
                HttpContext.Session.Remove("CartList");
            }
            else
            {
                HttpContext.Session.SetJson("CartList", cartList);
            }
            product.Quantity += count;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
/*using ECommercePlateform.Data;
using ECommercePlateform.Infrastructure;
using ECommercePlateform.Models;
using ECommercePlateform.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommercePlateform.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<CartProduct> cartList = 
                HttpContext.Session.GetJson<List<CartProduct>>("CartList") ?? new List<CartProduct>();

            FullCartViewModel fullCartView = new FullCartViewModel();
            fullCartView.CartProducts = cartList;
            fullCartView.TotalPrice = cartList.Sum(p => p.Quantity * p.Price);
            
            return View(fullCartView);
        }

        public async Task<IActionResult> AddOne(int id)
        {
            Product product = await _context.Products.FindAsync(id);
            List<CartProduct> cartList = HttpContext.Session.GetJson<List<CartProduct>>("CartList") ?? new List<CartProduct>();
            CartProduct cartProduct = cartList.Where(p => p.ProductId == id).FirstOrDefault();

            if(product.Quantity > 0)
            {
                if (cartProduct == null)
                {
                    cartList.Add(new CartProduct(product));
                }
                else
                {
                    cartProduct.Quantity++;
                }
                --product.Quantity;
                await _context.SaveChangesAsync();
            }
            else
            {
                ViewData["Qty"] = 1;
            }

            HttpContext.Session.SetJson("CartList", cartList);
            return Redirect(Request.Headers["Referer"].ToString());
        }
        public async Task<IActionResult> RemoveOne(int id)
        {
            Product product = await _context.Products.FindAsync(id);
            List<CartProduct> cartList = HttpContext.Session.GetJson<List<CartProduct>>("CartList");
            CartProduct cartProduct = cartList.Where(p => p.ProductId == id).FirstOrDefault();

            if (cartProduct.Quantity > 1)
            {
                --cartProduct.Quantity;
            }
            else
            {
                cartList.RemoveAll(p => p.ProductId == id);
            }
            product.Quantity++;
            await _context.SaveChangesAsync();

            if (cartList.Count == 0)
            {
                HttpContext.Session.Remove("CartList");
            }
            else
            {
                HttpContext.Session.SetJson("CartList", cartList);
            }
            return Redirect(Request.Headers["Referer"].ToString());
        }
        public async Task<IActionResult> RemoveProduct(int id)
        {
            Product product = await _context.Products.FindAsync(id);
            List<CartProduct> cartList = HttpContext.Session.GetJson<List<CartProduct>>("CartList");
            var count = cartList.FindAll(p => p.ProductId == id).Count();
            cartList.RemoveAll(p => p.ProductId == id);

            if (cartList.Count == 0)
            {
                HttpContext.Session.Remove("CartList");
            }
            else
            {
                HttpContext.Session.SetJson("CartList", cartList);
            }
            product.Quantity += count;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
*/
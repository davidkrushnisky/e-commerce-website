using ECommercePlateform.Data;
using ECommercePlateform.Infrastructure;
using ECommercePlateform.Models;
using ECommercePlateform.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
            List<CartItem> cartList =
                  HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            CartViewModel cartVM = new()
            {
                CartItems = cartList,
                TotalPrice = cartList.Sum(x => x.Count * x.Price)
            };
            return View(cartVM);
        }

        public async Task<IActionResult> Add(int id)
        {
            Product product = await _context.Products.FindAsync(id);

            List<CartItem> cartList =
                  HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            CartItem cartItem = cartList.Where(c => c.ItemId == id).FirstOrDefault();

            if(cartItem == null)
            {
                CartItem item = new CartItem(product);
                item.Count = 1;
                cartList.Add(item);
            }
            else
            {
                cartItem.Count += 1;
                cartItem.Quantity -= 1;
            }

            HttpContext.Session.SetJson("Cart", cartList);
            TempData["Success"] = "The product has been added!";
            return Redirect(Request.Headers["Referer"].ToString());
        }

        public async Task<IActionResult> Decrease(int id)
        {

            List<CartItem> cartList =
                  HttpContext.Session.GetJson<List<CartItem>>("Cart");

            CartItem cartItem = cartList.Where(c => c.ItemId == id).FirstOrDefault();

            if (cartItem.Count > 1)
            {
                --cartItem.Count;
            }
            else
            {
                cartList.RemoveAll(p => p.ItemId == id);
            }

            if(cartList.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cartList);
            }

            TempData["Success"] = "The product has been removed!";
            return Redirect(Request.Headers["Referer"].ToString());
        }

        public async Task<IActionResult> RemoveProduct(int id)
        {

            List<CartItem> cartList =
                  HttpContext.Session.GetJson<List<CartItem>>("Cart");

            cartList.RemoveAll(p => p.ItemId == id);

            if (cartList.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cartList);
            }

            TempData["Success"] = "The product has been removed!";
            return Redirect(Request.Headers["Referer"].ToString());
        }

        public IActionResult Clear()
        {
            HttpContext.Session.Remove("Cart");
         
            return RedirectToAction("index");
        }
    }
}

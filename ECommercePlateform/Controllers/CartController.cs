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
                  HttpContext.Session.GetJson<List<CartItem>>("CartList") ?? new List<CartItem>();

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
                cartList.Add(new CartItem(product));
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
    }
}

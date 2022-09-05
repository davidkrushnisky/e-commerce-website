using ECommercePlateform.Infrastructure;
using ECommercePlateform.Models;
using ECommercePlateform.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommercePlateform.ViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            List<CartItem> cartList =
                  HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            SmallCartViewModel cartView = new SmallCartViewModel();
            cartView.CartItems = cartList;
            cartView.TotalPrice = cartList.Sum(p => p.Count * p.Price);
            return View(cartView);
        }
    }
}

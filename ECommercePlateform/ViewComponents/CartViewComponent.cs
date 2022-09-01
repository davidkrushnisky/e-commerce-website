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

            List<CartProduct> cartList =
                HttpContext.Session.GetJson<List<CartProduct>>("CartList") ?? new List<CartProduct>();

            CartViewModel cartView = new CartViewModel();
            cartView.CartProducts = cartList;
            cartView.TotalPrice = cartList.Sum(p => p.Quantity * p.Price);
            return View(cartView);
        }
    }
}

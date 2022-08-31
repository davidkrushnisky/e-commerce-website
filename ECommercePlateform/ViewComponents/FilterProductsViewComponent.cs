using Microsoft.AspNetCore.Mvc;

namespace ECommercePlateform.ViewComponents
{
    public class FilterProductsViewComponent : ViewComponent
    {
        private readonly Data.ApplicationDbContext db;
        public FilterProductsViewComponent(Data.ApplicationDbContext context) => db = context;
        public IViewComponentResult Invoke()
        {
            var headphone = db.Categories.FirstOrDefault(c => c.CategoryName == "Headphones");
            ViewData["HeadphoneId"] = headphone.CategoryId;
            var keyboard = db.Categories.FirstOrDefault(c => c.CategoryName == "Keyboards");
            ViewData["KeyboardId"] = keyboard.CategoryId;
            var monitor = db.Categories.FirstOrDefault(c => c.CategoryName == "Monitors");
            ViewData["MonitorId"] = monitor.CategoryId;
            return View();
        }
    }
}

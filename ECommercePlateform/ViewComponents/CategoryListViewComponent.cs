using ECommercePlateform.Data;
using ECommercePlateform.Enums;
using ECommercePlateform.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ECommercePlateform.ViewComponents
{
    public class CategoryListViewComponent : ViewComponent
    {
        private readonly Data.ApplicationDbContext db;

        public CategoryListViewComponent(Data.ApplicationDbContext context) => db = context;
        public IViewComponentResult Invoke()
        {
            var model = db.Categories.ToList();
            return View(model);
        }
    }
}

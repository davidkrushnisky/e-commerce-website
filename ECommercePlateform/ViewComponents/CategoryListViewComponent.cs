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
        //private static readonly ApplicationDbContext _context = new ApplicationDbContext(DbContextOptions < ApplicationDbContext > options);

        
        public IViewComponentResult Invoke()
        {
            
            return View();
        }
    }
}

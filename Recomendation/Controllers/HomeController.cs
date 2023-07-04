using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Recomendation.Models;
using System.Diagnostics;
using System.Linq;

namespace Recomendation.Controllers
{
    public class HomeController : Controller
    {
        ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await db.KitchenGargen.ToListAsync());
        }
        public IActionResult Create()
        {
            ViewBag.InfoGardering = new SelectList(db.InfoGardering, "Id", "VegetableName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(KitchenGargen kitchenGargen)
        {
            kitchenGargen.VegetableName = db.InfoGardering.FirstOrDefault(item => item.Id == kitchenGargen.InfoGarderingId).VegetableName;
            db.KitchenGargen.Add(kitchenGargen);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
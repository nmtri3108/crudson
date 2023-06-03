using System.Diagnostics;
using DemoEfcoreSon.DbContext;
using Microsoft.AspNetCore.Mvc;
using DemoEfcoreSon.Models;

namespace DemoEfcoreSon.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _db;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
    {
        _logger = logger;
        _db = db;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var shops = _db.Shops.ToList();
        return View(shops);
    }
    
    [HttpGet]
    public IActionResult Delete(int shopId)
    {
        var shop = _db.Shops.Find(shopId);
        _db.Shops.Remove(shop);
        _db.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        return View(new Shop());
    }
    
    [HttpPost]
    public IActionResult Create(Shop shop)
    {
        if (!ModelState.IsValid)
            return View(shop);
        
        _db.Shops.Add(shop);
        _db.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
    
    [HttpGet]
    public IActionResult Update(int id)
    {
        var shop = _db.Shops.Find(id);
        return View(shop);
    }
    
    [HttpPost]
    public IActionResult Update(Shop shop)
    {
        _db.Shops.Update(shop);
        _db.SaveChanges();
        return RedirectToAction(nameof(Index));
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
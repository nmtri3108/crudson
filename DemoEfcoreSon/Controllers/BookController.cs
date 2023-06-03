using DemoEfcoreSon.DbContext;
using DemoEfcoreSon.Models;
using DemoEfcoreSon.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DemoEfcoreSon.Controllers;

public class BookController : Controller
{
    private readonly ApplicationDbContext _db;

    public BookController(ApplicationDbContext db)
    {
        _db = db;
    }
    // GET
    public IActionResult Index()
    {
        return View(_db.Books.ToList());
    }
    
    [HttpGet]
    public IActionResult Delete(int bookId)
    {
        var book = _db.Books.Find(bookId);
        _db.Books.Remove(book);
        _db.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        var bookVm = new CreateBookVm()
        {
            Book = new Book(),
            ShopList = _db.Shops.Select(x=> new SelectListItem
            {
                Text = x.ShopName,
                Value = x.Id.ToString()
            }).ToList()
        };
        return View(bookVm);
    }
    
    [HttpPost]
    public IActionResult Create(CreateBookVm createBookVm)
    {
        if (createBookVm.Book.Name == null || createBookVm.Book.PageNumber < 0 || createBookVm.Book.Author == null)
        {
            createBookVm.ShopList = _db.Shops.Select(x => new SelectListItem
            {
                Text = x.ShopName,
                Value = x.Id.ToString()
            }).ToList();
            
            return View(createBookVm);
        }
            
        
        _db.Books.Add(createBookVm.Book);
        _db.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
    
    [HttpGet]
    public IActionResult Update(int bookId)
    {
        var bookVm = new CreateBookVm()
        {
            Book = _db.Books.Find(bookId),
            ShopList = _db.Shops.Select(x=> new SelectListItem
            {
                Text = x.ShopName,
                Value = x.Id.ToString()
            }).ToList()
        };
        return View(bookVm);
    }
    
    [HttpPost]
    public IActionResult Update(CreateBookVm createBookVm)
    {
        if (createBookVm.Book.Name == null || createBookVm.Book.PageNumber < 0 || createBookVm.Book.Author == null)
        {
            createBookVm.ShopList = _db.Shops.Select(x => new SelectListItem
            {
                Text = x.ShopName,
                Value = x.Id.ToString()
            }).ToList();
            
            return View(createBookVm);
        }
            
        
        _db.Books.Update(createBookVm.Book);
        _db.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}
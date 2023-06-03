using DemoEfcoreSon.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DemoEfcoreSon.ViewModels;

public class CreateBookVm
{
    public Book Book { get; set; }
    public List<SelectListItem> ShopList { get; set; }
}
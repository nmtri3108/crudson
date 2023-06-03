using System.ComponentModel.DataAnnotations;

namespace DemoEfcoreSon.Models;

public class Shop
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "Bạn Cần nhập vào shop name")]
    [Display(Name = "Shop Name")]
    public string ShopName { get; set; }
    [Required]
    public string Address { get; set; }
}